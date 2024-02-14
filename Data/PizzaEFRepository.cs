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

        public List<Pizza> getAll()
        {

            return _context.Pizza.ToList();
            // var pizzas = _context.Pizza
            //         .Include(p => p.PizzaIngredientes)
            //             .ThenInclude(pi => pi.Ingrediente)
            //         .ToList();

            // var pizzasDto = pizzas.Select(p => new PizzaDTO
            // {
            //     PizzaId = p.PizzaID,
            //     Nombre = p.Nombre,
            //     Ingredientes = p.PizzaIngredientes.Select(pi => new IngredienteDTO
            //     {
            //         IngredienteId = pi.Ingrediente.IngredienteId,
            //         Nombre = pi.Ingrediente.NombreIngrediente
            //     }).ToList()
            // }).ToList();

            // return pizzasDto;
        }

        public void AddPizza(Pizza id)
        {
            _context.Pizza.Add(id);
            SaveChanges();
        }

        public Pizza GetPizza(int idPizza)
        {
            return _context.Pizza.FirstOrDefault(id => id.PizzaID == idPizza);
        }

        public void UpdatePizza(Pizza id)
        {
            _context.Entry(id).State = EntityState.Modified;
        }

        public void RemovePizza(int idPizza)
        {
            var pizza = GetPizza(idPizza);
            if (pizza is null)
            {
                throw new KeyNotFoundException("Pizza not found.");
            }
            _context.Pizza.Remove(pizza);
            SaveChanges();

        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }
}