using System;
using Tasks_24_09_2025.ProgramHeart.Interfaces;

namespace Tasks_24_09_2025.Programs.Data_Types.String;

internal  class StringConvertToASCII : IRunnable
{
    public void Run()
    {
        Console.WriteLine("Wellcome to ASCII converter!");
        while (true)
        {
            Console.Write("enter text: ");
            string text = Console.ReadLine();
            if (text != null)
            {
                ConvertToASCII(text);
                break;
            }
            else
            {
                Console.WriteLine("Input need to be longer than 0 characters");
            }
        }
    }
    private static void ConvertToASCII(string text)
    {
        foreach (char c in text)
        {
            Console.WriteLine($"{c} - {(int)c}");
        }
    }
}
