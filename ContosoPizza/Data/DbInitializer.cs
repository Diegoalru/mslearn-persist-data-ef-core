using ContosoPizza.Models;
using System.Collections.Generic;

namespace ContosoPizza.Data;

public static class DbInitializer
{
    public static void Initialize(PizzaContext context)
    {
        if (context.Pizzas.Any())
        {
            return; // DB has been seeded
        }

        // Toppings
        var toppings = new List<Topping>
        {
            new() { Name = "Pepperoni", Calories = 130 },
            new() { Name = "Sausage", Calories = 100 },
            new() { Name = "Ham", Calories = 70 },
            new() { Name = "Chicken", Calories = 50 },
            new() { Name = "Pineapple", Calories = 75 }
        };

        // Sauces
        var sauces = new List<Sauce>
        {
            new() { Name = "Tomato", IsVegan = true },
            new() { Name = "Alfredo", IsVegan = false }
        };

        // Pizzas
        var pizzas = new List<Pizza>
        {
            new() {
                Name = "Meat Lovers",
                Sauce = sauces[0],
                Toppings = [toppings[0], toppings[1], toppings[2], toppings[3]]
            },
            new() {
                Name = "Hawaiian",
                Sauce = sauces[0],
                Toppings = [toppings[4], toppings[2]]
            },
            new() {
                Name = "Alfredo Chicken",
                Sauce = sauces[1],
                Toppings = [toppings[3]]
            }
        };

        context.Toppings.AddRange(toppings);
        context.Sauces.AddRange(sauces);
        context.Pizzas.AddRange(pizzas);
        context.SaveChanges();
    }
}