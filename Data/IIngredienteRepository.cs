using TetePizza.Models;

namespace TetePizza.Data
{
    public interface IIngredienteRepository
    {
        List<Ingrediente> getAll();
        void AddIngrediente(Ingrediente id);
        Ingrediente GetIngrediente(int idIngrediente);
        void UpdateIngrediente(Ingrediente id);
        void SaveChanges();   

    }
}
