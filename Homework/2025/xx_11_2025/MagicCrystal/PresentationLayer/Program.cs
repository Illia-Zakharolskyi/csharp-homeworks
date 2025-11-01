using System;
using MagicCrystal.CrystalHeart.Helpers.Collections.List;
using MagicCrystal.CrystalHeart.Helpers.Collections.Dictionaries;
using MagicCrystal.CrytsalInfo;
using MagicCrystal.UserProfile;

namespace MagicCrystal.PresentationLayer;

internal class Program_
{
    internal static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        User user = new User();

        while (true)
        {
            Console.ResetColor();
            Console.Clear();

            Random rnd = new Random();

            Crystal.Draw();
            Console.WriteLine(new string('-', Console.WindowWidth));
            UserInputHandler.StartHandle(user);
            Crystal.GiveAnswer(rnd, CrystaDicts.crystalMods[user.SelectedCrystalMode]);

            Console.ReadLine();
        }
    }
}