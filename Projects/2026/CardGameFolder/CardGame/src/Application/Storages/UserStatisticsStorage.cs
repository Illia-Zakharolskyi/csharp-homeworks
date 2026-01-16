// .Net 9.0
// Data
using CardGame.Data.UserProfile;
using System;
using System.Text.Json;

namespace CardGame.src.Application.Storages;

internal class UserStatisticsStorage
{
    private readonly string? _path;

    public UserStatisticsStorage()
    {
        _path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "CardGame",
            "UserStatistics.json"
        );
    }

    public void Save(UserStatistics userStatistics)
    {
        if (_path == null)
        {
            Console.WriteLine("Шлях до збереження не встановлено.");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(_path)!);

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(userStatistics, options);

        try
        {
            File.WriteAllText(_path, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при збереженні файлу: {ex.Message}");
        }
    }

    public UserStatistics Load()
    {
        if (_path == null)
        {
            Console.WriteLine("Шлях до завантаження не встановлено.");
            return new UserStatistics();
        }

        if (!File.Exists(_path)) return new UserStatistics();

        string json;
        try
        {
            json = File.ReadAllText(_path);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при завантаженні файлу: {ex.Message}");
            return new UserStatistics();
        }

        UserStatistics res;
        try
        {
            res = JsonSerializer.Deserialize<UserStatistics>(json) ?? new UserStatistics();
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Помилка при розборі JSON: {ex.Message}");
            return new UserStatistics();
        }

        return res;
    }
}