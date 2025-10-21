using StrangeTasks_15_10_2025.ProgramHeart.Core.Interfaces;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Collections.Dictionaries.ProgramsDicts;
using System;

namespace StrangeTasks_15_10_2025.Programs;

internal class ProgramerQuest : IRunnable
{
    public void Run()
    {
        Random rnd = new Random();
        string spell = "";
        double mania = 250.00;

        Console.WriteLine($"Мана до закляття: {mania}");

        GenerateNewSpell(rnd, out spell);
        UpdateManiaAfterSpellsDamage(ref mania, spell);

        Console.WriteLine($"Мана після закляття: {mania:F2}");
    }
    private static void GenerateNewSpell(Random rnd, out string newSpell)
    {
        List<string> spells = new List<string>(ProgramerQuestDicts.spellDamages.Keys);

        newSpell = spells[rnd.Next(spells.Count)];
    }
    private static void UpdateManiaAfterSpellsDamage(ref double mania, string spell)
    {
        mania = mania - ProgramerQuestDicts.spellDamages[spell];
    }
}
