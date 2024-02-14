using TetePizza.Data;
using TetePizza.Models;

namespace TetePizza.Business
{
    public class IngredienteService : IIngredienteService
    {
        private readonly IIngredienteRepository _repository;

        public IngredienteService(IIngredienteRepository repository)
        {
            _repository = repository;
        }



        public List<Ingrediente> getAll(){
            var pizzas = _repository.getAll();

            return pizzas;
        }

        public Ingrediente GetIngrediente(int idIngrediente)
        {
             var id = _repository.GetIngrediente(idIngrediente);
             if (id is null) {
                throw new KeyNotFoundException("Pizza not found.");
             }
            
            return id;
        }

    }
}
