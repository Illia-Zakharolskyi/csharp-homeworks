using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Helpers.DataHelpers;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Collections.Dictionaries.EntryPointDicts;
using System;

namespace StrangeTasks_15_10_2025.EntryPoint;

internal static class MainHandler
{
    internal static void StartHanlde()
    {
        int userOption = IntegersHelper.ReadInteger("Введи номер програми яку хочеш запустити: ", "Це не число або значення занадто велике", MainDicts.entryDict.Keys.ToList(), "Такого номера програми ще нема");
        Console.Clear();
        MainDicts.entryDict[userOption].program.Run();
    }
}
