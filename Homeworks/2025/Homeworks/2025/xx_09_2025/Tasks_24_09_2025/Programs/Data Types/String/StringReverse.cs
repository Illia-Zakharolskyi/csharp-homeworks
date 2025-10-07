using System;
using Tasks_24_09_2025.ProgramHeart.Interfaces;

namespace Tasks_24_09_2025.Programs.Data_Types.String;

internal class StringReverse : IRunnable
{
    public void Run()
    {
        Console.WriteLine("welcome to string-reverser");
        Console.Write("enter text: ");
        string userInput = Console.ReadLine();
        string reversedText = Reverse(userInput);

        Console.WriteLine(reversedText);
    }
    private static string Reverse(string text)
    {
        string reversed = new string(text.Reverse().ToArray());

        return reversed;
    }
}
