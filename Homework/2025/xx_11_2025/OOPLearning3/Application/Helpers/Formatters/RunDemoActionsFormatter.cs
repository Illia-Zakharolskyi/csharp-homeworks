using System;

namespace OOPLearning3.Application.Helpers.Formatters;

internal static class RunDemoActionsFormatter
{
    internal static void RunActions(List<Action> actions, string text = "Дія", char symbol = '-', int charRepeats = 50)
    {
        for (int i = 0; i < actions.Count; i++)
        {
            Console.WriteLine($"{text} {i + 1}:");
            actions[i].Invoke();
            Console.WriteLine(new string(symbol, charRepeats));
        }
    }
}
