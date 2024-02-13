namespace TetePizza.Models;

using System.ComponentModel.DataAnnotations;
using System.Text;

public class Pizza
{
    [Key]
    public int? PizzaID { get; set;}

    [Required]
    public string? Nombre { get; set; }

    [Required]
    public string? IsGlutenFree { get; set; }



    private static int pizzaNumberSeed = 1;

    public List<Ingrediente> ingredientes { get; set; } = new List<Ingrediente>();





    public Pizza() {}
    public Pizza(string name, string isGlutenFree)
    {
        Nombre = name;
        PizzaID = pizzaNumberSeed;
        IsGlutenFree = isGlutenFree;
        pizzaNumberSeed++;
    }

    public override string ToString()
    {
        var tostring = $"La pizza {PizzaID} se llama {Nombre} y tiene los siguientes ingredientes {ingredientes}.";
        return tostring;
    }


}