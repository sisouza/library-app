using Microsoft.AspNetCore.Mvc;

namespace library_app.UsersApi.Controllers
{
    [Route("[controller")]
    [ApiController]
    public class RegisterController: ControllerBase
    {
        [HttpPost]
        public IActionResult RegisterUser(CreateUserDto createUserDto)
        {
            return Ok();
        }
    }
}