using CuriosityApi.Configurations;
using CuriosityApi.Services.Cart;
using Microsoft.AspNetCore.Mvc;

namespace CuriosityApi.Controllers;


[Route("cart")]
[ApiController]
public class CartController
(
    ICartService cartService
)
: ControllerBase
{
    [HttpPost("product/(idProduct)")]
    public async Task<IActionResult> AddProduct([FromRoute] Guid idProduct)
    {
        var idUser = User.Id();
        if(idUser is null)
            return Unauthorized();
        await cartService.AddProduct(idProduct, (Guid)idUser);
        return Ok("Product added to the cart!");
    }
}