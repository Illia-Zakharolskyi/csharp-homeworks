using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tasks_05_09_2025
{
    internal class Menu
    {
        internal static void StartMenu()
        {
            Console.WriteLine("Task of available operation:");
            LoopMenu();
        }
        private static void LoopMenu()
        {
            for (int i = 0; i < _availableActions.Count; i++)
            {
                Console.WriteLine($"{i}. {_availableActions[i]}");
            }
        }
        private static readonly List<string> _availableActions = new List<string>
        {
            "Exit from program", "Game treasure-in-chest", "Game snake number", "Who faster", "My home work"
        };
    }
}
