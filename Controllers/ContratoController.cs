using Microsoft.AspNetCore.Mvc;
using SistemaDeVenda.Data;

namespace SistemaDeVenda.Controllers
{
    [ApiExplorerSettings(GroupName = "2 - Contratos")]
    [ApiController]
    [Route("api/[controller]")]
    public class ContratoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContratoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListarContratos()
        {
            var contratos = _context.Contratos.ToList();
            return Ok(contratos);
        }
    }
}
