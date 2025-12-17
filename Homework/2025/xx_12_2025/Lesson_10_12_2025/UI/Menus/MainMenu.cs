// .NET 9.0
using System;

// Application
using Lesson_10_12_2025.Application.RefactoredTasks;


// UI
using Lesson_10_12_2025.UI.Models;
using Lesson_10_12_2025.UI.Dispatchers;
using Lesson_10_12_2025.UI.Interfaces;

namespace Lesson_10_12_2025.UI.Menus;

internal class MainMenu : Menu, IMenu
{
    public void Display()
    {
        base.Display(GetActionMap());
    }

    public override Dictionary<int, (string description, Action action)> GetActionMap()
    {
        Task1Menu task1Menu = new();
        Task2Menu task2Menu = new();
        Task3Menu task3Menu = new();
        Task4Menu task4Menu = new();
        Task5Menu task5Menu = new();
        Task6Menu task6Menu = new();
        Task7Menu task7Menu = new();


        return new Dictionary<int, (string description, Action action)>
        {
            { 0, ("Вихід", () => Environment.Exit(0)) },
            { 1, ("Зарефакторенне завдання 1", () => MenuDispatcher.Run(task1Menu)) },
            { 2, ("Зарефакторенне завдання 2", () => MenuDispatcher.Run(task2Menu)) },
            { 3, ("Зарефакторенне завдання 3", () => MenuDispatcher.Run(task3Menu)) },
            { 4, ("Зарефакторенне завдання 4", () => MenuDispatcher.Run(task4Menu)) },
            { 5, ("Зарефакторенне завдання 5", () => MenuDispatcher.Run(task5Menu)) },
            { 6, ("Зарефакторенне завдання 6", () => MenuDispatcher.Run(task6Menu)) },
            { 7, ("Зарефакторенне завдання 7", () => MenuDispatcher.Run(task7Menu)) },
        };
    }
}