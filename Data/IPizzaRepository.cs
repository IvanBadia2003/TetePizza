using TetePizza.Models;

namespace TetePizza.Data
{
    public interface IPizzaRepository
    {
        void AddPizza(Pizza id);
        Pizza GetPizza(int idPizza);
        void UpdatePizza(Pizza id);
        void SaveChanges();   

        List<Ingrediente> GetIngredientesByPizza(int idPizza);

    }
}
