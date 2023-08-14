using AnimesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimesAPI.Data
{
    public class AnimesDbContext : DbContext
    {     
            public AnimesDbContext(DbContextOptions<AnimesDbContext> opts)
                : base(opts)
            {

            }

            public DbSet<Anime> Animes { get; set; }
            public DbSet<Personagem> Personagens { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Personagem>()
                    .HasOne(personagem => personagem.Animes)
                    .WithMany(anime => anime.Personagens)
                    .HasForeignKey(Personagem => Personagem.AnimeId);
            }
    }
}
