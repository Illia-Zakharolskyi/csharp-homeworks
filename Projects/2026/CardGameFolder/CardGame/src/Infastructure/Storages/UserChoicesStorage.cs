// .Net 9.0
using System;
using System.Text.Json;

// Data
using CardGame.Data.UserProfile;
namespace CardGame.src.Infastructure.Storages; 

internal class UserChoicesStorage 
{
    private readonly string? _path;
    
    public UserChoicesStorage()
    {
        _path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "CardGame",
            "UserChoices.json"
        );
    }

    public void Save(UserChoices choices) 
    {
        if (_path == null)
        {
            Console.WriteLine("Шлях до збереження не встановлено.");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(_path)!);

        var options = new JsonSerializerOptions { WriteIndented = true }; 
        string json = JsonSerializer.Serialize(choices, options); 

        try 
        { 
            File.WriteAllText(_path, json); 
        } 
        catch (Exception ex) 
        { 
            Console.WriteLine($"Помилка при збереженні файлу: {ex.Message}");
        }
    } 
    public UserChoices Load() 
    { 
        if (_path == null)
        {
            Console.WriteLine("Шлях до завантаження не встановлено.");
            return new UserChoices();
        }

        if (!File.Exists(_path)) return new UserChoices();

        string json;
        try
        {
            json = File.ReadAllText(_path);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при завантаженні файлу: {ex.Message}");
            return new UserChoices();
        }

        UserChoices res;
        try 
        { 
            res = JsonSerializer.Deserialize<UserChoices>(json) ?? new UserChoices(); 
        } 
        catch (JsonException ex) 
        { 
            Console.WriteLine($"Помилка при розборі JSON: {ex.Message}");
            return new UserChoices();
        }

        return res;
    } 
}