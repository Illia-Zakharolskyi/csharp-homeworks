// .NET9.0
using System;
using System.IO;

// Application
using Lesson_03_12_2025.Application.Managers;
using Lesson_03_12_2025.Application.Storages;
using Lesson_03_12_2025.Application.Helpers.Dictionaries;

namespace Lesson_03_12_2025.UI;

internal static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        string filePath = "electronic_dictionary.txt";

        var storage = new ElectronicDictionaryStorage(filePath);
        var entries = storage.LoadFile();
        var manager = new ElectronicDictionaryManager(entries);
        var mainDicts = new MainDicts(manager);
        var mainHandler = new MainHandler(mainDicts);

        while (true)
        {
            Console.Clear();
            MainMenu.Display(mainDicts.GetAvailableActions());
            mainHandler.HandleUserInput();

            if (manager.NeedToSaveFile())
            {
                storage.SaveFile(entries);
                manager.MarkFileAsSaved();
            }

            Console.ReadKey();
        }
    }
}