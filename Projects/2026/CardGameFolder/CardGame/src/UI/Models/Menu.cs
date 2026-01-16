// System
using System;

// Data
using CardGame.Data.UserProfile;
using CardGame.src.Application.Storages;


// Infrastructure

// UI
using CardGame.src.UI.Dispatchers;

namespace CardGame.src.UI.Models;

internal class Menu
{
    protected readonly MenuDispatcher _dispatcher;
    protected readonly UserChoices _userChoices;
    protected readonly UserChoicesStorage _userChoicesStorage;

    protected Menu(MenuDispatcher dispatcher, UserChoices userChoices, UserChoicesStorage userChoicesStorage)
    {
        _dispatcher = dispatcher;
        _userChoices = userChoices;
        _userChoicesStorage = userChoicesStorage;
    }

    public virtual void Display(Dictionary<int, (string description, Action action)> actionMap)
    {
        Console.WriteLine($"{"Номер",-6} | {"Опис"}");
        Console.WriteLine(new string('-', 40));

        foreach (var item in actionMap)
        {
            Console.WriteLine($"{item.Key,-6} | {item.Value.description}");
        }

        Console.WriteLine(new string('-', 40));
    }

    public virtual Dictionary<int, (string description, Action action)> GetActionMap()
    {
        return new Dictionary<int, (string description, Action action)>();
    }
}
