
using TetePizza.Models;

namespace TetePizza.Business
{
    public interface IIngredienteService
    {

        public List<Ingrediente> getAll();
        public Ingrediente GetIngrediente(int idIngrediente);

    }
}
