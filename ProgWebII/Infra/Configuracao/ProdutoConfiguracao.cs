using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgWebII.Modelos;

namespace ProgWebII.Infra.Configuracao
{
    public class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prop => prop.Preco)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
