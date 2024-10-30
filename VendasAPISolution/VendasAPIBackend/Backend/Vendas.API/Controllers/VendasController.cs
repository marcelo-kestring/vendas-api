using Microsoft.AspNetCore.Mvc;
using Vendas.Dominio.Entities;
using Vendas.Dominio.Services;

namespace VendasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendasController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterVendas()
        {
            var vendas = await _vendaService.ObterTodasVendasAsync();
            return Ok(vendas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterVenda(int id)
        {
            var venda = await _vendaService.ObterVendaPorIdAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            return Ok(venda);
        }

        [HttpPost]
        public async Task<IActionResult> CriarVenda([FromBody] Venda venda)
        {
            await _vendaService.CriarVendaAsync(venda);
            return CreatedAtAction(nameof(ObterVenda), new { id = venda.Id }, venda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarVenda(int id, [FromBody] Venda venda)
        {
            if (id != venda.Id)
            {
                return BadRequest();
            }

            await _vendaService.AtualizarVendaAsync(venda);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarVenda(int id)
        {
            await _vendaService.DeletarVendaAsync(id);
            return NoContent();
        }
    }
}