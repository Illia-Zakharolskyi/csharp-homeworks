using StrangeTasks_15_10_2025.ProgramHeart.Core.Interfaces;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Collections.Dictionaries.ProgramsDicts;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Helpers.CollectionHelpers;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Helpers.DataHelpers;
using System;

namespace StrangeTasks_15_10_2025.Programs;

internal class Juicer : IRunnable
{
    public void Run()
    {
        ListHelper.DisplayList("Доступні фрукти для введеня: ", JuicerDicts.fruitJuices.Keys.ToList());
        Console.WriteLine();

        string userFruit = StringHelper.ReadString("введи один з фруктів: ", "фрукт не може бути з пустою назвою!", JuicerDicts.fruitJuices.Keys.ToList(), true, "Такого фрукту нажаль ще нема в доступних");

        double amountOfJuice = GetAmountOfJuice(userFruit);
        Console.WriteLine($"Сока у фрукті без 'магічного' додавання: {amountOfJuice}");

        AddJuiceInFruit(ref  amountOfJuice);
        Console.WriteLine($"Сока у фрукті з 'магічним' додаванням: {amountOfJuice:F2}");
    }
    private static double GetAmountOfJuice(string fruit)
    {
        return JuicerDicts.fruitJuices[fruit.ToLower()];
    }
    private static void AddJuiceInFruit(ref double amountOfJuice)
    {
        amountOfJuice = amountOfJuice * 1.25;
    }
}
