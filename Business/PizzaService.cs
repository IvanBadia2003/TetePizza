using TetePizza.Data;
using TetePizza.Models;

namespace TetePizza.Business
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _repository;

        public PizzaService(IPizzaRepository repository)
        {
            _repository = repository;
        }



        public List<Pizza> getAll()
        {
            var pizzas = _repository.getAll();

            return pizzas;
        }

        public Pizza GetPizza(int idPizza)
        {
            var id = _repository.GetPizza(idPizza);
            if (id is null)
            {
                throw new KeyNotFoundException("Pizza not found.");
            }

            return id;
        }

        public void AddPizza(Pizza id)
        {
            _repository.AddPizza(id);

        }


       
    }
}
