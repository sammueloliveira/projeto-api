using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtConfig _jwtConfig;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IOptions<JwtConfig> options)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtConfig = options.Value;
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult> Registrar(RegisterViewModel registerVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var user = new IdentityUser
            {
                UserName = registerVM.Email,
                Email = registerVM.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerVM.Senha);

            if(result.Succeeded)
            {
                
                return Ok(await GerarJwt(registerVM.Email));
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginViewModel LoginVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var result = await _signInManager.PasswordSignInAsync(LoginVM.Email, LoginVM.Senha, false, true);

            if(result.Succeeded)
            {
                return Ok(await GerarJwt(LoginVM.Email));
            }
            if(result.IsLockedOut)
            {
                return BadRequest("Usuário bloqueado. Tente novamente após 30 minutos.");
            }

            return BadRequest("Email e/ou Senha invalidos!");
        }

        private async Task<string> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
               Issuer = _jwtConfig.Issuer,
               Audience = _jwtConfig.Audience,
               Expires = DateTime.UtcNow.AddMinutes(_jwtConfig.ExpirationMinutes),
               SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);


        }
    }
    
}
 