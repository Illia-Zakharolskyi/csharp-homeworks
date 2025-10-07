using System;
using System.Globalization;
using Tasks_24_09_2025.ProgramHeart.Interfaces;

namespace Tasks_24_09_2025.Programs.Data_Types.String;

internal class StringRepChar : IRunnable
{
    public void Run()
    {
        Console.WriteLine("wellcome to every-second-char-from-first-become-big!");
        while (true)
        {
            Console.Write("your text: ");
            string text = Console.ReadLine();
            bool isAllGood = CheckInput(text);
            if (isAllGood)
            {
                string replacedText = Replacer(text);
                Console.WriteLine(replacedText);
                break;
            }
            else
            {
                Console.WriteLine("Text need to be longer than 0 character and not only spaces");
                continue;
            }
        }
    }
    private static bool CheckInput(string text)
    {
        if (!string.IsNullOrWhiteSpace(text))
            return true;
        else
            return false;
    }
    private static string Replacer(string text)
    {
        // Concat -> добавляє всі символи в строку, ? - if (true), : - else
        return string.Concat(text.Select((character, index) => index % 2 == 0 ? char.ToUpper(character) : char.ToLower(character)));
    }
}
