using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TetePizza.Models;

public class Ingrediente
{
    [Key]
    public int IngredienteId { get; set; }

    [Column(TypeName = "NVARCHAR(150)")]
    public string NombreIngrediente { get; set;}
    public string Origen { get; set;}

    [ForeignKey("Pizza")]
    public int PizzaId { get; set; }
    public Pizza Pizza { get; set; }

    public Ingrediente() { }

    public Ingrediente(string nombre, string origen)
    {
        NombreIngrediente = nombre;
        Origen = origen;
    }
}