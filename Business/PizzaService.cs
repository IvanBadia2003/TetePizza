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





        public Pizza GetPizza(int idPizza)
        {
             var id = _repository.GetPizza(idPizza);
             if (id is null) {
                throw new KeyNotFoundException("Pizza not found.");
             }
            
            return id;
        }

         public List<Ingrediente> GetIngredientesByPizza(int idPizza)
        {
            var ingredientes = _repository.GetIngredientesByPizza(idPizza);
            foreach(var ingrediente in ingredientes)
            {
                Console.WriteLine($"este ingrediente {ingrediente.NombreIngrediente} esta en la pizza {ingrediente.Pizza.Nombre}");
            }
            if (ingredientes.Count == 0) 
            {
                    throw new KeyNotFoundException("Ingredients not found.");
            }
            return ingredientes;
        }
    }
}
