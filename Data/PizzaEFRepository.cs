using TetePizza.Models;
using Microsoft.EntityFrameworkCore;

namespace TetePizza.Data
{
    public class PizzaEFRepository : IPizzaRepository
    {
        private readonly PizzaContext _context;

        public PizzaEFRepository(PizzaContext context)
        {
            _context = context;
        }

        public void AddPizza(Pizza id)
        {
            _context.Pizza.Add(id);
        }

        public Pizza GetPizza(int idPizza)
        {
            return _context.Pizza.FirstOrDefault(id => id.PizzaID == idPizza);
        }

        public void UpdatePizza(Pizza id)
        {
            _context.Entry(id).State = EntityState.Modified;
        }

        public void RemovePizza(int idPizza) {
            var pizza = GetPizza(idPizza);
            if (pizza is null) {
                throw new KeyNotFoundException("Pizza not found.");
            }
            _context.Pizza.Remove(pizza);
            SaveChanges();

        }
        

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


        public void GetIngredientesFromPizza(int idPizza) {
            var ingredientes = _context.Ingrediente
                                .Where(t => t.PizzaId == idPizza)
                                .Include(t => t.Pizza) 
                                .ToList();

            foreach(var ingrediente in ingredientes)
            {
                Console.WriteLine($"este ingrediente {ingrediente.NombreIngrediente} esta en la pizza {ingrediente.Pizza.Nombre}");
            }

        }

        public List<Ingrediente> GetIngredientesByPizza(int idPizza)
        {
            return _context.Ingrediente
                                .Where(t => t.PizzaId == idPizza)
                                .Include(t => t.Pizza)
                                .ToList();
        }
    }   
}