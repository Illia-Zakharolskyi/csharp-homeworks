using Homework_Lists_Dictionaries.ProgramHeart.Core.Interfaces;
using System;
using System.Threading;

namespace Homework_Lists_Dictionaries.Programs.Collections.Lists;

internal class ListNames : IRunnable
{
    public void Run()
    {
        LoopText();
    }
    private static void LoopText()
    {
        foreach (string item in names)
        {
            Console.WriteLine(item);
        }
        Thread.Sleep(50);
    }
    private static readonly List<string> names = new()
    {
        "Anton", "Maksym", "Illia", "Another"
    };
}
