using Microsoft.AspNetCore.Mvc;
using SistemaDeVenda.Data;

namespace SistemaDeVenda.Controllers
{
    [ApiExplorerSettings(GroupName = "3 - Faturas")]
    [ApiController]
    [Route("api/[controller]")]
    public class FaturaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FaturaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListarFaturas()
        {
            var faturas = _context.Faturas.ToList();
            return Ok(faturas);
        }
    }
}