using ApplicationLayer;
using ApplicationLayer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LoginWebApplication2.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RoleController(IRolesService roleService,ILogger<RoleController> logger) : ControllerBase
    {

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(RoleAddRequest request) 
        {

          var x= await roleService.AddRole(request);
            if (x != null)
            {
                logger.LogDebug("Role Added: "+request.RoleName);
                return Ok(x);
            }
            else
            {
                logger.LogDebug("Role Already Exists");
                return Conflict("Role Already Exists");
            }
        }
    }
}
