using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace tasks_05_09_2025
{
    internal class UserExit
    {
        internal static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Bye!");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
    // Інтерфейс для уникнення використання lambda-функцій у словнику в ChoiceHandler.cs, _directory.
    internal interface IRunnable
    {
        void Run();
    }
    internal class PlayTreasureChest : IRunnable
    {
        public void Run()
        {
            int[] chests = GoldGenerator(7);
            Console.WriteLine("Hello to game treasure-in-chest! we have 7 chests, in one of chests is gold, good luck!");
            int userChest = UserChest("your chest(1-7): ", 1, 7);
            bool goldInChest = CheckChest(chests, userChest);
            EndText(goldInChest);
        }
        private int[] GoldGenerator(int elementChests)
        {
            // +1 щоб уникнути індекс 0
            int[] golds = new int[elementChests + 1]; 
            double chance = 100.0 / elementChests;
            bool isOne = false;
            for (int i = 1; i <= elementChests; i++)
            {
                Random rnd = new Random();
                double roll = rnd.NextDouble() * 100;
                if (roll < chance && isOne == false)
                {
                    golds[i] = 1;
                    isOne = true;
                }
                else
                    golds[i] = 0;
                chance *= 2;
            }
            return golds;
        }
        private int UserChest(string text, int minElement, int maxElement)
        {
            while (true)
            {
                Console.Write(text);
                if (int.TryParse(Console.ReadLine(), out int selectedChest))
                {
                    if (selectedChest < minElement || selectedChest > maxElement)
                    {
                        Console.WriteLine($"Invalid chest, min chest: {minElement}, max chest: {maxElement}");
                        continue;
                    }
                    return selectedChest;
                }
                else
                    Console.WriteLine("Invalid input, write integer");
            }
        }
        private bool CheckChest(int[] array, int userChoice)
        {
            if (array[userChoice] == 1)
            {
                return true;
            }
            return false;
        }
        private void EndText(bool isGold)
        {
            if (isGold)
            {
                Console.WriteLine("Correct, You win!");
            }
            else
            {
                Console.WriteLine("You Lose!");
            }
        }
    }
    internal class PlaySnakeNumber : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Welcome to the Snake-Number game!");
            Console.WriteLine("Imagine a 3x3 grid with numbers from 1 to 9.");
            Console.WriteLine("Try to guess the correct steps of the snake. If you guess right — you move forward. If not — the snake eats you. Good luck!");
            int[] correctWay = LoopWay(5, 1, 10);
            ChoiceHandler("your number: ", 1, 9, correctWay, "Yes, you right!", "You have already walked like that!", "You lose! the correcr choice is:");
        }
        private static int[] LoopWay(int elements, int min, int max)
        {
            int[] array = new int[elements];
            int i = 0;
            Random rnd = new Random();
            int lastNum = -1;
            while (i < elements)
            {
                int secretNum = 0;
                if (i == 0)
                {
                    secretNum = rnd.Next(min, max);
                }
                else
                {
                    List<int> candidates = new List<int>();
                    // просто робимо 2 можливі числа
                    if (lastNum -1 >= min)
                    {
                        candidates.Add(lastNum - 1);
                    }
                    if (lastNum +1 < max)
                    {
                        candidates.Add(lastNum + 1);
                    }
                    // видаляємо вже використані елементи
                    candidates = candidates.Where(n => !array.Contains(n)).ToList();
                    // якщо кандидатів нема, виходимо
                    if (candidates.Count == 0)
                        break;

                    secretNum = candidates[rnd.Next(candidates.Count)];
                }
                array[i] = secretNum;
                lastNum = secretNum;
                i++;
            }
            return array;
        }
        private static void ChoiceHandler(string comText, int min, int max, int[] array, string succesText, string repeatText, string failText)
        {
            int lastChoice = -1;
            int stepIndex = 0;

            while (stepIndex < array.Length)
            {
                Console.Write(comText);
                if (int.TryParse(Console.ReadLine(), out int selectedNum))
                {
                    if (selectedNum < min || selectedNum > max)
                    {
                        Console.WriteLine($"Invalid number, min number: {min}, max number: {max}");
                        continue;
                    }

                    if (selectedNum == lastChoice)
                    {
                        Console.WriteLine(repeatText);
                        continue;
                    }

                    if (selectedNum == array[stepIndex])
                    {
                        Console.WriteLine(succesText);
                        lastChoice = selectedNum;
                        stepIndex++;
                    }
                    else
                    {
                        Console.WriteLine($"{failText} {array[stepIndex]}");
                        Console.WriteLine("Correct path was:");
                        foreach (int i in array)
                        {
                            Console.WriteLine(i);
                        }
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, write integer");
                }
            }
        }
    }
    internal class WhoFaster : IRunnable
    {
        public void Run()
        {
            string[] runners = CreateRunners(6, "Runner");
            double[] records = CreateRecords(6);
            TextAll(runners, records);
            TheFastest(runners, records);
        }
        private static string[] CreateRunners(int elements, string name)
        {
            string[] runners = new string[elements];
            for (int i = 0; i < elements; i++)
            {
                runners[i] = $"{name} {i + 1}";
            }
            return runners;
        }
        private static double[] CreateRecords(int elements)
        {
            double[] records = new double[elements];
            Random rnd = new Random();
            for (int i = 0; i < elements; i++)
            {
                double secretRecord = rnd.NextDouble() * 20;
                records[i] = secretRecord;
            }
            return records;
        }
        private static void TextAll(string[] stringArray, double[] doubleArray)
        {
            for(int i = 0; i < stringArray.Length; i++)
            {
                Console.WriteLine($"{stringArray[i]}: {doubleArray[i]} seconds");
            }
        }
        private static void TheFastest(string[] stringArray, double[] doubleArray)
        {
            double bestRecord = 0;
            int currentIndex = -1;
            int i = 0;
            while (i < stringArray.Length)
            {
                if (doubleArray[i] < bestRecord)
                {
                    bestRecord = doubleArray[i];
                    currentIndex++;
                }
                i++;
            }
            Console.WriteLine($"The best runner was {stringArray[currentIndex]}, record: {bestRecord}");
        }
    }
    internal class HomeWork : IRunnable
    {
        public void Run()
        {
            int biggestRate = LoopSongs();
            Console.WriteLine($"The 🎵 song with the biggest Rate is {_songs[biggestRate]}! ⭐ Rate: {_ratings[biggestRate]}!!");
        }
        private static int LoopSongs()
        {

            int biggestRateIndex = 0;
            int biggestRate = _ratings[biggestRateIndex];
            for (int i = 0; i < _songs.Length; i++)
            {
                Console.WriteLine($"🎵 Song: {_songs[i]}, | ⭐ Rate: {_ratings[i]}");
                if (_ratings[i] > biggestRate)
                {
                    biggestRateIndex = i;
                }
            }
            return biggestRateIndex;
        }
        // тут було б краще використовувати словник, але домашнє завдання по масивам
        private static readonly string[] _songs = new string[5]
        {
            "Song1", "Song2", "Song3", "Song4", "Song5"
        };
        private static readonly int[] _ratings = new int[5]
        {
            3, 4, 2, 5, 1
        };
    }
}
