using Homework_Lists_Dictionaries.ProgramHeart.Core.Interfaces;
using System;

namespace Homework_Lists_Dictionaries.Programs.Collections.Lists;

internal class ListEvenNumbers : IRunnable
{
    public void Run()
    {
        List<int> numbers = ListMaker(10, 1, 101);
        List<int> evenNumbers = EvenList(numbers);
        TextEvenNumbers(evenNumbers);
    }
    private static List<int> ListMaker(int elements, int min, int max)
    {
        HashSet<int> generatedNumbers = new HashSet<int>();
        Random rnd = new Random();
        while (generatedNumbers.Count < elements)
        {
            generatedNumbers.Add(rnd.Next(min, max));
        }
        return generatedNumbers.ToList();
    }
    private static List<int> EvenList(List<int> numbers)
    {
        List<int> evenNumbers = new List<int>();
        foreach (int number in numbers)
        {
            if (number % 2 == 0)
                evenNumbers.Add(number);
        }
        return evenNumbers.ToList();
    }
    private static void TextEvenNumbers(List<int> numbers)
    {
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
