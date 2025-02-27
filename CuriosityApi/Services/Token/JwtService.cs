using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CuriosityApi.Configurations;
using CuriosityApi.Entities;
using Microsoft.IdentityModel.Tokens;

namespace CuriosityApi.Services.Token;

public class JwtService
(
    ConfigurationManager config
) 
: IJwtService
{
    public string Generate(ApplicationUser user)
    {
        var key = config.GetJWTSecurityKey();

        var jwt = new JwtSecurityToken(
            claims : [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            ],
            expires : DateTime.UtcNow.AddDays(1),
            signingCredentials : new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256Signature
            )
        );
        var handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(jwt);
    }
}
