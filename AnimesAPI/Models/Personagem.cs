using System.ComponentModel.DataAnnotations;

namespace AnimesAPI.Models
{
    public class Personagem
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessario cadastrar um nome para o Personagem!!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessario passar uma descrição para o Personagem!!")]
        public string Descricao { get; set; }
        public int AnimeId { get; set; }
        public Anime Animes { get; set; }
    }
}

