using Microsoft.EntityFrameworkCore;
using YouLearn.Domain.Entities;
using YouLearn.Shared;

namespace YouLearn.Infra.Persistence.EF
{
    public class YouLearnContext : DbContext
    {
        public DbSet<Canal> Canais { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);
        }
        //public DbSet<Favorito> Favoritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //ignorar classes
            //aplicar configuracoes
        }


    }
}
