
using System;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Requests;

namespace UsersApi.Services
{
    public class LoginService
    {
        //login manager
        private SignInManager<IdentityUser<int>> _singInManager;

        public Result UserLogin(LoginRequest request)
        {
            //SingInManager will try the authentication using password
           var result = _singInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
           if(result.Result.Succeeded) return Result.Ok();
           return Result.Fail("Login Not authorized");
        }
    }
}