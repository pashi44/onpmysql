using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;



using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
[ApiController]
[Route("api/[controller]")]
[Authorize]

//UserManger class to manage the users

public class AccountController : ControllerBase
{


    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AccountController> _logger;
    public AccountController(UserManager<AppUser> userManager,
                             IConfiguration configuration,
                             ILogger<AccountController> logger)

    {
        this._userManager = userManager;
        this._configuration = configuration;

        this._logger = logger;
    }


    [HttpPost("redister")]


    //this method should take the addorudate Usre odel whish has 
    //emial. and password
    public async Task<IActionResult> Register([FromBody]
    AddOrUpdateAppUserModel model)
    {

        if (ModelState.IsValid)
        {

            AppUser? existingUser = await
            _userManager.FindByNameAsync(model.UserName);


            if (existingUser != null)
            {
                ModelState.AddModelError(
                    "",
                    "UserName already  taken"
                );

                return BadRequest(ModelState);

            }


            Models.Identity.AppUser? newUser = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            //saving the suer to dbContext

            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (result.Succeeded)
            {
                var token = GenerateToken(model.UserName);
}
       
       
       
       
        }


        return  ;

    }






}