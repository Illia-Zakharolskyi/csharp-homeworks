using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPLearning.Classes;

internal class Recipe
{
    internal string Name { get; init; } = String.Empty;
    private readonly Dictionary<string, string> ingredients = new();

    internal void AddIngredient(string ingredient, string quantity = "1 шт.")
    {
        if (string.IsNullOrEmpty(ingredient) || string.IsNullOrEmpty(quantity))
        {
            Console.WriteLine("Не корректна назва чи кількість інгрідіентів");
            return;
        }
        if (ingredients.ContainsKey(ingredient))
        {
            ingredients[ingredient] += quantity;
        }
        else
        {
            ingredients[ingredient] = quantity;
        }

        Console.WriteLine($"Новий інгрідіент - {ingredient}, в кількості {ingredients[ingredient]}");
    }
    internal void ChangeIngredientQuantity(string ingredient, string quantity)
    {
        if (!ingredients.ContainsKey(ingredient))
        {
            Console.WriteLine("Такого інгрідіенту немає");
            return;
        }

        ingredients[ingredient] = quantity;

        Console.WriteLine($"Кількість {ingredient} зінилася на {quantity}");
    }
    internal void RemoveIngredient(string ingredient)
    {
        if (!ingredients.ContainsKey(ingredient))
        {
            Console.WriteLine("Такого інгрідіенту немає");
            return;
        }

        ingredients.Remove(ingredient);

        Console.WriteLine($"Інгрідіент {ingredient} видалено з рецепту");
    }
    internal void ShowRecipeIngredients()
    {
        if (ingredients.Count == 0)
        {
            Console.WriteLine("Інгрідієнти відсутні");
            return;
        }

        Console.WriteLine($"Інгрідієнти для рецепту '{Name}':");

        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($"- {ingredient.Key}: {ingredient.Value}");
        }
    }

    internal Dictionary<string, string> GetIngredients()
    {
        return new Dictionary<string, string>(ingredients);
    }
}
