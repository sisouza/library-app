using FluentResults;
using library_app.UsersApi.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Requests;

namespace library_app.UsersApi.Controllers
{
    [Route("[controller")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private UserService _userService;

        public RegisterController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult RegisterUser(CreateUserDto createUserDto)
        {
            Result result = _userService.RegisterUser(createUserDto);
            if (result.IsFailed) return StatusCode(500);
            //return account activation code
            return Ok(result.Successes);
        }

        [HttpPost("/active")]
        public IActionResult ActiveAccount(ActiveAccountRequest request)
        {
            Result result = _userService.ActiveAccount(request);
            if (result.IsFailed) return StatusCode(500);
            return Ok(result.Successes);
        }
    }
}