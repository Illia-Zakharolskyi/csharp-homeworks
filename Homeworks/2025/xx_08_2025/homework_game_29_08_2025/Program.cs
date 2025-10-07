using System;
using System.Collections.Generic;
using System.Threading;

namespace homework_game_29_08_2025
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                TasksMenu();
                UserAnswer();
            }
        }
        static void TasksMenu()
   
        {
            Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine("Hello to my game! what do you want to make?");
            List<string> Menu = new List<string>
            {
                "exit",
                "continue"
            };
            for (int i = 0; i < Menu.Count; i++)
            {
                Console.WriteLine($"{i} - {Menu[i]}");
            }
        }
        static void UserAnswer()
        {
            Console.Write("your option: ");
            if (int.TryParse(Console.ReadLine(), out int userOption))
            {
                switch (userOption)
                {
                    case 0:
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Bye!");
                        Environment.Exit(0);
                        break;
                    case 1:
                        GameGuessTheNumber();
                        break;
                    default:
                        Console.WriteLine("not correct choice");
                        return;
                }
            }
        }
        static void GameGuessTheNumber()
        {
            bool inGame = true;
            while (inGame)
            {
                TaskMenu();
                UserOperation();
            }
            void TaskMenu()
            {
                Thread.Sleep(2500);
                Console.Clear();
                List<string> menu = new List<string>
                {
                    "exit to srart menu",
                    "start easy level(secret number is from 1 to 15)",
                    "start medium level(secret number is from 1 to 45)",
                    "start hard level(secret number is from 1 to 100)",
                    "start optional level(you write parameters of secret number)"
                };
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i} - {menu[i]}");
                }
            }
            void UserOperation()
            {
                Console.Write("your operation: ");
                if (int.TryParse(Console.ReadLine(), out int userOperation))
                {
                    switch (userOperation)
                    {
                        case 0:
                            inGame = false;
                            break;
                        case 1:
                            Game(1, 16);
                            break;
                        case 2:
                            Game(1, 46);
                            break;
                        case 3:
                            Game(1, 101);
                            break;
                        case 4:
                            UserParameters();
                            break;
                        default:
                            Console.WriteLine("not correct option");
                            break;
                    }
                }
                else
                {

                }
            }
            void UserParameters()
            {
                Thread.Sleep(500);
                Console.Clear();
                bool isAllGreat = false;
                do
                {
                    Console.Write("min. secret number: ");
                    if (int.TryParse(Console.ReadLine(), out int minSecretNumber))
                    {
                        Console.Write("max. secret number: ");
                        if (int.TryParse(Console.ReadLine(), out int maxSecretNumber))
                        {
                            isAllGreat = true;
                            Game(minSecretNumber, maxSecretNumber + 1); // зробив +1 щоб було логічно, якщо не було б +1, наприклад користувач вводе максимальне число 5, а насправді воно буде 4, для користувача це трішки не зрозуміло
                        }
                        else
                        {
                            Console.WriteLine("not correct input");
                        }
                    }
                    else
                    {
                        Console.WriteLine("not correct input");
                    }
                }
                while (isAllGreat == false);
                {
                        Console.WriteLine("not correct input, print integer");
                }
            }
            void Game(int a, int b)
            {
                int userTries = 0;
                Random rnd = new Random();
                int secretNumber = rnd.Next(a, b);
                Console.Clear();
                Console.WriteLine($"The game is start! secret number can be from {a} to {b - 1}, good luck!"); // b - 1 щоб вивелося те число, яке є максимальним насправді
                Thread.Sleep(1500);
                bool inThisGame = true;
                while (inThisGame)
                {
                    Console.Write("your guess: ");
                    if (int.TryParse(Console.ReadLine(), out int selectedNumber))
                    {
                        Thread.Sleep(200);
                        if (selectedNumber != secretNumber)
                        {
                            if (selectedNumber < a || selectedNumber > b - 1)
                            {
                                Console.WriteLine("your input not can be secret number");
                                continue;
                            }
                            userTries++;
                            if (selectedNumber < secretNumber)
                            {
                                Console.WriteLine("your guess smaller than secret number!");
                            }
                            else if (selectedNumber > secretNumber)
                            {
                                Console.WriteLine("your guess bigger than secret number!");
                            }
                            continue;
                        }
                        else if (selectedNumber == secretNumber)
                        {
                            userTries++;
                            Thread.Sleep(1000);
                            Console.Clear();
                            Console.WriteLine($"Well done! you guess the secret number for {userTries} tries!");
                            bool inEnd = true;
                            while (inEnd)
                            {
                                Console.WriteLine("0 - exit to start menu, 1 - play again");
                                if (int.TryParse(Console.ReadLine(), out int userOperation))
                                {
                                    switch (userOperation)
                                    {
                                        case 0:
                                            Console.WriteLine("Thank for playing our game!");
                                            inGame = false;
                                            inThisGame = false;
                                            inEnd = false;
                                            break;
                                        case 1:
                                            inThisGame = false;
                                            inEnd = false;
                                            break;
                                        default:
                                            Console.Clear();
                                            Console.WriteLine("not correct operation");
                                            continue;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("not correct input");
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("not correct input");
                        continue;
                    }
                }
            }
        }
    }
}