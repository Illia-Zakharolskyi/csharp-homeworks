using MagicCrystal.CrystalHeart.Helpers.Collections.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCrystal.CrytsalInfo;

internal static class Crystal
{
    internal static void Draw()
    {
        int n = 5; // висота половини кристалу
        int consoleWidth = Console.WindowWidth; // щоб кожен раз коли потрібно не писати Console.WindowWidth

        //верхня частина
        for (int i = 1; i <= n; i++)
        {
            int stars = 2 * i - 1;
            string line = new string('*', stars);
            int leftPadding = (consoleWidth - line.Length) / 2;
            Console.WriteLine(new string(' ', leftPadding) + line);
        }

        //нижня частина
        for (int i = n - 1; i >= 1; i--)
        {
            int stars = 2 * i - 1;
            string line = new string('*', stars);
            int leftPadding = (consoleWidth - line.Length) / 2;
            Console.WriteLine(new string(' ', leftPadding) + line);
        }
    }
    internal static void GiveAnswer(Random rnd, List<string> answers)
    {
        int backgroundColor = rnd.Next(0, 5);
        int foregroundColor = backgroundColor == 5 ? 0 : backgroundColor + 1; // наступний колір

        Console.BackgroundColor = GenerateColor(backgroundColor);
        Console.ForegroundColor = GenerateColor(foregroundColor);
        
        Console.WriteLine(answers[rnd.Next(answers.Count)]);
    }
    private static ConsoleColor GenerateColor(int num)
    {
        switch (num)
        {
            case 0: return ConsoleColor.Green;
            case 1: return ConsoleColor.Blue;
            case 3: return ConsoleColor.Yellow;
            case 4: return ConsoleColor.Red;
            case 5: return ConsoleColor.Magenta;
            default: return ConsoleColor.Black;
        }
    }
}
