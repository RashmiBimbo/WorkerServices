using AutoMapper;
using CommonCode.Jwt;
using CommonCode.Models.Dtos;
using CommonCode.Models.Dtos.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SqlIntegrationAPI.Models.Domains.Identity;

namespace SqlIntegrationAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, ILogger<ServicesAPIController> logger, IJwtService jwtService) : ControllerBase
{
    private readonly UserManager<AppUser> userManager = userManager;
    private readonly SignInManager<AppUser> signInManager = signInManager;
    private readonly RoleManager<AppRole> roleManager = roleManager;
    private readonly IMapper mapper = mapper;
    private readonly ILogger<ServicesAPIController> logger = logger;
    private readonly IJwtService jwtService = jwtService;

    [HttpPost("Register")]
    public async Task<ActionResult<AppUser>> PostRegister(RegisterDto registerDTO)
    {
        //Validation
        if (ModelState.IsValid == false)
        {
            string errMsg = string.Join("|", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            return BadRequest(errMsg);
        }

        AppUser user = mapper.Map<AppUser>(registerDTO);
        AppUserDto userDto = mapper.Map<AppUserDto>(user);
        user.UserName = registerDTO.UserName;
        IdentityResult result = await userManager.CreateAsync(user, registerDTO.Password);
        if (result.Succeeded)
        {
            //sign-in
            await signInManager.SignInAsync(user, isPersistent: false);

            var authResponse = jwtService.CreateJwtToken(userDto);
            return Ok(authResponse);
        }
        else
        {
            string errMsg = string.Join(" | ", result.Errors.Select(e => e.Description)); //error1 | error2
            return Problem(errMsg);
        }
    }

    [HttpGet]
    public async Task<IActionResult> IsUserNameAlreadyRegistered(string userName)
    {
        try
        {
            AppUser? user = await userManager.FindByNameAsync(userName);

            return Ok(user != null);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpGet("LogOut")]
    public async Task<IActionResult> GetLogOut()
    {
        signInManager.SignOutAsync();
        return NoContent();
    }

    [HttpPost("LogIn")]
    public async Task<ActionResult<Models.Domains.Identity.AppUser>> PostLogin(LoginDto loginDto)
    {
        //Validation
        if (ModelState.IsValid == false)
        {
            string errMSg = string.Join("|", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            return BadRequest(errMSg);
        }
        var result = await signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, isPersistent: false, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            AppUser user = await userManager.FindByNameAsync(loginDto.UserName);
            if (user != null)
            {
                AppUserDto userDto = mapper.Map<AppUserDto>(user);
                var authResponse = jwtService.CreateJwtToken(userDto);
                return Ok(authResponse);
            }
            return NoContent();
            //return result is null ? NoContent() : Ok(new { PersonName = user.PersonName, PersonEmail = user.Email });
        }
        else
        {
            //string errMsg = string.Join(" | ", result..Select(e => e.Description)); //error1 | error2
            return Problem("Invalid Email or Password!");
        }
    }
}
