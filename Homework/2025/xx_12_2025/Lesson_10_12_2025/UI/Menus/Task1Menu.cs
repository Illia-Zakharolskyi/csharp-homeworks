// .Net 9.0
using System;

// Application
using Lesson_10_12_2025.Application.RefactoredTasks;


// UI
using Lesson_10_12_2025.UI.Models;
using Lesson_10_12_2025.UI.Dispatchers;
using Lesson_10_12_2025.UI.Interfaces;

namespace Lesson_10_12_2025.UI.Menus;

internal class Task1Menu : Menu, IMenu
{
    public void Display()
    {
        base.Display(GetActionMap());
    }

    public override Dictionary<int, (string description, Action action)> GetActionMap()
    {
        return new Dictionary<int, (string description, Action action)>
        {
            { 0, ("назад", () => MenuDispatcher.PopMenu()) },
            { 1, ("викликати завдання", () => Task1.Execute()) },
        };
    }
}
