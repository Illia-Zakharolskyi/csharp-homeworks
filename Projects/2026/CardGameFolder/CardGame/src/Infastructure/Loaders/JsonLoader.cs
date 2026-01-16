// .Net 9.0
using System;
using System.Text.Json;

// Domain
using CardGame.src.Domain.Models;

namespace CardGame.src.Infastructure.Loaders;

internal class JsonLoader
{
    internal List<T> Load<T>(string filePath)
        where T : class
    {
        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
        {
            throw new ArgumentException("Не коректний шлях к файлу", nameof(filePath));
        }

        string json = File.ReadAllText(filePath);
        List<T>? items = JsonSerializer.Deserialize<List<T>>(json);

        return items ?? throw new ArgumentException($"некоректий формат данних для створення {typeof(T).Name}: {filePath}");
    }
}