using WebApi.Models;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Token;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public TokenController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] InputModel Input)
        {
            if (string.IsNullOrWhiteSpace(Input.Email) || string.IsNullOrWhiteSpace(Input.Password))
            {
                return Unauthorized();
            }

            var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                try
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var role = roles.FirstOrDefault();
                    if (role != null)
                    {
                        var token = new TokenJWTBuilder()
                            .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                            .AddSubject(user.Id)
                            .AddIssuer("BJ.Securiry.Bearer")
                            .AddAudience("FrontBJ.Securiry.Bearer")
                            .AddClaim("usuario", user.UserName)
                            .AddClaim("role", role)
                            .AddExpiry(50)
                            .Builder();

                        return Ok(token.value);
                    }
                    else
                    {
                        throw new ArgumentException("Erro no usuário, entrar em contato pelo e-mail.");
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.ToString());
                }
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
