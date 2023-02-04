using Egen.API.Controllers;
using Egen.Dto.Security;
using Egen.IRepository.Interfaces.Security;
using Egen.IService.Infrastructure;
using Egen.IService.Interfaces.Security;
using Egen.Repository;
using Egen.Repository.Repositories.Security;
using Egen.Service.Infrastructure;
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

namespace Egen.APITest.Security
{
    public class UserControllerTest
    {
        string idbConn = string.Empty;
        private readonly IConfiguration _configuration;
        private UserController _sut;
        private Mock<IUserService> _userServiceMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IRepositoryConfiguration _repositoryConfiguration;

        public UserControllerTest()
        {
            _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@"appsettings.json", false, false)
            .AddEnvironmentVariables()
            .Build();
            idbConn = _configuration.GetConnectionString("IdentityDbConnection");
            
            _userServiceMock = new Mock<IUserService>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _sut = new UserController(_unitOfWorkMock.Object);
            _repositoryConfiguration = new RepositoryConfiguration(idbConn, string.Empty, string.Empty, string.Empty);
            _userRepository = new UserRepository(_repositoryConfiguration);
            _userService = new UserService(_userRepository);
            _unitOfWork = new UnitOfWork(_userService);
        }

        [Fact]
        public async void GetAll_ShouldReturn()
        {
            ///Arrange
            var expected = HttpStatusCode.OK;

            ///Act
            var result = await _sut.GetAllAsync();

            ///Asset
            Assert.NotNull(result);
            
        }

        [Fact]
        public async void GetAllAsync_ShouldReturn200Status()
        {

            ///Arrange
            var expected = HttpStatusCode.OK;

            ///Act
            var result = await _sut.GetAllAsync();

            ///Asset
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }

        [Fact]
        public async void GetAllAsync_ShouldReturnMockData()
        {
            ///Arrange
            var expected = new Egen.Dto.Security.UserDto();
            var users = new List<Egen.Dto.Security.UserDto>(){
                new UserDto() { Id=1, Name="Chapas", Email="chapas@eg.co", IsActive=true},
                new UserDto() { Id=2, Name="Chapas2", Email="2chapas@eg.co", IsActive=true},
                new UserDto() { Id=3, Name="Chapas3", Email="3chapas@eg.co", IsActive=true}
            };
            _userServiceMock.Setup(x=> x.GetAllAsync()).ReturnsAsync(users);

            ///Act
            var result = await _sut.GetAllAsync();

            ///Asset
            Assert.NotNull(result);
            Assert.True(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value is IEnumerable<Egen.Dto.Security.UserDto>);

        }

        //[Fact]
        //public async Task GetAllAsync_ShouldReturnDataFromDb()
        //{
        //    ///Arrange
        //    var expected = new Egen.Dto.Security.UserDto();

        //    ///Act
        //    var result = await _userService.GetAllAsync();

        //    ///Asset
        //    Assert.NotNull(result);
        //    Assert.True(result is IEnumerable<Egen.Dto.Security.UserDto>);
        //    Assert.True(result.Count() > 0);

        //    foreach (var item in result)
        //    {
        //        Assert.True(item.Id > 0);
        //        Assert.True(!string.IsNullOrEmpty(item.Name));
        //        Assert.True(!string.IsNullOrEmpty(item.Email));
        //        Assert.True(item.Name.Length <= 50);
        //        Assert.True(item.Email.Length <= 50);
        //    }

        //}

        //[Theory]
        //[InlineData(1)]
        //[InlineData(2)]
        //public async Task GetByIdAsync(int Id)
        //{
        //    ///Arrange
        //    var data = 100;

        //    ///Act
        //    var result = await _userService.GetByIdAsync(Id);

        //    ///Asset
        //    Assert.NotNull(result);
        //    Assert.True(result is Egen.Dto.Security.UserDto);
        //    Assert.True(result.Email.Length > 0);

        //}


    }
}
