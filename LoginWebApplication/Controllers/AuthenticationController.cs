using ApplicationLayer;
using ApplicationLayer.DTO;
using DomainLayer;
using Microsoft.AspNetCore.Mvc;

namespace LoginWebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private IAuthenticateUserService _userService;
        private IJwtTokenService _jwtTokenService;
        private IConfiguration configuration;
        ILogger<AuthenticationController> logger;

        public AuthenticationController(IAuthenticateUserService user, IJwtTokenService token, IConfiguration config, ILogger<AuthenticationController> log)
        { 
            _userService = user;
            _jwtTokenService = token;
            configuration = config;
            logger = log;

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
                var token = _jwtTokenService.GenerateToken(result.value);

                //var response = new TokenResponse
                //{
                //    Token = token,
                //    ExpiresAtUtc = DateTime.UtcNow.AddMinutes(int.Parse(HttpContext.RequestServices
                //        .GetService<Microsoft.Extensions.Configuration.IConfiguration>()["JwtSettings:DurationMinutes"] ?? "60")),
                //Roles = result.value.Roles?.Select(r => r.RoleType).ToList()
                //};

                return Ok(token);
            }
        }
    }
}
