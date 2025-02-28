using CuriosityApi.Configurations;
using CuriosityApi.Entities;
using CuriosityApi.Models;
using CuriosityApi.Services.Chat;
using CuriosityApi.Services.Product;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public async Task<IActionResult> InitChat([FromRoute] Guid idProduct)
    {
        var idUserA = User.Id();
        var userB = await productService.GetOwner(idProduct);
        var idUserB = userB?.Id;
        if(idUserA is null || idUserB is null) 
            return Unauthorized();

        var _ = await chatService.Create(new ChatModel ((Guid)idUserA, (Guid)idUserB, idProduct));
        if(_ is null)   
            return BadRequest("Some of the id's are invalid");
            // return StatusCode(213123);

        return Ok("Chat created succesfully!");
    }
    
}