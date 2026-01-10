// .Net 9.0
using System;

// Data
using CardGame.Data.UserProfile;

// Domain
using CardGame.src.Domain.Models;

// Infastructure
using CardGame.src.Infastructure.DTO;
using CardGame.src.Infastructure.Loaders;
using CardGame.src.Infastructure.Resolvers;

namespace CardGame.src.Application.Factories;

internal class CharacterFactory
{
    private static readonly JsonLoader _loader = new JsonLoader();
    private static readonly PathResolver _resolver = new PathResolver();

    internal Character? CreateEnemy(string relativeCharacterListPath)
    {
        if (string.IsNullOrWhiteSpace(relativeCharacterListPath)) return null;

        string fullCharacterListPath = _resolver.ResolveRelativePathToFullPath(relativeCharacterListPath);

        List<CharacterInfo> characterPaths = _loader.Load<CharacterInfo>(fullCharacterListPath);
        Dictionary<string, CharacterInfo> characterMap = characterPaths.ToDictionary(c => c.Name, c => c);

        string enemyName = characterMap.Keys.ElementAt(new Random().Next(characterMap.Count));

        string fullCharacterStatsPath = _resolver.ResolveRelativePathToFullPath(characterMap[enemyName].RelativeCharacterCharacteristicsFilePath);
        string fullCharacterCardsPath = _resolver.ResolveRelativePathToFullPath(characterMap[enemyName].RelativeCardsFilePath);

        List<CharacterStats> stats = _loader.Load<CharacterStats>(fullCharacterStatsPath);
        List<Card> cards = _loader.Load<Card>(fullCharacterCardsPath);

        return new Character(
            name: stats[0].Name,
            maxHealth: stats[0].MaxHealth,
            maxMana: stats[0].MaxMana,
            isPlayer: false,
            deck: cards
        );
    }
    internal Character? CreatePlayer(string relativeCharacterListPath, UserChoices choices)
    {
        if (string.IsNullOrWhiteSpace(relativeCharacterListPath) || choices.SelectedCharacterName == null) return null;

        List<CharacterInfo> characterPaths = _loader.Load<CharacterInfo>(_resolver.ResolveRelativePathToFullPath(relativeCharacterListPath));
        Dictionary<string, CharacterInfo> characterMap = characterPaths.ToDictionary(c => c.Name, c => c);
        List<CharacterStats> stats = _loader.Load<CharacterStats>(_resolver.ResolveRelativePathToFullPath(characterMap[choices.SelectedCharacterName].RelativeCharacterCharacteristicsFilePath));
        List<Card> cards = _loader.Load<Card>(_resolver.ResolveRelativePathToFullPath(characterMap[choices.SelectedCharacterName].RelativeCardsFilePath));

        return new Character(
            name: stats[0].Name,
            maxHealth: stats[0].MaxHealth,
            maxMana: stats[0].MaxMana,
            isPlayer: true,
            deck: cards
        );
    }
}