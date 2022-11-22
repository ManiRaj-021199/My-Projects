using PizzaApi.Models;

namespace PizzaApi.Services;

public static class PizzaService
{
    static int nextId = 3;

    #region Properties
    static List<Pizza> Pizzas { get; }
    #endregion

    #region Constructors
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
            new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
        };
    }
    #endregion

    #region Publics
    public static List<Pizza> GetAllPizzas() => Pizzas;

    public static Pizza? GetPizza(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void AddPizza(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void DeletePizza(int id)
    {
        var pizza = GetPizza(id);
        if(pizza is null) return;

        Pizzas.Remove(pizza);
    }

    public static void UpdatePizza(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if(index == -1) return;

        Pizzas[index] = pizza;
    }
    #endregion
}