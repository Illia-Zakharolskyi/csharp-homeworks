using MagicCrystal.CrystalHeart.Helpers.Collections.List;
using System;

namespace MagicCrystal.CrystalHeart.Helpers.Collections.Dictionaries;

internal static class CrystaDicts
{
    internal static readonly Dictionary<string, List<string>> crystalMods = new()
    {
        { "нейтральний", PossibleAnswers.neutralAnswers },
        { "жартівливий", PossibleAnswers.jokingAnswers },
        { "злий", PossibleAnswers.angryAnswers }
    };
}
