using AecTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AeCTest.Infra.Configuration
{
    internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.Usuarios).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.Enderecos).WithOne(x => x.Usuario).HasForeignKey(x => x.UsuarioId);
        }
    }
}
