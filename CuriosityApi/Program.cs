using CuriosityApi.Configurations;
using CuriosityApi.Entities;
using CuriosityApi.Services.Auth;
using CuriosityApi.Services.Password;
using CuriosityApi.Services.Token;
using CuriosityApi.Services.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MainPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:") // URL DO FRONT
            .WithHeaders("**")
            .WithMethods("**");
    });
});

builder.Services
    .AddJWTAuthentication(builder.Configuration)
    .AddDbContext<CuriosityDbContext>(Options => {
        Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services
    .AddSingleton<IJwtService, JwtService>()
    .AddSingleton(builder.Configuration)
    .AddSingleton<IPasswordService, PasswordService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IAuthService, AuthService>();


builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
