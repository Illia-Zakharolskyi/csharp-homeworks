using System;
using Tasks_01_10_2025.ProgramHeart.Utilities.Alphabets;

namespace Tasks_01_10_2025.ProgramHeart.Utilities.Dictionaries;

internal static class PasswordGeneratorDict
{
    internal static readonly Dictionary<int, (string description, string alphabet)> thisDict = new()
    {
        { 1, ("English", LatinAlphabets.Englishalphabet) },
        { 2, ("Українська",  CyrillicAlphabets.UkrainianAlphabet) }
    };
}
