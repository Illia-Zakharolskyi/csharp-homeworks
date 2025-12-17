// .Net 9.0
using System;

namespace Lesson_10_12_2025.UI.Models;

internal class Menu
{
    public virtual void Display(Dictionary<int, (string description, Action action)> actionMap)
    {
        Console.WriteLine($"{"Номер", -6} | {"Опис"}");
        Console.WriteLine(new string('-', 40));

        foreach (var item in actionMap)
        {
            Console.WriteLine($"{item.Key,-6} | {item.Value.description}");
        }

        Console.WriteLine(new string('-', 40));
    }
    public virtual Dictionary<int, (string description, Action action)> GetActionMap()
    {
        return new Dictionary<int, (string description, Action action)>();
    }
}