using CuriosityApi.Entities;
using CuriosityApi.Services.Chat;
using CuriosityApi.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace CuriosityApi.Controllers;

[ApiController]
[Route("chat")]
public class ChatController
(
    IChatService chatService,
    IProductService productService
)
: ControllerBase
{  
    [HttpPost("(idProduct)")]
    public Task<IActionResult> InitChat([FromRoute] Guid idProduct)
    {
        var idUserB = productService.GetOwner()
    }
}