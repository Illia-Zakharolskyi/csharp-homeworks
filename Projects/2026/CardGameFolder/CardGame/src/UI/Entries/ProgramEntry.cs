// .Net 9.0
using System;

// Data
using CardGame.Data.UserProfile;

// Application
using CardGame.src.Application.Managers;
using CardGame.src.Application.Storages;


// Domain
using CardGame.src.Domain.Formatters;

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
        UserStatisticsStorage userStatisticsStorage = new UserStatisticsStorage();
        // User Profile
        UserChoices userChoices = userChoicesStorage.Load();
        UserStatistics userStatistics = userStatisticsStorage.Load();
        // Formatters
        CardFormatter formatter = new CardFormatter();
        // Managers
        GameManager manager = new GameManager(formatter, userStatisticsStorage);
        // Dispatchers
        MenuDispatcher menuDispatcher = new MenuDispatcher();

        while (true)
        {
            menuDispatcher.Run(new MainMenu(menuDispatcher, manager, userChoices, userChoicesStorage, userStatisticsStorage));
        }
    }
}