using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLearning.Classes;

internal class TreasureChest
{
    private readonly Dictionary<string, int> treasures = new();
    private bool isOpen = false;

    internal void AddTreasure(string treasure, int quantity = 1)
    {
        if (quantity <= 0)
        {
            Console.WriteLine("кількість повинна бути більше ніж 0");
            return;
        }
        if (treasures.ContainsKey(treasure))
        {
            treasures[treasure] += quantity;
            Console.WriteLine($"додано ще {quantity} шт. скарби: {treasure}");
        }
        else
        {
            treasures[treasure] = quantity;
            Console.WriteLine($"додано новий скарб: {treasure}, кількість {quantity} шт.");
        }
    }

    internal void OpenChest()
    {
        string text = isOpen ? "скриня вже відкрита, нічого нового туди не додалося" : "скриню відкрито, ось що в ній є:";
        Console.WriteLine(text);
        if (isOpen) return;
        isOpen = true;

        if (treasures.Count == 0)
        {
            Console.WriteLine("нічого");
            return;
        }

        foreach (var treasure in treasures)
        {
            Console.WriteLine($"- {treasure.Key}, кількість {treasure.Value} шт");
        }
    }
    internal void CloseChest()
    {
        if (!isOpen)
        {
            Console.WriteLine("Скриню вже закрито");
            return;
        }

        isOpen = false;
        Console.WriteLine("скриню закрито");
    }
}