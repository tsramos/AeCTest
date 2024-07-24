using AecTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AeCTest.Infra.Configuration
{
    internal class EnderecosConfiguration : IEntityTypeConfiguration<Enderecos>
    {
        public void Configure(EntityTypeBuilder<Enderecos> builder)
        {
            builder.Property(a => a.Cep).IsRequired();
            builder.Property(a => a.Logradouro).IsRequired();
            builder.Property(a => a.Bairro).IsRequired();
            builder.Property(a => a.Cidade).IsRequired();
            builder.Property(a => a.Uf).IsRequired();
            builder.Property(a => a.Numero).IsRequired();
        }
    }
}
