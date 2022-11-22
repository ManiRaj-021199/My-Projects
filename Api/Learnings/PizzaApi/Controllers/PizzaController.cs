using PizzaApi.Models;
using PizzaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace PizzaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    #region Actions
    [HttpGet]
    public ActionResult<List<Pizza>> GetAllPizzas() => PizzaService.GetAllPizzas();

    [HttpGet("{id}")]
    public ActionResult<Pizza> GetPizza(int id)
    {
        var pizza = PizzaService.GetPizza(id);
        if(pizza == null) return NotFound();

        return pizza;
    }

    [HttpPost]
    public IActionResult AddPizza(Pizza pizza)
    {
        PizzaService.AddPizza(pizza);

        return CreatedAtAction(nameof(AddPizza), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePizza(int id, Pizza pizza)
    {
        if(id != pizza.Id) return BadRequest();

        var existingPizza = PizzaService.GetPizza(id);
        if(existingPizza is null) return NotFound();

        PizzaService.UpdatePizza(pizza);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePizza(int id)
    {
        var pizza = PizzaService.GetPizza(id);
        if(pizza is null) return NotFound();

        PizzaService.DeletePizza(id);

        return NoContent();
    }
    #endregion
}