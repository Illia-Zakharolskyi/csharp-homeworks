// .Net 9.0
using System;

// Data
using CardGame.Data.UserProfile;

// Application
using CardGame.src.Application.Managers;

// Domain
using CardGame.src.Domain.Models;

// Infastructure

// UI
using CardGame.src.UI.Models;
using CardGame.src.UI.Interfaces;
using CardGame.src.UI.Dispatchers;
using CardGame.src.Application.Storages;

namespace CardGame.src.UI.Menus; 

internal class MainMenu : Menu, IMenu 
{ 
    private readonly CharacterSelectionMenu _characterSelectionMenu;
    private readonly UserStatisticMenu _userStatisticMenu;

    private readonly GameManager _gameManager;
    
    internal MainMenu(MenuDispatcher dispatcher, GameManager gameManager, UserChoices userChoices, UserChoicesStorage userChoicesStorage, UserStatisticsStorage userStatisticsStorage) 
        : base(dispatcher, userChoices, userChoicesStorage) 
    { 
        _gameManager = gameManager;  
        _characterSelectionMenu = new CharacterSelectionMenu(dispatcher, userChoices, _userChoicesStorage); 
        _userStatisticMenu = new UserStatisticMenu(dispatcher, userChoices, userChoicesStorage, userStatisticsStorage);
    } 

    public void Display() 
    { 
        base.Display(GetActionMap()); 
    } 
    public override Dictionary<int, (string description, Action action)> GetActionMap() 
    { 
        return new Dictionary<int, (string description, Action action)> 
        { 
            { 0, ("Вихід", () => Environment.Exit(0)) }, 
            { 1, ("Запустити битву", () => StartBattleAction()) },
            { 2, ("Вибір персонажа", () => _dispatcher.PushMenu(_characterSelectionMenu)) },
            { 3, ("Статистика", () => _dispatcher.PushMenu(_userStatisticMenu)) }
        }; 
    }
    private void StartBattleAction()
    {
        if (_userChoices.SelectedCharacterName == null)
        {
            Console.WriteLine("Спочатку вибери персонажа!");
            Console.ReadKey(true);
            return;
        }

        _gameManager.StartBattle(_userChoices);
    }
}