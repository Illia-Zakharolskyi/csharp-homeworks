using System;
namespace StrangeTasks_15_10_2025.ProgramHeart.Utilities.Helpers.CollectionHelpers;

internal static class ListHelper
{
    internal static void DisplayList<T>(string message, List<T> list, bool inLine = true, string separator = ", ")
    {
        Console.WriteLine(message);

        if (list == null || list.Count == 0)
        {
            Console.WriteLine("пустий список");
            return;
        }

        if (inLine)
        {
            string joined = string.Join(separator, list);
            Console.WriteLine(joined);
        }
        else
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
