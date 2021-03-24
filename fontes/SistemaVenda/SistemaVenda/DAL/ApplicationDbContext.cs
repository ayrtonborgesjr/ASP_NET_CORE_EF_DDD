using SistemaVenda.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SistemaVenda.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaProdutos> VendaProdutos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Produto>().ToTable("Produto");
            builder.Entity<Usuario>().ToTable("Usuario");
            builder.Entity<Cliente>().ToTable("Cliente");
            builder.Entity<Venda>().ToTable("Venda");

            builder.Entity<VendaProdutos>().HasKey(x => new { x.CodigoVenda, x.CodigoProduto });

            builder.Entity<VendaProdutos>()
                .ToTable("VendaProdutos")
                .HasOne(x => x.Venda)
                .WithMany(y => y.Produtos)
                .HasForeignKey(x => x.CodigoVenda);

            builder.Entity<VendaProdutos>()
                .HasOne(x => x.Produto)
                .WithMany(y => y.Vendas)
                .HasForeignKey(x => x.CodigoProduto);
        }
    }
}
