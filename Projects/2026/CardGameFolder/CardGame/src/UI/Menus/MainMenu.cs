﻿// .Net 9.0
using System;

// Data
using CardGame.Data.UserProfile;

// Application
using CardGame.src.Application.Managers; 

// Domain
using CardGame.src.Domain.Models;

// Infastructure
using CardGame.src.Infastructure.Storages;

// UI
using CardGame.src.UI.Models; 
using CardGame.src.UI.Interfaces; 
using CardGame.src.UI.Dispatchers;

namespace CardGame.src.UI.Menus; 

internal class MainMenu : Menu, IMenu 
{ 
    private readonly CharacterSelectionMenu _characterSelectionMenu; 
    private readonly GameManager _gameManager; 
    
    internal MainMenu(MenuDispatcher dispatcher, GameManager gameManager, UserChoices userChoices, UserChoicesStorage userChoicesStorage) : base(dispatcher, userChoices, userChoicesStorage) 
    { 
        _gameManager = gameManager;  
        _characterSelectionMenu = new CharacterSelectionMenu(dispatcher, userChoices, _userChoicesStorage); 
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
            { 1, ("Вибір персонажа", () => _dispatcher.PushMenu(_characterSelectionMenu)) },
            { 2, ("Запустити битву", () => StartBattleAction()) }
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