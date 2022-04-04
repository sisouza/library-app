using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using library_app.UsersApi.Data.Dtos;
using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Requests;
using UsersApi.Models;
using UsersApi.Services;

public class UserService
{
    private IMapper _mapper;
    private UserManager<CustomIdentityUser> _userManager;
    private EmailService _emailService;
    private RoleManager<IdentityRole<int>> _roleManager;

    public UserService(IMapper mapper, UserManager<CustomIdentityUser> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _emailService = emailService;
        _roleManager = roleManager;
    }

    public Result RegisterUser(CreateUserDto createDto)
    {
        User user = _mapper.Map<User>(createDto);
        CustomIdentityUser userIdentity = _mapper.Map<CustomIdentityUser>(user);
        //user that was mapped has a password
        Task<IdentityResult> resultIdentity = _userManager.CreateAsync(userIdentity, createDto.Password);
        //set default role during register
        _userManager.AddToRoleAsync(userIdentity, "regular");

        //create a new role
        var createRoleResult = _roleManager.CreateAsync(new IdentityRole<int>("admin")).Result;

        //Add role to user during create
        var userRole = _userManager
        .AddToRoleAsync(userIdentity, "admin").Result;


        if (resultIdentity.Result.Succeeded)
        {
            //generates account confirmation code
            var code = _userManager.GenerateEmailConfirmationTokenAsync(userIdentity).Result;
            
            _emailService.SendEmail(new[] { userIdentity.Email }, "Activation Link", userIdentity.Id, code);
            return Result.Ok().WithSuccess(code).WithSuccess(userIdentity.Id.ToString());;
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