using System;
using Tasks_24_09_2025.ProgramHeart.Interfaces;

namespace Tasks_24_09_2025.Programs.Data_Types.String;

internal class StringIsPalindrome : IRunnable
{
    public void Run()
    {
        Console.WriteLine("Welcome to program palindrome-check!");
        while (true)
        {
            Console.Write("Your text: ");
            string text = Console.ReadLine();
            bool CorrectInput = CheckInput(text);
            if (CorrectInput)
            {
                string reversedText = Reverse(text);
                bool isPalindrome = CheckPalindrome(text, reversedText);
                if (isPalindrome)
                {
                    Console.WriteLine("It's palindrome!");
                    break;
                }
                else
                {
                    Console.WriteLine("It's not palindrome");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input, text need to be longer than 0 characters and not only spaces");
                continue;
            }
        }
    }
    private static bool CheckInput(string text)
    {
        if (!string.IsNullOrWhiteSpace(text)) return true;
        else return false;
    }
    private static string Reverse(string text)
    {
        string reversed = new string(text.Reverse().ToArray());

        return reversed;
    }
    private static bool CheckPalindrome(string text1, string text2)
    {
        if (text1 == text2) return true;
        else return false;
    }
}
