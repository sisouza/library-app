using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using library_app.UsersApi.Data.Dtos;
using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Requests;
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

    //user account activation
    public Result ActiveAccount(ActiveAccountRequest request)
    {

        var identityUser = _userManager
        .Users
        //checks if user id request equals id found in database    
        .FirstOrDefault(u => u.Id == request.UserId);

        var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.ActivationCode).Result;

        if (identityResult.Succeeded)
        {
            return Result.Ok();
        }
        return Result.Fail("An error occured during user account activation");
    }
}