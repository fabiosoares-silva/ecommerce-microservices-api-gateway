using Microsoft.AspNetCore.Mvc;
using Vendas.Data;
using Vendas.Dtos;
using Vendas.Models;
using Vendas.Services;

namespace Vendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly PedidosDbContext _context;
        private readonly EstoqueService _estoqueService;

        public PedidosController(PedidosDbContext context, EstoqueService estoqueService)
        {
            _context = context;
            _estoqueService = estoqueService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] PedidoDto pedidoDto)
        {
            // Verificar estoque antes de criar o pedido
            bool temEstoqueDisponivel = await _estoqueService.VerificarEstoque(pedidoDto.ProdutoId, pedidoDto.Quantidade);
            if (!temEstoqueDisponivel)
            {
                return BadRequest("Estoque insuficiente para o produto solicitado.");
            }
            var pedido = new Pedido
            {
                ProdutoId = pedidoDto.ProdutoId,
                Quantidade = pedidoDto.Quantidade,
                DataPedido = DateTime.UtcNow
            };

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ConsultarPedido), new { id = pedido.Id }, pedido);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }
    }
}
