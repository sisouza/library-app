
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Services;

namespace UsersApi.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult userLogout(){
            Result result = _logoutService.Logout();
            if(result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);
        }

    }
}