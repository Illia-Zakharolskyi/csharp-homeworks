using Homework_Lists_Dictionaries.ProgramHeart.Core.Interfaces;
using System;

namespace Homework_Lists_Dictionaries.Programs.Collections.Lists;

internal class ListCheckElement : IRunnable
{
    public void Run()
    {
        List<string> userElements = userAnswers(
            "Hello to very mini-game! here you need to write fruits/vegetables/berries, and when you stop, we look at your elements, and compare with our list!",
            "your option: ", " do you want to continue? y/n: "
            );
        List<string> identialProducts = CheckElements(_productsList, userElements);
        TextProducts(identialProducts);
    }
    private static List<string> userAnswers(string welcomeText, string optionText, string continueText)
    {
        Console.WriteLine(welcomeText);
        List<string> answers = new List<string>();

        while (true)
        {
            Console.Write(optionText);
            string answerElement = Console.ReadLine().ToLower().Trim();

            if (!string.IsNullOrWhiteSpace(answerElement))
                answers.Add(answerElement);

            bool wantsToContinue = AskToContinue(continueText);
            if (!wantsToContinue)
                break;
        }

        return answers;
    }
    private static bool AskToContinue(string text)
    {
        while (true)
        {
            Console.Write(text);
            string answer = Console.ReadLine().Trim().ToLower();

            if (answer == "y" || answer == "yes")
                return true;
            else if (answer == "n" || answer == "no")
                return false;
            else
                Console.WriteLine("Invalid answer. Please enter 'y' or 'n'.");
        }
    }

    private static List<string> CheckElements(List<string> products, List<string> elements)
    {
        List<string> repeats = new List<string>();
        List<string> identicalElements = new List<string>();
        foreach (string product in elements)
        {
            if (products.Contains(product) && !repeats.Contains(product))
            {
                identicalElements.Add(product);
                repeats.Add(product);
            }
        }
        return identicalElements;
    }
    private static void TextProducts(List<string> identicalProducts)
    {
        // тут я перевірив список на пустоту
        if (identicalProducts.Count == 0)
        {
            Console.WriteLine("No idential products found.");
            return;
        }

        // тут я відсортував список (по алфавіту)
        identicalProducts.Sort();

        Console.WriteLine("Idential products are:");

        foreach (string product in identicalProducts)
        {
            Console.WriteLine(product);
        }
    }
    private static readonly List<string> _productsList = new List<string>
    {
        "apple", "banana", "orange", "grapes", "watermelon", "strawberry", "blueberry", "raspberry", "mango", "pineapple",
        "peach", "cherry", "pear", "plum", "kiwi", "coconut", "lemon", "lime", "apricot", "fig", "pomegranate", "potato"
    };
}
