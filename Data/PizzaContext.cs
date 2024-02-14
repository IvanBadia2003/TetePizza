using Microsoft.EntityFrameworkCore;
using TetePizza.Models;
using Microsoft.Extensions.Configuration;

namespace TetePizza.Data
{
    public class PizzaContext : DbContext
    {

        public PizzaContext(DbContextOptions<PizzaContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PizzaIngrediente>()
    .HasKey(pi => new { pi.PizzaID, pi.IngredienteID });

            modelBuilder.Entity<PizzaIngrediente>()
                .HasOne(pi => pi.Pizza)
                .WithMany(p => p.PizzaIngredientes)
                .HasForeignKey(pi => pi.PizzaID);

            modelBuilder.Entity<PizzaIngrediente>()
                .HasOne(pi => pi.Ingrediente)
                .WithMany(i => i.PizzaIngredientes)
                .HasForeignKey(pi => pi.IngredienteID);

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { PizzaID = 1, Nombre = "Hawaiana"},
                new Pizza { PizzaID = 2, Nombre = "Barbacoa"}
            );

            modelBuilder.Entity<Ingrediente>().HasData(
                new Ingrediente { IngredienteId = 1, NombreIngrediente = "Piña" , Origen ="Vegetal"},
                new Ingrediente { IngredienteId = 2, NombreIngrediente = "Jamón york", Origen ="Animal"},
                new Ingrediente { IngredienteId = 3, NombreIngrediente = "Carne picada", Origen ="Animal"}
            );

            modelBuilder.Entity<PizzaIngrediente>().HasData(
                new PizzaIngrediente { PizzaID = 1, IngredienteID = 1 },
                new PizzaIngrediente { PizzaID = 1, IngredienteID = 2 },
                new PizzaIngrediente { PizzaID = 2, IngredienteID = 3 }
            );
        }

        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }
        public DbSet<PizzaIngrediente> PizzaIngrediente { get; set; }


    }
}
