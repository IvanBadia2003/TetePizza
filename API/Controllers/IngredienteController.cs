using Microsoft.AspNetCore.Mvc;

using TetePizza.Data;
using TetePizza.Models;
using TetePizza.Business;

namespace TetePizza.API.Controllers;

[ApiController]
[Route("[controller]")]
public class IngredienteController : ControllerBase
{
    
    private readonly ILogger<IngredienteController> _logger;
    private readonly IIngredienteService _ingredienteService;

    public IngredienteController(ILogger<IngredienteController> logger, IIngredienteService ingredienteService)
    {
        _logger = logger;
        _ingredienteService = ingredienteService;
    }

    [HttpGet]
        public ActionResult <List<Ingrediente>> getAll()
        {
            var pizzas = _ingredienteService.getAll();
            return pizzas;


        }

     [HttpGet]
     [Route("Id")]
        public ActionResult<Ingrediente> GetIngrediente(int Id)
        {
            var pizza = _ingredienteService.GetIngrediente(Id);
            return (pizza is null) ?  NotFound() : Ok(pizza); 

        }
}
