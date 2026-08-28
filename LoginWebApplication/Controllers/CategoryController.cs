using ApplicationLayer;
using ApplicationLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginWebApplication2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoryController(ICategoryService category) : Controller
    {
        [Authorize(Roles = "ADMIN")]
        [HttpPost("Add_Category")]
        public async Task<IActionResult> AddCategory(List<AddCategoryRequest> request)
        {
            var s = await category.AddCategory(request);
            return Ok(s);
        }

        [HttpGet("Get_Category")]
        public async Task<IActionResult> GetCategory()
        {
            {
                var s = await category.GetCategory();
                return Ok(s);
            }
        }
    }
}
