using Microsoft.AspNetCore.Mvc;

using TetePizza.Data;
using TetePizza.Models;
using TetePizza.Business;

namespace TetePizza.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    
    private readonly ILogger<PizzaController> _logger;
    private readonly IPizzaService _pizzaService;

    public PizzaController(ILogger<PizzaController> logger, IPizzaService tetePizzaService)
    {
        _logger = logger;
        _pizzaService = tetePizzaService;
    }

    [HttpGet]
        public IActionResult GetPizza()
        {
            var idPizza = 1;
            var pizza = _pizzaService.GetPizza(idPizza);
            _logger.LogError("hack");
            return (pizza is null) ?  NotFound() : Ok(pizza); 

        }

     [HttpGet]
     [Route("Id")]
        public IActionResult GetPizza(int Id)
        {
            var pizza = _pizzaService.GetPizza(Id);
            return (pizza is null) ?  NotFound() : Ok(pizza); 

        }
}
