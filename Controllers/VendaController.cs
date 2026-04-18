using Microsoft.AspNetCore.Mvc;
using SistemaDeVenda.Models;
using SistemaDeVenda.Services;
namespace SistemaDeVenda.Controllers
{
    [ApiExplorerSettings(GroupName = "1 - Vendas")]
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly VendaService _service;

        public VendaController(VendaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CriarVenda([FromBody] Venda venda)
        {
            if (venda == null)
                return BadRequest("Dados inválidos");
            if (string.IsNullOrEmpty(venda.Cliente))
                return BadRequest("Cliente é obrigatório");

            _service.CriarVenda(venda);

            return Ok(new { mensagem = "Venda criada com sucesso" });
        }
        [HttpGet]
        public IActionResult ListarVendas()
        {
            var vendas = _service.ListarVendas();
            return Ok(vendas);
        }
    }
}