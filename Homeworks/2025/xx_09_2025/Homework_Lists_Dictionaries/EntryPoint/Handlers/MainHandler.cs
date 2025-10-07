using Homework_Lists_Dictionaries.ProgramHeart.Core.Interfaces;
using Homework_Lists_Dictionaries.ProgramHeart.Utilities.HelpDirectionaries;
using System;

namespace Homework_Lists_Dictionaries.EntryPoint.Handlers;

internal static class MainHandler
{
    internal static void Start()
    {
        while (true)
        {
            int selectedNumber = UserInput("your option: ");
            bool isProgram = CheckInDictionary(selectedNumber, MainDictionary.mainDictionary);
            if (isProgram)
            {
                Console.Clear();
                RunProgram(selectedNumber, MainDictionary.mainDictionary);
                break;
            }
            else
            {
                Console.WriteLine("No such option in menu, click any button to try again");
                Console.ReadKey(true);
                break;
            }
        }
    }
    private static int UserInput(string text)
    {
        while (true)
        {
            Console.Write(text);
            if (int.TryParse(Console.ReadLine(), out int selectedNumber))
            {
                return selectedNumber;
            }
            else
            {
                // можливо вернути будь яке число яке не є в главному словнику, щоб заробив оператор else
                return -1;
            }
        }
    }
    private static bool CheckInDictionary(int selectedNumber, Dictionary<int, (string description, IRunnable program)> dictionary)
    {
        if (dictionary.ContainsKey(selectedNumber))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private static void RunProgram(int selectedNumber, Dictionary<int, (string description, IRunnable program)> dictionary)
    {
        dictionary[selectedNumber].program.Run();
    }
}