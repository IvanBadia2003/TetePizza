namespace TetePizza.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

public class PizzaIngrediente
{
    [ForeignKey("Pizza")]
    public int PizzaID { get; set; }
    public Pizza Pizza { get; set; }


    [ForeignKey("Ingrediente")]
    public int IngredienteID { get; set; }
    public Ingrediente Ingrediente { get; set; }



}