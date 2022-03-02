
using System;
using System.Linq;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Requests;
using UsersApi.Models;

namespace UsersApi.Services
{
    public class LoginService
    {
        //login manager
        private SignInManager<IdentityUser<int>> _singInManager;
        //import TokenService
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> singInManager, TokenService tokenService)
        {
            _singInManager = singInManager;
            _tokenService = tokenService;
        }

        public Result UserLogin(LoginRequest request)
        {
            //SingInManager will try the authentication using password
            var result = _singInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
            if (result.Result.Succeeded)
            {

                //recover user that has logged and verifies if it is the same user as request user
                var identityUser = _singInManager
                    .UserManager
                    .Users
                //checks if username of the user logged in normalized(uppercase) equals username normalized(uppercase) found in database    
                    .FirstOrDefault(user => user.NormalizedUserName == request.Username.ToUpper());

                //token that will be send to LoginController and user
                Token token = _tokenService.CreateToken(identityUser);

                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login Not authorized");
        }
    }
}