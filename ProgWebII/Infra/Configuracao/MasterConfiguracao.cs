using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProgWebII.Modelos;

namespace ProgWebII.Infra.Configuracao
{
    public class MasterConfiguracao : IEntityTypeConfiguration<Master>
    {
        public void Configure(EntityTypeBuilder<Master> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Login).HasMaxLength(100).IsRequired();
            builder.Property(prop => prop.Senha).IsRequired();
        }
    }
}
