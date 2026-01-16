// .Net 9.0
using System;

// Data
using CardGame.Data.UserProfile;

// Application
using CardGame.src.Application.Services;
using CardGame.src.Application.Factories;
using CardGame.src.Application.Storages;

// Domain
using CardGame.src.Domain.Models;
using CardGame.src.Domain.Formatters;

// Infastructure
using CardGame.src.Infastructure.Resolvers;

namespace CardGame.src.Application.Managers;

internal class GameManager
{
    private readonly CardFormatter _formatter; 
    private readonly CharacterFactory _characterFactory = new CharacterFactory();
    private readonly PathResolver _pathResolver = new PathResolver();
    private readonly UserStatisticsStorage _userStatisticsStorage;
    internal GameManager(CardFormatter formatter, UserStatisticsStorage userStatisticsStorage) 
    { 
        _formatter = formatter; 
        _userStatisticsStorage = userStatisticsStorage;
    }

    public void StartBattle(UserChoices choices) 
    { 
        string fullCharacterListPath = _pathResolver.ResolveRelativePathToFullPath("Resources/JsonFiles/Lists/CharactersList.json");

        Character? enemy = _characterFactory.CreateEnemy(fullCharacterListPath);
        Character? player = _characterFactory.CreatePlayer(fullCharacterListPath, choices);

        if (enemy == null || player == null) 
        { 
            Console.WriteLine("Не вдалося створити якогось персонажа для битви."); 
            return;
        }

        var battle = new Battle(player, enemy, _formatter, _userStatisticsStorage);
        battle.Run(); 
    }
}