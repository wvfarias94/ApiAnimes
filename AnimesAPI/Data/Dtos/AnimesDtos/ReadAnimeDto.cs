namespace AnimesAPI.Data.Dtos.AnimesDtos
{
    public class ReadAnimeDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int AnoLancamento { get; set; }
    }
}
