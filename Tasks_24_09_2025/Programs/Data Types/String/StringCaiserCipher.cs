using System;
using Tasks_24_09_2025.ProgramHeart.Interfaces;

namespace Tasks_24_09_2025.Programs.Data_Types.String;

internal class StringCaiserCipher : IRunnable
{
    public void Run()
    {
        Console.WriteLine("welcome to Caiser-cipher!");
        string input = GetInput();
        string result = Cipher(input);
        ShowResult(result);
    }
    private static string GetInput()
    {
        Console.Write("Enter text: ");

        string input = Console.ReadLine().ToLower();

         if (input != null && input.Length > 0)
        {
            return input;
        }
        else
        {
            GetInput(); return "";
        }
    }
    private static string Cipher(string input)
    {
        string result = "";

        foreach (char c in input)
        {
            result += ShiftChar(c);
        }

        return result;
    }
    private static char ShiftChar(char c)
    {
        if (!Alphabet.Contains(c))
            return c;

        int index = Alphabet.IndexOf(c);
        int nextIndex = (index + 1) % Alphabet.Count;
        return Alphabet[nextIndex];
    }
    private static void ShowResult(string result)
    {
        Console.WriteLine("Ciphered text:");
        Console.WriteLine(result);
    }

    private static readonly List<char> Alphabet = new List<char>
    {
        'a','b','c','d','e','f','g','h','i','j','k','l','m',
        'n','o','p','q','r','s','t','u','v','w','x','y','z'
    };
}
