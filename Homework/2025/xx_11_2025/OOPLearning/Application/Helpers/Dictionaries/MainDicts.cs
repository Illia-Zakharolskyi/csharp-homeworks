using System;

using OOPLearning.Classes;
using OOPLearning.Application.Runners;

namespace OOPLearning.Application.Helpers.Dictionaries;

internal static class MainDicts
{
    internal static readonly Dictionary<int, (string description, Action action)> availableActions = new()
    {
        { 0, ("вихід", DemoRunner.RunExitDemo) },
        { 1, ("bank", DemoRunner.RunBankAccountDemo) },
        { 2, ("enemy", DemoRunner.RunEnemyDemo) },
        { 3, ("magic", DemoRunner.RunMagicDemo) },
        { 4, ("chest", DemoRunner.RunTreausreChestDemo) },
        { 5, ("inventory", DemoRunner.RunInventoryDemo) },
        { 6, ("plants", DemoRunner.RunMedicinalPlantDemo) },
        { 7, ("trap", DemoRunner.RunTrapDemo) },
        { 8, ("sword", DemoRunner.RunKnightSwordDemo) },
        { 9, ("recipe", DemoRunner.RunRecipeDemo) },
        { 10, ("Всі програми(без виходу)", DemoRunner.RunAllDemos) }
    };
}
