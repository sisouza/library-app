
using library_app.UsersApi.Data.Dtos;
using UsersApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace library_app.UsersApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, IdentityUser<int>>();
            CreateMap<User, CustomIdentityUser>();
        }
    }

}