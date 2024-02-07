using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Models;

public class Ingrediente
{
    [Key]
    public int TransactionId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set;}
    public DateTime Date { get; set;}
    public string Note { get; set;}

    [ForeignKey("Pizza")]
    public string BankAccountId { get; set; }
    // Propiedad de navegación
    public Pizza Pizza { get; set; }

    // EF Core requiere un constructor sin parámetros
    public Ingrediente() { }

    public Ingrediente(decimal amount, DateTime date, string note)
    {
        Amount = amount;
        Date = date;
        Note = note;
    }
}