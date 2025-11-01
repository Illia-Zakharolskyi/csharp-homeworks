using MagicCrystal.CrystalHeart.Core;
using MagicCrystal.CrytsalInfo.Commands;
using MagicCrystal.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCrystal.CrystalHeart.Helpers.Factories;

internal static class CommandFactory
{
    internal static Dictionary<string, ICommand> Create(User user)
    {
        return new Dictionary<string, ICommand>()
        {
            { "вихід", new ExitCommand() },
            { "змінити стиль", new ChangeCrystalModCommand { user = user } },
        };
    }
}
