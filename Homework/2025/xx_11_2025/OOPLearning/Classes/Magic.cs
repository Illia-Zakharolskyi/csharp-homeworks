using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLearning.Classes;

internal class Magic
{
    internal void CastSpell(string spellName)
    {
        Console.WriteLine($"використано заклинання: {spellName}");
    }
    internal void UsePotion(string potionType)
    {
        Console.WriteLine($"використано зілля: {potionType}");
    }
}
