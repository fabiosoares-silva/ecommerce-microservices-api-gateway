using Estoque.Data;
using Estoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly EstoqueDbContext _context;

        public EstoqueController(EstoqueDbContext context)
        {
            _context = context;
        }

        [HttpPost("Produtos")]
        public async Task<IActionResult> AdicionarProduto(Produto produto)
        {
           _context.Produtos.Add(produto);
           await _context.SaveChangesAsync();

           return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        [HttpPut("Produtos/{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }
            
            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpGet("Produtos/{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        [HttpPost("Validar")]
        public async Task<ActionResult<bool>> ValidarEstoque([FromBody] ValidarEstoqueRequest request)
        {
            var produto = await _context.Produtos.FindAsync(request.ProdutoId);

            if (produto == null)
            {
                return false;
            }

            return produto.QuantidadeEmEstoque >= request.QuantidadeDesejada;
        }

        public record ValidarEstoqueRequest(int ProdutoId, int QuantidadeDesejada);

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}   