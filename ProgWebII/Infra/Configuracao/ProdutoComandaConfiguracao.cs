using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgWebII.Modelos;

namespace ProgWebII.Infra.Configuracao
{
    public class ProdutoComandaConfiguracao : IEntityTypeConfiguration<ProdutoComanda>
    {
        public void Configure(EntityTypeBuilder<ProdutoComanda> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.HasOne(prop => prop.Produto)
                .WithMany(prop => prop.ProdutosComanda)
                .HasForeignKey(prop => prop.ProdutoId)
                .IsRequired();

            builder.HasOne(prop => prop.Comanda)
                .WithMany(prop => prop.ProdutosComanda)
                .HasForeignKey(prop => prop.ComandaId)
                .IsRequired();
        }
    }
}
