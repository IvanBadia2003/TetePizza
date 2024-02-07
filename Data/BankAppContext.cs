using Microsoft.EntityFrameworkCore;
using BankApp.Models;
using Microsoft.Extensions.Configuration;

namespace BankApp.Data
{
    public class BankAppContext : DbContext
    {

        public BankAppContext(DbContextOptions<BankAppContext> options)
            : base(options)
        {

        }

      protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Number = "1234567890", Owner = "John Doe"},
                new Pizza { Number = "0987654321", Owner = "Jane Doe"},
                new Pizza { Number = "09876543274", Owner = "Ivan Badia"}
            );
            modelBuilder.Entity<Ingrediente>().HasData(
                new Ingrediente { TransactionId = 1, Amount = 200.00m, BankAccountId="1234567890", Date = new DateTime(2021,01,01,10,0,0), Note = "Deposito inicial"},
                new Ingrediente { TransactionId = 2, Amount = 300.00m, BankAccountId="1234567890", Date = new DateTime(2021,01,02,11,0,0), Note = "Deposito"},
                new Ingrediente { TransactionId = 3, Amount = -150.00m, BankAccountId="1234567890", Date = new DateTime(2021,01,03,9,30,0), Note = "Retiro"},
                new Ingrediente { TransactionId = 4, Amount = 400.00m, BankAccountId="0987654321", Date = new DateTime(2021,01,04,14,0,0), Note = "Deposito"}
            );
        }

        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }
       
    }
}
