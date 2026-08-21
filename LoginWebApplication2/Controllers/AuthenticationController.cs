using ApplicationLayer;
using ApplicationLayer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LoginWebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private IAuthenticateUserService _userService;

        public AuthenticationController(IAuthenticateUserService user)
        { 
            _userService = user;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> ValidateUser(ValidateUserLoginRequest user)
        {
          var result= await _userService.AuthenticateAsync(user.username, user.password);
            if (!result.IsSuccess)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(result.value);
            }
        }
    }
}
