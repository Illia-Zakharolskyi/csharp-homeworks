using StrangeTasks_15_10_2025.ProgramHeart.Core.Interfaces;
using System;

namespace StrangeTasks_15_10_2025.Programs;

internal class ExitProgram : IRunnable
{
    public void Run()
    {
        Console.Clear();

        Console.WriteLine("Допобачення!");

        Console.ReadKey();
        Environment.Exit(0);
    }
}
