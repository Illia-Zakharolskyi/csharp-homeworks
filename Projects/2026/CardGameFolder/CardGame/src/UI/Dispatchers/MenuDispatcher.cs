// .NET 9.0
using System;


// Utilities
using CardGame.src.Application.Utilities.Validators;
using CardGame.src.UI.Interfaces;




// UI

namespace CardGame.src.UI.Dispatchers;

internal class MenuDispatcher
{
    private readonly Stack<IMenu> menuStack = new();
    
    internal void Run(IMenu menu)
    {
        menuStack.Push(menu);

        while (menuStack.Count > 0)
        {
            var currentMenu = menuStack.Peek();
            var currentMenuActionMap = currentMenu.GetActionMap();
            Console.Clear();
            currentMenu.Display();


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

    internal void PushMenu(IMenu menu)
    {
        menuStack.Push(menu);
    }

    internal void PopMenu()
    {
        if (menuStack.Count > 0)
            menuStack.Pop();
    }
}