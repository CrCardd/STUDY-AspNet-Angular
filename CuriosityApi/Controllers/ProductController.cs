using CuriosityApi.Configurations;
using CuriosityApi.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace CuriosityApi.Controllers;

[ApiController]
[Route("product")]
public class ProductController
(
    IProductService productService
)
: ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return BadRequest();
    }

    [HttpGet("")]
    public IActionResult GetUserProducts()
    {   
        if(User.Id() is null)
            return BadRequest();
            
        var userProducts = productService.FindByUserId((Guid)User.Id());
        return Ok(new {userProducts});
    }
}