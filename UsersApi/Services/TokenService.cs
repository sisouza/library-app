
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using UsersApi.Models;

namespace UsersApi.Services
{

    public class TokenService
    {

        //add role param cause user access will be manager through token (id, username, role) - token will also store role info 
        public Token CreateToken(IdentityUser<int> user, string role)
        {

            //what user must have to generate a token
            Claim[] userRights = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            //generate a security key
            var userKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fhkdafhaflkalkfklja"));

            //generate credentials from userKey
            var credentials = new SigningCredentials(userKey, SecurityAlgorithms.HmacSha256);

            //generate token that will be send to user
            var token = new JwtSecurityToken(
                claims: userRights,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddHours(1)
            );

            //convert token into a string to be stored
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString);
        }
    }

}