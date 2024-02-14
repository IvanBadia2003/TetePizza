
using TetePizza.Models;

namespace TetePizza.Business
{
    public interface IPizzaService
    {

        public List<Pizza> getAll();
        public Pizza GetPizza(int idPizza);
        public void AddPizza(Pizza id);


    }
}
