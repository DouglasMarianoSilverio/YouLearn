using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;

namespace YouLearn.Infra.Persistence.EF.Map
{
    public class MapPlaylist : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable("PlayList");
            //Foreign Key
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey("IdUsuario");

            //Propiedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
        }
    }
}
