
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsersApi.Models;

namespace UsersApi.Services
{
    public class LogoutService
    {
        private SignInManager<CustomIdentityUser> _singInManager;

        public LogoutService(SignInManager<CustomIdentityUser> singInManager)
        {
            _singInManager = singInManager;
        }

        public Result Logout()
        {
            var identityResult = _singInManager.SignOutAsync();
            if (identityResult.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Logout failed");
        }
    }
}