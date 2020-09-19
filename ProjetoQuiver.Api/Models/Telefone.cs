using System.ComponentModel.DataAnnotations;

namespace ProjetoQuiver.Api.Models
{
    public class Telefone
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(15, ErrorMessage = "Digite o DDD + Numero do telefone. Ex: (012)98888-7777")]
        [MaxLength(15, ErrorMessage = "Digite o DDD + Numero do telefone. Ex: (012)98888-7777")]
        public string Numero { get; set; }

        public Contato Contato { get; set; }
    }
}