// .Net 9.0
using System;

// Application
using Lesson_10_12_2025.Application.Utilities.Validators;

// UI
using Lesson_10_12_2025.UI.Interfaces;
using Lesson_10_12_2025.UI.Models;

namespace Lesson_10_12_2025.UI.Dispatchers;

internal static class MenuDispatcher
{
    private static Stack<Menu> menuStack = new();

    internal static void Run(Menu menu)
    {
        menuStack.Push(menu);

        while (menuStack.Count > 0)
        {
            var currentMenu = menuStack.Peek();
            var currentMenuActionMap = currentMenu.GetActionMap();
            Console.Clear();
            currentMenu.Display(currentMenuActionMap);


            int userChoice = InetegerValidator.ReadInteger(
                promptMessage: "Введіть ваш вибір: ",
                invalidInputMessage: "Некоректне введення. Спробуйте ще раз.",
                allowedAnswers: new List<int>(currentMenuActionMap.Keys),
                invalidChoiceMessage: "Такої віповіді нема"
            );

            currentMenuActionMap[userChoice].action.Invoke();
            Console.ReadKey();
        }
    }

    internal static void PushMenu(Menu menu)
    {
        menuStack.Push(menu);
    }

    internal static void PopMenu()
    {
        if (menuStack.Count > 0)
            menuStack.Pop();
    }
}
