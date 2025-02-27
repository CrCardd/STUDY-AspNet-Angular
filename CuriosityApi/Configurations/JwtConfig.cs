using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CuriosityApi.Configurations;

public static class JwtConfig
{
    public static IServiceCollection AddJWTAuthentication(this IServiceCollection service, IConfiguration config)
    {
        service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidIssuer =  "curiosity",
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = config.GetJWTSecurityKey()
            };
        });
        service.AddAuthorization();
        return service;
    }
}