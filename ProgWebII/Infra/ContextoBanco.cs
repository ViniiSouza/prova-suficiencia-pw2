using Microsoft.EntityFrameworkCore;
using ProgWebII.Modelos;

namespace ProgWebII.Infra
{
    public class ContextoBanco : DbContext
    {
        public virtual DbSet<Comanda> Comandas { get; set; }

        public ContextoBanco(DbContextOptions<ContextoBanco> options) : base(options) { }
    }
}
