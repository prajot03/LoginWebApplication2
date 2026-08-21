using ApplicationLayer;
using ApplicationLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginWebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserService userService;
        public AccountController(IUserService service) => userService = service;

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDTO userRegister)

        {

            var s =await userService.RegisterAsync(userRegister);

            return Ok(s);
        }
        
    }
}
