using System.ComponentModel.DataAnnotations;

namespace SistemaDeVenda.Models
{
    public class Usuario
    {
        [Key]

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty; 

        public string Role { get; set; } = string.Empty; 
    }
}
