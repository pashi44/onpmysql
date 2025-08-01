
using Xunit;
using Moq;
using Models.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using onpmysql.Controllers;
using System.Threading.Tasks;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;


public class AuthServiceTests
{
    private readonly Mock<IConfiguration> _mockConfig;
    private readonly Mock<UserManager<AppUser>> _mockUserManager;

    public AuthServiceTests()
    {
        _mockConfig = new Mock<IConfiguration>();
        _mockUserManager = new Mock<UserManager<AppUser>>(
            Mock.Of<IUserStore<AppUser>>(), null, null, null, null, null, null, null, null
        );

        _mockConfig.Setup(c => c["JwtConfig:Secret"]).Returns("ThisIsASecretKeyForJwtToken123!");
        _mockConfig.Setup(c => c["JwtConfig:ValidIssuer"]).Returns("yourIssuer");
        _mockConfig.Setup(c => c["JwtConfig:ValidAudiences"]).Returns("yourAudience");

    }

    [Fact]
    public async Task GenerateToken_ValidInputs_ReturnsToken()
    {
        // Arrange
        var user = new AppUser { UserName = "testuser" };
        _mockUserManager.Setup(x => x.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "Admin" });

        // Act
          string  token = null!;

        // Assert
        Assert.NotNull(token);
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        Assert.Equal("testuser", jwtToken.Claims.First(c => c.Type == ClaimTypes.Name).Value);
    }
}