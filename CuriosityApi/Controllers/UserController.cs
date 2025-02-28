using CuriosityApi.Configurations;
using CuriosityApi.Models;
using CuriosityApi.Services.Chat;
using Microsoft.AspNetCore.Mvc;

namespace CuriosityApi.Controllers;

[ApiController]
[Route("user")]
public class UserController
(
    IChatService chatService
)
: ControllerBase
{
    [HttpGet("chat")]
    public async Task<IActionResult> GetChats()
    {
        if(User.Id() is null)
            return Unauthorized();
        UserChatsModel? userChatsData = await chatService.GetUserChats((Guid)User.Id());
        return Ok(new {userChatsData});
    }
}