// .NET9.0
using System;

// Application
using Lesson_03_12_2025.Application.Managers;

namespace Lesson_03_12_2025.Application.Helpers.Dictionaries;

internal class MainDicts
{
    private readonly ElectronicDictionaryManager _dictionaryManager;

    internal MainDicts(ElectronicDictionaryManager dictionaryManager)
    {
        _dictionaryManager = dictionaryManager;
    }

    internal Dictionary<int, (string description, Action action)> GetAvailableActions()
    {
        return new Dictionary<int, (string description, Action action)>()
        {
            { 0, ("Вийти з програми", () => Environment.Exit(0)) },
            { 1, ("Додати слово та пояснення", () => _dictionaryManager.AddEntry()) },
            { 2, ("Видалити слово", () => _dictionaryManager.RemoveEntry()) },
            { 3, ("Оновити пояснення до слова", () => _dictionaryManager.UpdateEntry()) },
            { 4, ("знайти пояснення для слова", () => _dictionaryManager.SearchEntry()) },
            { 5, ("показати всі слова зі значенями", () => _dictionaryManager.ShowAllEntries()) },
        };
    }
}
