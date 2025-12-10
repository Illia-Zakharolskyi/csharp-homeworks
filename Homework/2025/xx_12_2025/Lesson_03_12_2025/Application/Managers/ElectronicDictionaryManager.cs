// .NET9.0
using System;
using System.ComponentModel.DataAnnotations;
using Lesson_03_12_2025.Application.Helpers.Dictionaries;


// Application
using Lesson_03_12_2025.Application.Utilities.Validators;

// Domain
using Lesson_03_12_2025.Domain.Models;

namespace Lesson_03_12_2025.Application.Managers;

internal class ElectronicDictionaryManager
{
    private readonly List<ElectronicDictionaryEntry>? _entries;
    private bool _isFileChanged = false;

    private void MarkAsNeedToSaveFile() => _isFileChanged = true;
    internal bool NeedToSaveFile() => _isFileChanged;
    internal void MarkFileAsSaved() => _isFileChanged = false;

    internal ElectronicDictionaryManager(List<ElectronicDictionaryEntry> entries)
    {
        _entries = entries ?? new List<ElectronicDictionaryEntry>();
    }

    internal void AddEntry()
    {
        string word = StringValidator.ReadString("Введи слово: ", "Некоректне значення для слова");
        string definition = StringValidator.ReadString("Введи пояснення: ", "Некоректне значення для пояснення");

        _entries!.Add(new ElectronicDictionaryEntry(word, definition));
        
        Console.WriteLine("Слово + пояснення добавлено!");
        MarkAsNeedToSaveFile();
    }
    internal void RemoveEntry()
    {
        string word = StringValidator.ReadString("Введи слово для видалення: ", "Некоректне значення для слова");

        var entry = _entries!.FirstOrDefault(e => e.Word.Equals(word, StringComparison.OrdinalIgnoreCase));
        if (entry != null)
        {
            _entries!.Remove(entry);
            Console.WriteLine("Слово видалено!");
            MarkAsNeedToSaveFile();
            return;
        }

        Console.WriteLine("Слово не найдено");
    }
    internal void UpdateEntry()
    {
        string word = StringValidator.ReadString("Введи слово для обновлення пояснення: ", "Некоректне значення для слова");
        string newDefinition = StringValidator.ReadString("Введи нове пояснення: ", "Некоректне значення для пояснення");

        var entry = _entries!.FirstOrDefault(e => e.Word.Equals(word, StringComparison.OrdinalIgnoreCase));
        if (entry != null)
        {
            entry.Definition = newDefinition;
            Console.WriteLine("Пояснення обновлено!");
            MarkAsNeedToSaveFile();
            return;
        }

        Console.WriteLine("Слово не найдено");
    }
    internal void SearchEntry()
    {
        string word = StringValidator.ReadString("Введи слово для пошуку: ", "Некоректне значення для слова");

        if (_entries!.Count == 0)
        {
            Console.WriteLine("Словник порожній");
            return;
        }

        if (!_entries.Any(e => e.Word.Equals(word, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Слово не найдено");
            return;
        }

        var entry = _entries.First(e => e.Word.Equals(word, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"Пояснення для слова '{entry.Word}': {entry.Definition}");
    }
    internal void ShowAllEntries()
    {
        if (_entries!.Count == 0)
        {
            Console.WriteLine("Файл пустий та нема чого показувати");
            return;
        }

        Console.WriteLine($"{"Слово", -5} | Значення");

        foreach (var entry in _entries)
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"{entry.Word, -5} | {entry.Definition}");
        }

        Console.WriteLine(new string('-', 30));
    }
    internal List<ElectronicDictionaryEntry> GetAllEntries()
    {
        return _entries!;
    }
}