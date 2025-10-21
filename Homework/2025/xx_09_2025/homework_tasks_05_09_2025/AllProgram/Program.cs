using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tasks_05_09_2025
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Menu.StartMenu();
                    ChoiceHandler.StartHandler();
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error! {ex.Message}");
                }
            }
        }
    }
}

