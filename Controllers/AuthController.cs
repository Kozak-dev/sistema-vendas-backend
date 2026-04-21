using Microsoft.AspNetCore.Mvc;
using SistemaDeVenda.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;

namespace SistemaDeVenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "5 - Auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly string _key = "MINHA_CHAVE_SECRETA_SUPER_SEGURA_123456789";

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Email == request.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Senha, usuario.Senha))
                return Unauthorized(new { mensagem = "Email ou senha inválidos" });

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome ?? string.Empty),
                new Claim(ClaimTypes.Role, usuario.Role ?? string.Empty)
            };

            var keyBytes = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var creds = new SigningCredentials(keyBytes, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "SistemaDeVenda",
                audience: "SistemaDeVenda",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = tokenString });
        }
        [HttpGet("gerar-hash/{senha}")]
        public IActionResult GerarHash(string senha)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(senha);
            var confere = BCrypt.Net.BCrypt.Verify(senha, hash);
            return Ok(new { senha, hash, confere, tamanho = hash.Length });
        }

        public class LoginRequest
        {
            public string Email { get; set; } = string.Empty;
            public string Senha { get; set; } = string.Empty;
        }
    }
}