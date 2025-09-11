using System.ComponentModel.DataAnnotations;

namespace Estoque.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = default!;

        public decimal Preco { get; set; }

        public int QuamtidadeEmEstoque { get; set; }
    }
}
