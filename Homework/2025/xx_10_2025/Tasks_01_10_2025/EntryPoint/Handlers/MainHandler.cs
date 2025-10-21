using System;
using Tasks_01_10_2025.ProgramHeart.Utilities.Dictionaries;

namespace Tasks_01_10_2025.EntryPoint.Handlers;

internal static class MainHandler
{
    internal static void Start()
    {
        while (true)
        {
            Console.Write("Your answer by ID(твоя відповідь по айді): ");
            string text = Console.ReadLine();
            var correctData = CheckDataType(text);
            if (!correctData.isCorrect)
            {
                NotCorrectData("Invalid input(не коректний ввід)");
                continue;
            }
            bool inDictionary = CheckKeyInDirectionary(correctData.key);
            if (inDictionary)
            {
                Console.Clear();
                MainDict.mainDict[correctData.key].program.Run();
                break;
            }
            else
            {
                NotCorrectData("Invalid ID(не коректний айді)");
                continue;
            }
        }
    }
    private static (bool isCorrect, int key) CheckDataType(string text)
    {
        if (int.TryParse(text, out int answer) && !string.IsNullOrWhiteSpace(text))
        {
            return (true, answer);
        }
        else
            return (false, -1);
    }
    private static bool CheckKeyInDirectionary(int key)
    {
        if (MainDict.mainDict.ContainsKey(key))
            return true;
        else
            return false;
    }
    private static void NotCorrectData(string text)
    {
        Console.WriteLine(text);
    }
}
