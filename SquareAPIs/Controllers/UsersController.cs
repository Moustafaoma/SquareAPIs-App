using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Square.Core.DTOs;
using Square.Core.Filters;
using Square.Core.Models;
using Square.Core.RepositoryServices;

namespace Square.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IActionResult Create(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new Users()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password,
                UserName = userDto.UserName,
            };
            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();
            return Ok(user);
        }
        [HttpGet("GetByEmail")]
        [LogSensitiveActionFilter]
        public IActionResult GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest("Email is required."); // Bad request if email is not provided
            }
            var user = _unitOfWork.Users.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound("User not found."); // Not found if no user matches the email
            }

            return Ok(user);
        }
        [HttpGet("GetByUserName")]
        [LogSensitiveActionFilter]
        public IActionResult GetByUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return BadRequest("UserName is required."); // Bad request if email is not provided
            }
            var user=_unitOfWork.Users.GetUserByUserName(userName);
            if (user == null)
                return NotFound();
                     return Ok(user);
        }

    }
}
