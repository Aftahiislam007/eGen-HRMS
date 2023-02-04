using Egen.API.Controllers;
using Egen.IRepository.Interfaces.Security;
using Egen.IService.Interfaces.Security;
using Egen.Repository;
using Egen.Repository.Repositories.Security;
using Egen.Service.Services.Security;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Egen.APITest.Security;

public  class TestUserController
{
    //https://www.thecodebuzz.com/read-appsettings-json-in-net-core-test-project-xunit-mstest/
    //https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/

    string idbConn = string.Empty;
    private readonly IConfiguration _configuration;
    private UserController _sut;
    private Mock<IUserService> _userServiceMock;
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;
    private readonly IRepositoryConfiguration _repositoryConfiguration;
    

    public TestUserController()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@"appsettings.json",false,false)
            .AddEnvironmentVariables()
            .Build();
        idbConn = _configuration.GetConnectionString("IdentityDbConnection");
        _userServiceMock = new Mock<IUserService>();
        _sut = new UserController(_userServiceMock.Object);
        _repositoryConfiguration = new RepositoryConfiguration(idbConn, string.Empty,string.Empty,string.Empty);
        _userRepository = new UserRepository(_repositoryConfiguration);
        _userService = new UserService(_userRepository);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturn200Status()
    {

        ///Arrange
        var expected = HttpStatusCode.OK;

        ///Act
        var result = await _sut.GetAll();

        ///Asset
        result.GetType().Should().Be(typeof(OkObjectResult));
        (result as OkObjectResult).StatusCode.Should().Be(200);

    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnDataFromDb()
    {
        ///Arrange
        var expected = new Egen.Dto.Security.UserDto();

        ///Act
        var result = await _userService.GetAllAsync();

        ///Asset
        Assert.NotNull(result);
        Assert.True(result is IEnumerable<Egen.Dto.Security.UserDto>);
        Assert.True(result.Count() > 0);

        foreach (var item in result)
        {
            Assert.True(item.Id > 0);
            Assert.True(!string.IsNullOrEmpty(item.Name));
            Assert.True(!string.IsNullOrEmpty(item.Email));
            Assert.True(item.Name.Length<=50);
            Assert.True(item.Email.Length <= 50);
        }

    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async Task GetByIdAsync(int Id)
    {
        ///Arrange
        var data = 100;

        ///Act
        var result = await _userService.GetByIdAsync(Id);

        ///Asset
        Assert.NotNull(result);
        Assert.True(result is Egen.Dto.Security.UserDto);
        Assert.True(result.Email.Length > 0);

    }


}
