using OOPLearning2.Application.Routing.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLearning2.UI;

internal static class MainMenu
{
    internal static void Display()
    {
        Console.WriteLine($"{"Номер",-6} | {"Опис"}");
        Console.WriteLine(new string('-', 40));

        foreach (var item in DemoActionMap.availableActions)
        {
            Console.WriteLine($"{item.Key,-6} | {item.Value.description}");
        }

        Console.WriteLine(new string('-', 40));
    }
}
