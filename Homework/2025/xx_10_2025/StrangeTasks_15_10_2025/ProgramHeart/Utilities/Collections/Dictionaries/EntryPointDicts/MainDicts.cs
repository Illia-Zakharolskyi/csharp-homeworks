using StrangeTasks_15_10_2025.ProgramHeart.Core.Interfaces;
using StrangeTasks_15_10_2025.Programs;
using System;

namespace StrangeTasks_15_10_2025.ProgramHeart.Utilities.Collections.Dictionaries.EntryPointDicts;

internal static class MainDicts
{
    internal static readonly Dictionary<int, (string description, IRunnable program)> entryDict = new()
    {
        { 0, ("Вихід з програми", new ExitProgram()) },
        { 1, ("Соковижималка", new Juicer()) },
        { 2, ("Симулятор комп'ютерного майстра", new ComputerMasterSimulator()) },
        { 3, ("магічна кухня", new MagicalKitchen()) },
        { 4, ("подорож у часі", new TimeTravel()) },
        { 5, ("Квест програміста", new ProgramerQuest()) },
    };
}
