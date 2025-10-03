using Homework_Lists_Dictionaries.ProgramHeart.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Lists_Dictionaries.Programs.Collections.Lists;

internal class ListFibonacciNumbers : IRunnable
{
    public void Run()
    {
        List<int> fibonacciNumbers = FibonacciGenerator(10, 1, 11);
        Console.WriteLine("Fibonacci numbers:");
        TextFibonacci(fibonacciNumbers);
    }
    private static List<int> FibonacciGenerator(int elements, int baseMin, int baseMax)
    {
        List<int> fibonacciNumbers = new List<int>();
        List<int> usedNumbers = new List<int>();

        Random rnd = new Random();

        while (usedNumbers.Count < 2)
        {
            int secretNum = rnd.Next(baseMin, baseMax);

            if (!usedNumbers.Contains(secretNum))
                usedNumbers.Add(secretNum);
        }

        for (int i = 2; i < elements; i++)
        {
            int nextNum = usedNumbers[0] + usedNumbers[1];

            fibonacciNumbers.Add(nextNum);

            usedNumbers[0] = usedNumbers[1];
            usedNumbers[1] = nextNum;
        }

        return fibonacciNumbers;
    }
    private static void TextFibonacci(List<int> numbers)
    {
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
