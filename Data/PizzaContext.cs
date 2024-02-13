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
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { PizzaID = 1, Nombre = "Carbonara", IsGlutenFree = "Yes" },
                new Pizza { PizzaID = 2, Nombre = "Barbacoa", IsGlutenFree = "Yes" },
                new Pizza { PizzaID = 3, Nombre = "Hawaina", IsGlutenFree = "No" }
            );
            modelBuilder.Entity<Ingrediente>().HasData(
                new Ingrediente { IngredienteId = 1, NombreIngrediente = "Champiñon", PizzaId = 1, Origen = "Vegetal" },
                new Ingrediente { IngredienteId = 2, NombreIngrediente = "Oliva", PizzaId = 2, Origen = "Vegetal" },
                new Ingrediente { IngredienteId = 3, NombreIngrediente = "Piña", PizzaId = 1, Origen = "Vegetal" },
                new Ingrediente { IngredienteId = 4, NombreIngrediente = "Pollo", PizzaId = 2, Origen = "Animal" }
            );
        }

        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }

    }
}
