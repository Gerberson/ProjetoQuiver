using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoQuiver.Api.Models
{
    public class Corretora
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(3, ErrorMessage = "O {0} deve conter no mínimo {1} caracteres.")]
        [MaxLength(15, ErrorMessage = "O {0} deve conter no maximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(6, ErrorMessage = "O {0} deve conter no mínimo {1} caracteres.")]
        [MaxLength(15, ErrorMessage = "O {0} deve conter no maximo {1} caracteres.")]
        public string Password { get; set; }

        public string Role{ get; set; }

        public List<Contato> Contatos { get; set; }
    }
}
