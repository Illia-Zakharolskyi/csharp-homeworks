using System;

using OOPLearning3.Application.Routing;
using OOPLearning3.Application.Utilities.Validators;

namespace OOPLearning3.UI;

internal static class MainHandler
{
    internal static void Start()
    {
        int userAction = IntegerValidator.ReadInteger("введи номер дії яку хочеш зробити \n> ", "це не число, спробуй ще", MainDicts.availableActions.Keys.ToList(), "такого номеру дії нажаль ще немає. спробуй ще");
        Console.Clear();
        MainDicts.availableActions[userAction].action.Invoke();
    }
}
