using System;
using System.Globalization;
using Tasks_24_09_2025.ProgramHeart.Interfaces;

namespace Tasks_24_09_2025.Programs.Data_Types.String;

internal class StringGuessWord : IRunnable
{
    public void Run()
    {
        Console.WriteLine("welcome to game-guess-word! it's game, that not stop until the moment when you guess this word) good luck!");
        while (true)
        {
            string word = WordGuesser(0, words);
            WordWithStars(word);
            string guess = UserInput("your guess: ");
            bool isGuessed = InputCheck(word, guess);
            if (isGuessed)
            {
                Console.WriteLine($"You guessed the word! word: {word}");
                break;
            }
            else
            {
                Console.WriteLine("Try better! (not guess)");
                continue;
            }
        }
    }
    private static string WordGuesser(int min, List<string> list)
    {
        Random rnd = new Random();

        return list[rnd.Next(min, list.Count)];
    }
    private static void WordWithStars(string word)
    {
        string stars = Stars(word);
        Console.WriteLine($"word: {word[0]}{stars}{word[^1]}");
    }
    private static string Stars(string word)
    {
        string stars = "";

        // якщо слово з 2 літер буде помилка, краще так
        if (word.Length < 3)
        {
            return word;
        }

        //  -2 томущо перший та останній індекс в нас вже є
        for (int i = 0; i < word.Length - 2; i++)
        {
            stars += "*";
        }

        return stars;
    }
    private static string UserInput(string welcomeText)
    {
        while (true)
        {
            Console.Write(welcomeText);
            string guess = Console.ReadLine();

            if (guess != null)
            {
                // це штука яка робить першу літеру великой
                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                return textInfo.ToTitleCase(guess);
            }
            else
                Console.WriteLine("Invalid input, input need to be longer than 0 characters");
            continue;
        }
    }
    private static bool InputCheck(string word, string text)
    {
        if (word == text)
            return true;
        else
            return false;
    }

    private static readonly List<string> words = new()
    {
        "Computer", "Apple", "Phone", "Intellect", "Select", "Benchmark"
    };
}
