using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouLearn.Domain.Entities;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Infra.Persistence.EF.Map
{
    public class MapUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            //pk
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Senha).HasMaxLength(36).IsRequired();

            //mapeando objetos de valor ( complexos)
            builder.OwnsOne<Nome>(x => x.Nome, cb =>
            {
                cb.Property(x => x.PrimeiroNome).HasMaxLength(50).HasColumnName("PrimeiroNome").IsRequired();
                cb.Property(x => x.UltimoNome).HasMaxLength(50).HasColumnName("UltinoNome").IsRequired();
            });

            builder.OwnsOne<Email>(x => x.Email, cb =>
            {
                cb.Property(x => x.Endereco).HasMaxLength(200).HasColumnName("Email").IsRequired();
            });
        }
    }
}
