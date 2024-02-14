using TetePizza.Models;

namespace TetePizza.Data
{
    public interface IPizzaRepository
    {
        List<Pizza> getAll();
        void AddPizza(Pizza id);
        Pizza GetPizza(int idPizza);
        void UpdatePizza(Pizza id);
        void SaveChanges();   

    }
}
