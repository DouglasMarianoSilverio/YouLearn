using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using YouLearn.Domain.Entities;
using YouLearn.Domain.ValueObjects;
using YouLearn.Infra.Persistence.EF.Map;
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
            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Email>();
            modelBuilder.Ignore<Nome>();

            //aplicar configuracoes
            modelBuilder.ApplyConfiguration(new MapCanal());
            modelBuilder.ApplyConfiguration(new MapPlaylist());
            modelBuilder.ApplyConfiguration(new MapVideo());
            modelBuilder.ApplyConfiguration(new MapUsuario());
            //modelBuilder.ApplyConfiguration(new MapFavorito());

            base.OnModelCreating(modelBuilder);
        }


    }
}
