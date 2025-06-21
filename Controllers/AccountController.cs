using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Serilog;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]

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


    [HttpPost("register")]


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

            var assiginingRoles =
             await _userManager
             .AddToRolesAsync(
newUser, new List<string> { AppRoles.User}


            );
           
            if (result.Succeeded   && assiginingRoles.Succeeded)
            {
                var token = GenerateToken(model.UserName,  newUser);
                return Ok(new { token });
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }


        return BadRequest(ModelState);

    }//registerMethod




    /*When a user successfully logs in, the server generates a
     JSON Web Token (JWT) containing user-specific claims such as 
     user ID, role, and expiration time. This token is then signed
      using a shared secret key with an HMAC algorithm (e.g., HS256).
       The token is sent back to the client, which includes it in the
        Authorization header as a Bearer token with each subsequent request.
         Upon receiving a request, the server verifies the JWT by recalculating the signature
    using the same secret key and comparing it to the one in the token. 
    If the signature is valid and the token is not expired, the user is
     authenticated, and access is granted based on the claims. 
     This process allows statelessß authentication, where no server-side session storage is required.*/


    private async Task<string?> GenerateToken(string? userName, AppUser  user )
    {

        //_congiurati injected into out clas. with Iconfiguration class
        var secret = _configuration["JwtConfig:Secret"];
        var issuer = _configuration["JwtConfig:ValidIssuer"];
        var audience = _configuration["JwtConfig:ValidAudiences"];
        if (secret is null || issuer is null || audience is null)
        {
            throw
             new ApplicationException("Jwt is not set in the configuration");
        }


        var userRoles = await _userManager.GetRolesAsync(
            user
        );
        ///claimsthat the  user of this model does have ,
#pragma warning disable CS8604 // Possible null reference argument.
        var claims = new List<Claim>
        {
new Claim(ClaimTypes.Name,  user.UserName)
,
new Claim(AppClaimTypes.DrivingCountry, AppClaimTypes.DrivingCountry)
        };//claims  list
#pragma warning restore CS8604 // Possible null reference argument.

        claims.AddRange(userRoles.Select(role =>
            
            new Claim(ClaimTypes.Role , role)
            
            )
            
            
);

//  appended the claims 




            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.
       GetBytes(secret));
        Log.Information($"the signing key is {signingKey}");

        //JwtSecurityHandler generaes new JWT token

        /*In the preceding code, we are using the JwtSecurityTokenHandler class to generate
    the JWT token. The JwtSecurityTokenHandler class is from System.
    IdentityModel.Tokens.Jwt NuGet package. First, we get the configuration values from
    the appsettings.json file. Then, we create a SymmetricSecurityKey object using
    the secret key. The SymmetricSecurityKey object is used to sign the token.*/

        var tokenHandler = new JwtSecurityTokenHandler();


        /* the     token. descriptor class has the properties of the suj=bejct; 
        could be of anything,  Expires, Issuer*/
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            // Subject = new ClaimsIdentity(new[]
            // {
            //  new Claim(ClaimTypes.Name, userName)
            //  }),

Subject  = new ClaimsIdentity(claims:  claims),
            Expires = DateTime.UtcNow.AddDays(1),
            Issuer = issuer,
            Audience = audience,


            SigningCredentials = new SigningCredentials(signingKey,
       SecurityAlgorithms.HmacSha256Signature)
        };
        var securityToken = tokenHandler.
       CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(securityToken);
        Log.Information($"{token}");
     
     
     
        return token;
    }







    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        // Get the secret in the configuration
        // Check if the model is valid
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, model.
               Password))
                {
                    var token = GenerateToken(model.UserName,  user);
                    return Ok(new { token });
                }
            }
            // If the user is not found, display an error message
            ModelState.AddModelError("", "Invalid username or password");
        }
        return BadRequest(ModelState);
    }//LOgin functin


} //class