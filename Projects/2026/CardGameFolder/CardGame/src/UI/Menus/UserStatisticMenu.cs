// .Net 9.0
using System;

// Data
using CardGame.Data.UserProfile;

// Application
using CardGame.src.Application.Storages;

// UI
using CardGame.src.UI.Dispatchers;
using CardGame.src.UI.Interfaces;
using CardGame.src.UI.Models;

namespace CardGame.src.UI.Menus;

internal class UserStatisticMenu : Menu, IMenu
{
    private readonly UserStatisticsStorage _userStatisticsStorage;
    private UserStatistics _userStatistics => _userStatisticsStorage.Load();

    internal UserStatisticMenu(MenuDispatcher dispatcher, UserChoices userChoices, UserChoicesStorage userChoicesStorage, UserStatisticsStorage userStatisticsStorage)
        : base(dispatcher, userChoices, userChoicesStorage)
    {
        _userStatisticsStorage = userStatisticsStorage;
    }

    public void Display() 
    { 
        base.Display(GetActionMap()); 
    } 

    public override Dictionary<int, (string description, Action action)> GetActionMap() 
    { 
        return new Dictionary<int, (string description, Action action)> 
        { 
            { 0, ("Повернутися назад", () => _dispatcher.PopMenu()) },
            { 1, ("Показати статистику", () => ShowStatistics())   }
        };
    }

    private void ShowStatistics()
    {
        Console.Clear();

        string Battles = $"Боїв:{_userStatistics.GamesPlayed}";

        string PlayerMoves = $"Зроблено ходів ігроком:{_userStatistics.UserMovesMade}";
        string BotMoves = $"Зроблено ходів ботом:{_userStatistics.OpponentMovesMade}";

        string Wins = $"Перемог: {_userStatistics.GamesWon}";
        string Losses = $"Поразок: {_userStatistics.GamesLost}";

        string PlayerDamage = $"Загальна шкода нанесена ігроком:{_userStatistics.TotalPlayerDamageDealt}";
        string BotDamage = $"Загальна шкода нанесена ботом:{_userStatistics.TotalOpponentDamageDealt}";

        string[] strings = new string[]
        {
            Battles,
            "",
            PlayerMoves,
            BotMoves,
            "",
            Wins,
            Losses,
            "",
            PlayerDamage,
            BotDamage,
        };

        foreach (var str in strings)
        {
            int left = Math.Max(0, Console.WindowWidth / 2 - str.Length / 2);
            Console.SetCursorPosition(left, Console.CursorTop);
            Console.WriteLine(str);
        }
    }
}
