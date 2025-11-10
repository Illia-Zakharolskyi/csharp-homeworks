using OOPLearning.Application.Helpers.Dictionaries;
using System.Collections.ObjectModel;
using System;
using SimpleAssistant.ProgramHeart.Utilities.Helpers.DataHelpers;

namespace OOPLearning.UI;

internal static class MainHandler
{
    internal static void StartHandle()
    {
        int userNumber = IntegerValidator.ReadInteger("введіть номер презентації: ", "не корректний ввід", MainDicts.availableActions.Keys.ToList(), "не корректний номер");
        Console.Clear();
        MainDicts.availableActions[userNumber].action();
    }
}
