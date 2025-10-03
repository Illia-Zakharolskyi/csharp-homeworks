using Homework_Lists_Dictionaries.ProgramHeart.Core.Interfaces;
using System;

namespace Homework_Lists_Dictionaries.Programs.Collections.Lists;

internal class ListSumOfNumbers : IRunnable
{
    public void Run()
    {
        int result = ValueOfList(_numbers);
        TextValue(result);
    }
    private static int ValueOfList(List<int> list)
    {
        int sum = 0;
        foreach (int element in list)
        {
            sum += element;
        }
        return sum;
    }
    private static void TextValue(int value)
    {
        Console.WriteLine($"Value of the all numbers in list is: {value}");
    }
    private static readonly List<int> _numbers = new List<int>
    {
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10
    };
}