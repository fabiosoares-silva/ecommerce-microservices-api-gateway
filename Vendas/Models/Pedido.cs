using System.ComponentModel.DataAnnotations;

namespace Vendas.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public DateTime DataPedido { get; set; }
    }
}
