using OOPLearning2.Application.Routing.Dictionaries;
using OOPLearning2.Application.Utilitites.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLearning2.UI;

internal static class MainHandler
{
    internal static void Start()
    {
        int userNumber = IntegerValidator.ReadInteger("введіть номер: ", "не корректний ввід", DemoActionMap.availableActions.Keys.ToList(), "не корректний номер");
        Console.Clear();
        DemoActionMap.availableActions[userNumber].action();
    }
}
