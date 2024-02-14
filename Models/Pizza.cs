namespace TetePizza.Models;

using System.ComponentModel.DataAnnotations;
using System.Text;

public class Pizza
{
    [Key]
    public int PizzaID { get; set;}

    [Required]
    public string Nombre { get; set; }



    private static int pizzaNumberSeed = 1;

    public List<PizzaIngrediente> PizzaIngredientes { get; set; }





    public Pizza() {}
    public Pizza(string name)
    {
        Nombre = name;
        PizzaID = pizzaNumberSeed;
        pizzaNumberSeed++;
    }



}