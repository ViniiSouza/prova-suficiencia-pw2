using Microsoft.EntityFrameworkCore;
using ProgWebII.Modelos;

namespace ProgWebII.Infra
{
    public class ContextoBanco : DbContext
    {
        public virtual DbSet<Comanda> Comandas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<ProdutoComanda> ProdutosComanda { get; set; }


        public ContextoBanco(DbContextOptions<ContextoBanco> options) : base(options) { }
    }
}
