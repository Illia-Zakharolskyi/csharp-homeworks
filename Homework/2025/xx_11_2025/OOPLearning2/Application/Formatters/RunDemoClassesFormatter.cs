using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLearning2.Application.Formatters;

internal static class RunDemoClassesFormatter
{
    internal static void RunActions(List<Action> actions, string text = "Дія", char symbol = '-', int charRepeats = 30)
    {
        for (int i = 0; i < actions.Count; i++)
        {
            Console.WriteLine($"{text} {i + 1}:");
            actions[i].Invoke();
            Console.WriteLine(new string(symbol, charRepeats));
        }
    }
}
