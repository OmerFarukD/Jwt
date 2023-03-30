using Jwt.Business.Abstract;
using Jwt.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto loginDto)
        {
            var loginToUser = _authService.Login(loginDto);
            if (!loginToUser.Success)
            {
                return BadRequest(loginToUser.Message);
            }
            var result = _authService.CreateToken(loginToUser.Data);
            return Ok(result);
        }
        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var user = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            if (!user.Success)
            {
                return BadRequest(user.Message);
            }
            return Ok(_authService.CreateToken(user.Data));
        }
    }
}
