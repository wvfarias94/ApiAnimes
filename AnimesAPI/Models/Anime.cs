using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace AnimesAPI.Models
{
    public class Anime
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessario cadastrar um nome para o Anime!!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessario passar uma descrição para cadastrar um Anime!!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "É necessario informar um ano de lançamento Anime!!")]
        public int AnoLancamento { get; set; }
        public ICollection <Personagem> Personagens { get; set; }
    }
}




