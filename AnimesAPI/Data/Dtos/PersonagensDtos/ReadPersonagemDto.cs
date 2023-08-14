using AnimesAPI.Models;


namespace AnimesAPI.Data.Dtos.PersonagensDtos
{
    public class ReadPersonagemDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<Personagem> Personagens { get; set; }
    }
}
