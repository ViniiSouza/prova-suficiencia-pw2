using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgWebII.Modelos;

namespace ProgWebII.Infra.Configuracao
{
    public class ComandaConfiguracao : IEntityTypeConfiguration<Comanda>
    {
        public void Configure(EntityTypeBuilder<Comanda> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.HasOne(prop => prop.Usuario)
                .WithMany(prop => prop.Comandas)
                .HasForeignKey(prop => prop.UsuarioId)
                .IsRequired();
        }
    }
}
