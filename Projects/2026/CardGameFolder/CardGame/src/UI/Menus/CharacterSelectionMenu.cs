// .Net 9.0
using System;

// Data
using CardGame.Data.UserProfile;

// Application
using CardGame.src.Application.Utilities.Validators;

// Domain
using CardGame.src.Domain.Models;

// Infastructure
using CardGame.src.Infastructure.DTO;
using CardGame.src.Infastructure.Loaders;
using CardGame.src.Infastructure.Storages;

// UI
using CardGame.src.UI.Models;
using CardGame.src.UI.Dispatchers;
using CardGame.src.UI.Interfaces;

namespace CardGame.src.UI.Menus;

internal class CharacterSelectionMenu : Menu, IMenu
{
    private JsonLoader _loader = new JsonLoader();
    internal CharacterSelectionMenu(MenuDispatcher dispatcher, UserChoices userChoices, UserChoicesStorage userChoicesStorage) : base(dispatcher, userChoices, userChoicesStorage) 
    { 
        
    }

    public void Display()
    {
        base.Display(GetActionMap());
    }

    public override Dictionary<int, (string description, Action action)> GetActionMap()
    {
        return new Dictionary<int, (string description, Action action)>()
        {
            { 0, ("назад", () => _dispatcher.PopMenu()) },
            { 1, ("вибрати персонажа", () => ChooseCharacter()) }
        };
    }

    private void ChooseCharacter()
    {
        Console.Clear();

        string fullCharacterListPath = Path.Combine(AppContext.BaseDirectory, "Resources/JsonFiles/Lists/CharactersList.json");

        List<CharacterInfo> characterPaths = _loader.Load<CharacterInfo>(fullCharacterListPath);
        Dictionary<string, CharacterInfo> characterMap = characterPaths.ToDictionary(c => c.Name, c => c);

        Console.WriteLine($"{"Персонаж", -10} | {"номер"}");
        Console.WriteLine(new string('-', 40));

        foreach (var key in characterMap.Keys.Select((name, index) => (name, index)))
        {
            Console.WriteLine($"{key.name, -10} | {key.index + 1}");
        }

        Console.WriteLine(new string('-', 40));

        int userChoice = InetegerValidator.ReadInteger(
            promptMessage: "Введіть номер персонажа(якого бажаєте вибрати): ",
            invalidInputMessage: "Некоректне введення, спробуйте ціле число.",
            allowedAnswers: Enumerable.Range(1, characterMap.Count).ToList(),
            invalidChoiceMessage: "Такого номеру немає, введіть коректний номер."
        );

        string selectedCharacterName = characterMap.Keys.ElementAt(userChoice - 1);

        _userChoices.SelectedCharacterName = selectedCharacterName;
        _userChoicesStorage.Save(_userChoices);

        Console.WriteLine($"Ви вибрали персонажа: {selectedCharacterName}");
        Console.ReadKey(true);
        return;
    }
}