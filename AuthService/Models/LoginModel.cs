using System.ComponentModel.DataAnnotations;

namespace AuthService.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string? Password { get; set; }
    }
}
