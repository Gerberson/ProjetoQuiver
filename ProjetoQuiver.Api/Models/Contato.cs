using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoQuiver.Api.Models
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(3, ErrorMessage = "O {0} deve conter no mínimo {1} caracteres.")]
        [MaxLength(15, ErrorMessage = "O {0} deve conter no maximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(3, ErrorMessage = "O {0} deve conter no mínimo {1} caracteres.")]
        [MaxLength(15, ErrorMessage = "O {0} deve conter no maximo {1} caracteres.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido.")]
        public string Email { get; set; }

        public Corretora Corretora { get; set; }

        public List<Telefone> Telefones { get; set; }
    }
}