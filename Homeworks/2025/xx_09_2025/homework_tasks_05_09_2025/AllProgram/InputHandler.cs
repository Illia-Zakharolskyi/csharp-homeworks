using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tasks_05_09_2025
{
    internal class ChoiceHandler
    {
        internal static void StartHandler()
        {
            int userAction = CheckCorrectInput();
            CheckInDirectory(userAction);
        }
        private static int CheckCorrectInput()
        {
            while (true)
            {
                Console.Write("your operation: ");

                if (int.TryParse(Console.ReadLine(), out int selectedOperation))
                    return selectedOperation;

                Console.WriteLine("Invalid input, enter a number(integer)");
            }
        }
        private static void CheckInDirectory(int userAction)
        {
            if (userAction == 0)
            {
                UserExit.Exit();
            }
            Console.Clear();
            if (_directory.TryGetValue(userAction, out var action))
                action.Run();
            else
                Console.WriteLine("Invalid operation");
        }
        // IRunnable це інтерфейс в PossiblePrograms.cs
        private static readonly Dictionary<int, IRunnable> _directory = new Dictionary<int, IRunnable>
        {
            { 1, new PlayTreasureChest() },
            { 2, new PlaySnakeNumber() },
            { 3, new WhoFaster() },
            { 4, new HomeWork() }
        };
    }
}
