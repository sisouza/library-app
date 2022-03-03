using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using library_app.UsersApi.Data.Dtos;
using Microsoft.AspNetCore.Identity;
using UsersApi.Models;

public class UserService
{
    private IMapper _mapper;
    private UserManager<IdentityUser<int>> _userManager;

    public UserService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public Result RegisterUser(CreateUserDto createDto)
    {
        User user = _mapper.Map<User>(createDto);
        IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
        //user that was mapped has a password
        Task<IdentityResult> resultIdentity = _userManager.CreateAsync(userIdentity, createDto.Password);
        if (resultIdentity.Result.Succeeded)
        {
            //generates account confirmation code
            var code = _userManager.GenerateEmailConfirmationTokenAsync(userIdentity).Result;
            return Result.Ok().WithSuccess(code);
        }
        return Result.Fail("An error occur while registering User");

    }
}