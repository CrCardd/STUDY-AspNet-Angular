using CuriosityApi.Entities;
using CuriosityApi.Services.Chat;
using Microsoft.AspNetCore.Mvc;

namespace CuriosityApi.Controllers;

[ApiController]
[Route("chat")]
public class ChatController
(
    IChatService chatService
)
: ControllerBase
{  
    [HttpPost("(idUserB)")]
    public Task<IActionResult> InitChat
}