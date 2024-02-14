using TetePizza.Models;
using Microsoft.EntityFrameworkCore;

namespace TetePizza.Data
{
    public class IngredienteEFRepository : IIngredienteRepository
    {
        private readonly PizzaContext _context;

        public IngredienteEFRepository(PizzaContext context)
        {
            _context = context;
        }

        public List<Ingrediente> getAll() {
            List<Ingrediente> ingredientes = new List<Ingrediente>();



            return ingredientes;
        }

        public void AddIngrediente(Ingrediente id)
        {
            _context.Ingrediente.Add(id);
        }

        public Ingrediente GetIngrediente(int idIngrediente)
        {
            return _context.Ingrediente.FirstOrDefault(id => id.IngredienteId == idIngrediente);
        }

        public void UpdateIngrediente(Ingrediente id)
        {
            _context.Entry(id).State = EntityState.Modified;
        }

        public void RemoveIngrediente(int idIngrediente) {
            var ingrediente = GetIngrediente(idIngrediente);
            if (ingrediente is null) {
                throw new KeyNotFoundException("Ingrediente not found.");
            }
            _context.Ingrediente.Remove(ingrediente);
            SaveChanges();

        }
        

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }   
}