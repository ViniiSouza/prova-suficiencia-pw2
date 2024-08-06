using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgWebII.Modelos;

namespace ProgWebII.Infra.Configuracao
{
    public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Nome).HasMaxLength(100).IsRequired();
        }
    }
}
