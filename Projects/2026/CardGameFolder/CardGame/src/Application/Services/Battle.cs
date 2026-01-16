// .Net 9.0
using System;
using System.Text;

// Application
using CardGame.src.Application.Storages;

// Domain
using CardGame.src.Domain.Formatters;
using CardGame.src.Domain.Models;

namespace CardGame.src.Application.Services;

internal class Battle
{
    private readonly Character _player;
    private readonly Character _enemy;
    private readonly CardFormatter _cardsFormatter;
    private readonly UserStatisticsStorage _userStatisticsStorage;
    private bool _isPlayerTurn = false;

    internal Battle(Character player, Character enemy, CardFormatter formatter, UserStatisticsStorage userStatisticsStorage) 
    { 
        _player = player; 
        _enemy = enemy; 
        _cardsFormatter = formatter; 
        _userStatisticsStorage = userStatisticsStorage;
    }
    internal void Run()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red; 
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗"); 
        Console.WriteLine("║ ПОПЕРЕДЖЕННЯ! Зробіть консоль на весь екран перед битвою, ║"); 
        Console.WriteLine("║ Інакше можливі графічні баги при відображенні карт.       ║"); 
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝"); 
        Console.ResetColor();

        var _userStatistics = _userStatisticsStorage.Load();

        Console.ReadKey(true);

        while (_player.IsAlive() && _enemy.IsAlive())
        {
            _isPlayerTurn = !_isPlayerTurn;

            _player.HandClear();
            _enemy.HandClear();

            for (int i = 0; i < 7; i++)
            {
                _player.DrawCard();
                _enemy.DrawCard();
            }

            string enemyHeader = "КАРТИ ПРОТИВНИКА";
            string playerHeader = "ВАШІ КАРТИ";
            string playerInfo = $"Ви({_player.Name}): {_player.CurrentHealth}/{_player.MaxHealth} HP, {_player.CurrentMana}/{_player.MaxMana} Mana";
            string enemyInfo = $"Ворог({_enemy.Name}):  {_enemy.CurrentHealth}/{_enemy.MaxHealth} HP, {_enemy.CurrentMana}/{_enemy.MaxMana} Mana";
            int left = Math.Max(0, Console.WindowWidth / 2 - playerHeader.Length); 
            int right = Math.Max(0, Console.WindowWidth / 2); 

            Console.Clear();

            Console.WriteLine($"{playerInfo}{new string(' ', Console.WindowWidth / 2 - playerInfo.Length - 1)}🆚{new string(' ', Console.WindowWidth / 2 - enemyInfo.Length - 1)}{enemyInfo}");

            _cardsFormatter.CardsInRow(_enemy.GetHand());
            Console.WriteLine($"{new string('=', left - 3)}{enemyHeader}{new string('=', right - 3)}");

            Console.WriteLine($"{new string(' ', Console.WindowWidth * 4)}");

            Console.WriteLine($"{new string('=', left)}{playerHeader}{new string('=', right)}");
            _cardsFormatter.CardsInRow(_player.GetHand());

            if (_isPlayerTurn)
            {
                _player.Attack(_enemy);
                _userStatistics.UserMovesMade++;
                _userStatistics.TotalPlayerDamageDealt += _player.LastDamageDealt;
            }
            else
            {
                Console.WriteLine("Хід ворога...");
                _userStatistics.OpponentMovesMade++;
                Thread.Sleep(2000);
                _enemy.Attack(_player);
                _userStatistics.TotalOpponentDamageDealt += _enemy.LastDamageDealt;
            }

            Console.ReadKey(true);
        }

        _userStatistics.GamesPlayed++;

        if (_player.IsAlive()) _userStatistics.GamesWon++;
        else _userStatistics.GamesLost++;

        _userStatisticsStorage.Save(_userStatistics);

        Console.Clear();

        string winner = _player.IsAlive() ? "гравець" : "ворог";
        Console.WriteLine($"{winner} Виграв!");
    }
}