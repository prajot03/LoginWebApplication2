using ApplicationLayer;
using ApplicationLayer.DTO;
using DomainLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginWebApplication.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController(IProductService productService) : Controller
    {


        [HttpPost("Add Product")]
        public async Task<IActionResult> AddProduct(AddProductRequest prod)
        {

            var s = await productService.AddProduct(prod);
            return Ok(s);

        }


        [HttpGet("Get_All_Products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var s = await productService.GetProducts();
            return Ok(s);
        }


    }
}
