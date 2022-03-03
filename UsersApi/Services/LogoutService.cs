
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsersApi.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _singInManager;

        public LogoutService(SignInManager<IdentityUser<int>> singInManager)
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