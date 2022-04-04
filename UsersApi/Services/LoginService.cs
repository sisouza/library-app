
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
        private SignInManager<CustomIdentityUser> _singInManager;
        //import TokenService
        private TokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> singInManager, TokenService tokenService)
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
                Token token = _tokenService.CreateToken(identityUser, _singInManager
                
                    //get current user(our identity user) role to manage access
                    //binding role to user
                    .UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());

                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login Not authorized");
        }

        public Result RequestUserResetPassword(ResetPasswordRequest request)
        {
            //call find by email to check if email exists in app db
            CustomIdentityUser identityUser = RecoverUserByEmail(request.Email);

            if (identityUser != null)
            {
                string recoveryCode = _singInManager
                 .UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(recoveryCode);
            }

            return Result.Fail("Request Reset Password Failed");

        }

        public Result ResetUserPassword(PasswordResetRequest request)
        {
            //call find by email to check if email exists in app db
            CustomIdentityUser identityUser = RecoverUserByEmail(request.Email);

            IdentityResult result = _singInManager
               .UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password)
               .Result;

            if (result.Succeeded) return Result.Ok()
                 .WithSuccess("Password redefined with success");
            return Result.Fail("An error occured during password redefinition");

        }


        //method to find user by email so we dont need to write the same code everytime and just call the method instead
        private CustomIdentityUser RecoverUserByEmail(string email)
        {
            return _singInManager
              .UserManager
              .Users
              .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}