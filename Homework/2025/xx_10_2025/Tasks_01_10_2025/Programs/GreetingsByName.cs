using System;
using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class GreetingsByName : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("Ласкаво просимо до Вітання по Імені/!", '/', "", "", true);

        // приймаемо дані
        string userName = StringHelper.ReadString("введи своє ім'я: ", "не коректний текст, текст повинен бути не пустим");

        // вітаємо
        SayHello(userName);
    }
    private static void SayHello(string name)
    {
        Console.WriteLine($"Привіт {name}!");
    }
}
