
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Requests;
using UsersApi.Services;

namespace UsersApi.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class LoginControlle : ControllerBase
    {
        private LoginService _loginService;

        public LoginControlle(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult UserLogin(LoginRequest request)
        {
            Result result = _loginService.UserLogin(request);
            if (result.IsFailed) return Unauthorized(result.Errors);
            //if everything is okay return token.value came from service
            return Ok(result.Successes);
        }

        [HttpPost("/request-password")]
        public IActionResult SendRequest(ResetPasswordRequest request){
            Result result = _loginService.RequestUserResetPassword(request);
            if(result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);
        }
    }
}