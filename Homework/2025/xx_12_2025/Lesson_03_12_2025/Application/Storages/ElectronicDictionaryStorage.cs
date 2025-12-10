// .NET9.0
using Lesson_03_12_2025.Domain.Models;
using System;

namespace Lesson_03_12_2025.Application.Storages;

internal class ElectronicDictionaryStorage
{
    private readonly string _filePath;

    internal ElectronicDictionaryStorage(string filePath)
    {
        _filePath = filePath;
    }

    internal List<ElectronicDictionaryEntry> LoadFile()
    {
        var entries = new List<ElectronicDictionaryEntry>();

        try
        {
            if (!File.Exists(_filePath))
            {
                return entries;
            }

            foreach (var line in File.ReadAllLines(_filePath))
            {
                var parts = line.Split('|');
                entries.Add(new ElectronicDictionaryEntry(parts[0], parts[1]));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при загрузкі файлу: {ex.Message}");
        }

        return entries;
    }
    internal void SaveFile(List<ElectronicDictionaryEntry> entries)
    {
        try
        {
            var lines = new List<string>();
            foreach (var entry in entries)
            {
                lines.Add($"{entry.Word}|{entry.Definition}");
            }

            File.WriteAllLines(_filePath, lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при завантажуванні: {ex.Message}");
        }
    }
}
