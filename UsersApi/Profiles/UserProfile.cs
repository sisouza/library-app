
using library_app.UsersApi.Data.Dtos;
using UsersApi.Models;
using AutoMapper;

namespace library_app.UsersApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
        }
    }

}