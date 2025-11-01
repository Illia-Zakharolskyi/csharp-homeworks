using MagicCrystal.CrystalHeart.Helpers.Collections.Dictionaries;
using MagicCrystal.CrystalHeart.Helpers.Factories;
using MagicCrystal.UserProfile;
using System;

namespace MagicCrystal.PresentationLayer;

internal static class UserInputHandler
{
    internal static void StartHandle(User user)
    {
        Console.WriteLine("Привіт! ти можеш задати питання, та я відповім на нього!*");
        Console.WriteLine("*Це не ШІ, відповідь випадково генерується");
        Console.WriteLine("ще: ви можете ввести команду 'вихід' для того щоб вийти, та 'змінити стиль' для того щоб змінти стиль відповіді кристала!");
        Console.Write("> ");

        string? input = Console.ReadLine();

        var availablePrograms = CommandFactory.Create(user);
        if (availablePrograms.ContainsKey(input ?? string.Empty)) availablePrograms[input!].Execute();
    }
}
