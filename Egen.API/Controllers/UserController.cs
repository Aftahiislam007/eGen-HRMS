using AutoMapper;
using Egen.Dto.Security;
using Egen.Dto.Security.User;
using Egen.IRepository.Infrastructure;
using Egen.IService.Infrastructure;
using Egen.IService.Interfaces.Security;
using Egen.Model.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;

namespace Egen.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns>List of all active users</returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _userService.GetAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Error obtaining all user list:{ex.Message}"
                });
            }

        }

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="Id">Id of User</param>
        /// <returns>User entity</returns>
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                if (user == null)
                    return Ok(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.Error("Error Getting Data==================>>>>>>>>>>>>>>>>>>>>>>>: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Error obtaining user information:{ex.Message}"
                });
            }
        }

        /// <summary>
        /// Add a new User
        /// </summary>
        /// <param name="userDto">User entity</param>
        /// <returns>Number of User added</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserCreateDTO userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                return Ok(await _userService.AddAsync(user));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Exception in posting user:{ex.Message}"
                });
            }
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="userDto">User entity</param>
        /// <returns>Number Users updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserDTO userDto)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);

                if (user == null)
                {
                    return NotFound();
                }
                _mapper.Map(userDto, user);
                await _userService.UpdateAsync(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Exception in updating user:{ex.Message}"
                });
            }
        }

        /// <summary>
        /// Delete User By Id
        /// </summary>
        /// <param name="Id">User Id</param>
        /// <returns>Number of user deleted</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);

                if (user == null)
                {
                    return NotFound();
                }
                await _userService.DeleteAsync(user);
                return Ok("Delete Successful!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Exception in posting user:{ex.Message}"
                });
            }
        }

        /// <summary>
        /// Get Users based on parameters
        /// </summary>
        /// <param name="Id">User Id</param>
        /// <param name="Name">Name of the user</param>
        /// <param name="Email">User Email</param>
        /// <param name="IsActive">User IsActive or not</param>
        /// <returns>List of Users based on provided parameter values</returns>
        /*[Produces("application/json")]
        [HttpGet(Name = "GetAsync")]
        public async Task<IActionResult> GetAsync(int? Id = null, string? Name = null, string? Email = null, bool? IsActive = null)
        {
            try
            {
                var users = await _unitOfWork.Users.GetAsync(Id: Id, Name: Name, Email: Email, IsActive: IsActive);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Error obtaining all user list:{ex.Message}"
                });
            }

        }*/

    }
}

