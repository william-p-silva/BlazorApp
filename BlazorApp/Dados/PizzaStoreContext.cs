using BlazorApp.Model;
using Microsoft.EntityFrameworkCore;


namespace BlazorApp.Dados
{
    public class PizzaStoreContext : DbContext
    {
        public PizzaStoreContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ModeloPizza> Pizzas { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.Pizzas);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.EnderecoEntrega);
        }
    }
}
