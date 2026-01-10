// .Net 9.0
using System;
using System.Text;


// Application
using CardGame.src.Application.Utilities.Validators;

// Domain
using CardGame.src.Domain.Formatters;
using CardGame.src.Domain.Models;

namespace CardGame.src.Application.Services;

internal class Battle
{
    private readonly Character _player;
    private readonly Character _enemy;
    private readonly CardFormatter _cardsFormatter;
    private bool _isPlayerTurn = false;

    internal Battle(Character player, Character enemy, CardFormatter formatter) 
    { 
        _player = player; 
        _enemy = enemy; 
        _cardsFormatter = formatter; 
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
            }
            else
            {
                Console.WriteLine("Хід ворога...");
                Thread.Sleep(2000);
                _enemy.Attack(_player);
            }

            Console.ReadKey(true);
        }

        Console.Clear();
        Console.WriteLine($"{(_player.IsAlive() ? "Гравець" : "Ворог")} Виграв!");
    }
}