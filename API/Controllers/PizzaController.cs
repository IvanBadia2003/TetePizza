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
    public ActionResult<List<Pizza>> getAll()
    {
        var pizzas = _pizzaService.getAll();
        return pizzas;


    }

    [HttpGet]
    [Route("Id")]
    public ActionResult<Pizza> GetPizza(int Id)
    {
        var pizza = _pizzaService.GetPizza(Id);
        return (pizza is null) ? NotFound() : Ok(pizza);

    }

    [HttpPost]
    public ActionResult AddPizza(Pizza pizza)
    {
        _pizzaService.AddPizza(pizza);
        return CreatedAtAction(nameof(GetPizza), new {id = pizza.PizzaID }, pizza);



    }
}
