using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaDeVenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "1 - Vendas")]
    public class AuthController : ControllerBase
    {
        private readonly string key = "MINHA_CHAVE_SECRETA_SUPER_SEGURA_123456789";

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Usuario != "admin" || request.Senha != "12345")
            {
                return Unauthorized(new { mensagem = "Usuário ou senha inválidos" });
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.Usuario)
            };

            var keyBytes = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(keyBytes, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenString });
        }

        public class LoginRequest
        {
            public string Usuario { get; set; }
            public string Senha { get; set; }
        }
    }
}