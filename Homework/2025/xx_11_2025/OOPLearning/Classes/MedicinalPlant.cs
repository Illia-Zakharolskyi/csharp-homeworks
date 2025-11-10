using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLearning.Classes;

internal class MedicinalPlant
{
    private readonly Dictionary<string, int> collectedPlants = new();

    internal void CollectPlant(string plantName, int quantity = 1)
    {
        if (quantity <= 0)
        {
            Console.WriteLine("кількість повинна бути більше ніж 0");
            return;
        }

        if (collectedPlants.ContainsKey(plantName))
        {
            collectedPlants[plantName] += quantity;
            Console.WriteLine($"Додано {quantity} шт. рослини {plantName}");
        }
        else
        {
            collectedPlants[plantName] = quantity;
            Console.WriteLine($"Додана нова рослина {plantName} в кількості {quantity}");
        }
    }

    internal void ShowCollectedPlants()
    {
        if (collectedPlants.Count == 0)
        {
            Console.WriteLine("Лікарські рослини не зібрані");
            return;
        }

        Console.WriteLine("Зібрані лікарські рослини:");

        foreach (var plant in collectedPlants)
        {
            Console.WriteLine($"- {plant.Key}: {plant.Value} шт.");
        }
    }

    internal string? CreateMedicine(string medicineName)
    {
        Dictionary<string, Dictionary<string, int>> recipes = new()
        {
            { "зілля відновлення мани", new Dictionary<string, int> { {"Ромашка", 3 }, { "М'ята", 5 } } },
            { "зілля лікування", new Dictionary<string, int> { { "Алоє", 4 }, { "Календула", 2 } } },
            { "зілля сили", new Dictionary<string, int> { { "Женьшень", 2 }, { "Ехінацея", 3 } } }
        };

        if (!recipes.ContainsKey(medicineName))
        {
            Console.WriteLine($"Рецепт для '{medicineName}' не знайдено.");
            return null;
        }

        Dictionary<string, int> requiredPlants = recipes[medicineName];

        foreach (var plant in requiredPlants)
        {
            if (!collectedPlants.ContainsKey(plant.Key))
            {
                Console.WriteLine($"Нема такої рослини: {plant.Key}");
                return null;
            }

            if (collectedPlants[plant.Key] < plant.Value)
            {
                Console.WriteLine($"Недостатньо рослини: {plant.Key}. Потрібно {plant.Value} шт., а є {collectedPlants[plant.Key]}.");
                return null;
            }

            collectedPlants[plant.Key] -= plant.Value;

            if (collectedPlants[plant.Key] == 0)
            {
                Console.WriteLine($"Видалено рослину {plant.Key} через кількість у 0 штук");
                collectedPlants.Remove(plant.Key);
            }
        }

        Console.WriteLine($"Створено '{medicineName}'");
        return medicineName;
    }
}
