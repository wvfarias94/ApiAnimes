using System.ComponentModel.DataAnnotations;

namespace AnimesAPI.Data.Dtos.PersonagensDtos
{
    public class UpdatePersonagemDto
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}
