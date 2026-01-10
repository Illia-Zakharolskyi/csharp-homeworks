// .Net 9.0
using System;

// Data
using CardGame.Data.UserProfile;

// Application
using CardGame.src.Application.Managers;

// Domain
using CardGame.src.Domain.Formatters;

// Infastructure
using CardGame.src.Infastructure.Storages;

// UI
using CardGame.src.UI.Dispatchers;
using CardGame.src.UI.Menus;

namespace CardGame.src.UI.Entries;

public static class ProgramEntry
{

    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        // Storages
        UserChoicesStorage userChoicesStorage = new UserChoicesStorage();
        // Formatters
        CardFormatter formatter = new CardFormatter();
        // Managers
        GameManager manager = new GameManager(formatter);
        // Dispatchers
        MenuDispatcher menuDispatcher = new MenuDispatcher();
        // User Profile
        UserChoices userChoices = userChoicesStorage.Load();

        while (true)
        {
            menuDispatcher.Run(new MainMenu(menuDispatcher, manager, userChoices, userChoicesStorage));
        }
    }
}