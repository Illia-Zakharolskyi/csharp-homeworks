using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLearning.Classes;

internal class Inventory
{
    private readonly Dictionary<string, int> items = new();

    internal void AddItem(string item, int amount = 1)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Кількість повинна бути більше ніж 0");
            return;
        }

        if (items.ContainsKey(item))
        {
            items[item] += amount;
            Console.WriteLine($"Додано ще {amount} шт. предмету: '{item}'");
        }
        else
        {
            items[item] = amount;
            Console.WriteLine($"Додано новий предмет: '{item}', кількість {amount} шт.");
        }
    }

    internal void RemoveItem(string item)
    {
        if (!items.ContainsKey(item))
        {
            Console.WriteLine($"Предмет '{item}' не знайдено в інвентарі для видалення.");
            return;
        }

        items.Remove(item);
        Console.WriteLine($"Предмет '{item}' видалено з інвентарю.");
    }

    internal void ShowInventory()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Інвентар порожній, нічого показати");
            return;
        }

        Console.WriteLine("Інвентар містить:");
        foreach (var item in items)
        {
            Console.WriteLine($"- {item.Value} шт. Предмету {item.Key}");
        }
    }

    internal void ClearInvenory()
    {
        items.Clear();
        Console.WriteLine("Інвентар очищено");
    }
}
