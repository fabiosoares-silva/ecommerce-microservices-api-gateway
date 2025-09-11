using System.ComponentModel.DataAnnotations;

namespace Vendas.Dtos
{
    public class PedidoDto
    {
        [Required]
        public int ProdutoId { get; set; }
        [Required]
        public int Quantidade { get; set; }
    }
}
