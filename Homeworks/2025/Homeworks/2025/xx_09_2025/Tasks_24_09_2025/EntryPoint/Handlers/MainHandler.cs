using System;
using Tasks_24_09_2025.ProgramHeart.Interfaces;
using Tasks_24_09_2025.ProgramHeart.Utilities.MainDictionaries;

namespace Tasks_24_09_2025.EntryPoint.Handlers;

internal static class MainHandler
{
    internal static void Start()
    {
        int selectedNum = UserInput("your option: ", "Invalid input, write integer");
        CheckInDictionary(MainDictionary.mainDictionary, selectedNum);
    }
    private static int UserInput(string welcomeText, string errorText)
    {
        while (true)
        {
            Console.Write(welcomeText);
            if (int.TryParse(Console.ReadLine(), out int answered))
            {
                return answered;
            }
            else
            {
                Console.WriteLine(errorText);
                continue;
            }
        }
    }
    private static void CheckInDictionary(Dictionary<int, (string description, IRunnable program)> dict, int num)
    {
        if (dict.ContainsKey(num))
        {
            Console.Clear();
            dict[num].program.Run();
        }
        else
        {
            Console.WriteLine("Invalid ID, try again");
        }
    }
}
