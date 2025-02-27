using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CuriosityApi.Configurations;

public static class ConfigurationExtension
{

    public static string GetJWTSecret(this IConfiguration config)
    {
        var key = "JwtSecret";
        var get = config[key]
            ?? throw new Exception($"Missing JWT Secret on 'appsetting'\tkey : {key}");
        return get;
    }

    public static SymmetricSecurityKey GetJWTSecurityKey(this IConfiguration config)
    {
        var secretKey = config.GetJWTSecret();
        var secretBytes = Encoding.UTF8.GetBytes(secretKey);

        return new SymmetricSecurityKey(secretBytes);
    }
}