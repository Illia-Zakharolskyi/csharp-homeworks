using MagicCrystal.CrystalHeart.Core;
using MagicCrystal.CrystalHeart.Utilities.Validators;
using MagicCrystal.CrystalHeart.Helpers.Collections.Dictionaries;
using MagicCrystal.UserProfile;
using System;

namespace MagicCrystal.CrytsalInfo.Commands;

internal class ChangeCrystalModCommand : ICommand
{
    internal required User user { get; init; }

    public void Execute()
    {
        string newMod = StringValidator.ReadInput("введи новий стиль жарту(нейтральний, жартівливий, злий): ", "Некоректний ввід", CrystaDicts.crystalMods.Keys.ToList(), "такого стилю нажаль ще нема");
        user.SelectedCrystalMode = newMod.ToLower();
    }
}
