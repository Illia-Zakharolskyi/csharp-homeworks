using System;
using Tasks_24_09_2025.ProgramHeart.Interfaces;

namespace Tasks_24_09_2025.Programs.Data_Types.String;

internal class StringWordFinder : IRunnable
{
    public void Run()
    {
        Console.WriteLine("welcome to word-finder mini game!");
        string words = UserInput("Enter text: ");
        bool isFound = WordFinder(words, "cat");
        if (isFound)
            Console.WriteLine("Yes! you have 'cat' in the text!");
        else
            Console.WriteLine("No, 'cat' was not found in your text");
    }
    private static string UserInput(string welcomeText)
    {
        while (true)
        {
            Console.Write(welcomeText);
            string answer = Console.ReadLine();
            if (answer != null)
            {
                return answer;
            }
            else
            {
                Console.WriteLine("Invalid input, input need to be longer than 0 characters");
            }
        }
    }
    private static bool WordFinder(string text, string word)
    {
        char[] separators = { ' ', '!', '?', ',', '.', ':', ';', '-', '\n', '\r', '\t' };

        var separatedText = text
            .Split(separators, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        if (separatedText.Contains(word))
            return true;
        else
            return false;
    }
}
