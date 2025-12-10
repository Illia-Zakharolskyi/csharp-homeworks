// .NET 9.0
using System;

// Application
using Lesson_03_12_2025.Application.Helpers.Dictionaries;
using Lesson_03_12_2025.Application.Utilities.Validators;

namespace Lesson_03_12_2025.UI;

internal class MainHandler
{
    private readonly MainDicts _mainDicts;

    internal MainHandler(MainDicts mainDicts)
    {
        _mainDicts = mainDicts;
    }

    internal void HandleUserInput()
    {
        int userChoice = IntegerValidator.ReadInteger(
            "Введіть номер дії: ",
            "Некоректне введення. Спробуйте ще раз.",
            new List<int>(_mainDicts.GetAvailableActions().Keys),
            "Такої дії немає. Спробуйте ще раз."
        );

        _mainDicts.GetAvailableActions()[userChoice].action.Invoke();
    }
}
