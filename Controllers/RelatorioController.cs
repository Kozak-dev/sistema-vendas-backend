using Microsoft.AspNetCore.Mvc;
using SistemaDeVenda.Services;

namespace SistemaDeVenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "4 - Relatorio")]
    public class RelatorioController : ControllerBase
    {
        private readonly VendaService _service;

        public RelatorioController(VendaService service)
        {
            _service = service;
        }

        [HttpGet("total-vendas")]
        public IActionResult TotalVendas()
        {
            var total = _service.TotalVendas();
            return Ok(new { total });
        }

        [HttpGet("quantidade-vendas")]
        public IActionResult QuantidadeVendas()
        {
            var quantidade = _service.QuantidadeVendas();
            return Ok(new { quantidade });
        }
    }
}