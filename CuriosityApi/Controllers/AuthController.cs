using CuriosityApi.Services.Auth;
using CuriosityApi.Services.Token;
using Microsoft.AspNetCore.Mvc;

namespace CuriosityApi.Controllers;

[Route("auth")]
[ApiController]
public class AuthController
(
    IAuthService authService,
    IJwtService jwtService
)
: ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] AccountModel data)
    {
        await authService.CreateUser(data);
        return Ok("User registered!");
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginModel data)
    {
        var user = await authService.Authenticate(data);
        if(user is null)
            return Unauthorized();
            
        return Ok(new { token = jwtService.Generate(user)});
    }

}

