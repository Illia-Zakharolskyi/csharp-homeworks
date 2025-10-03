using Homework_Lists_Dictionaries.ProgramHeart.Core.Interfaces;
using System;
using System.Globalization;

namespace Homework_Lists_Dictionaries.Programs.Collections.Directionaries;

internal class DicPhoneBook : IRunnable
{
    public void Run()
    {
        PhoneBookHelper.listContacts.Clear();
        PhoneBookHelper.isRunning = true;

        Console.WriteLine("It's phone book, but it's can be used also how todo-list and so on");

        while (PhoneBookHelper.isRunning)
        {
            Console.Clear();

            PhoneBookManager.MenuDisplay();
            PhoneBookManager.HandlerStart();

            Console.WriteLine("Operation succed(or no)! click some button to continue...");
            Console.ReadKey();
        }
    }
}

internal static class PhoneBookManager
{
    internal static void MenuDisplay()
    {
        TextForMenu();
        Console.WriteLine(new string('-', 30));
        LoopText();
        Console.WriteLine(new string('-', 30));
    }
    internal static void HandlerStart()
    {
        while (true)
        {
            int selectedID = ReadInput();
            bool found = CheckInDictionary(selectedID);
            if (found)
            {
                break;
            }
            else
            {
                continue;
            }
        }
    }
    internal static void ProgramExit()
    {
        Console.WriteLine("click any button to exit...");
        Console.ReadKey(true);
        PhoneBookHelper.isRunning = false;
    }
    // === Ці методи для меню === \\
    private static void TextForMenu()
    {
        string text = "ID";
        Console.WriteLine($"{text.PadRight(5)} | Description");
    }
    private static void LoopText()
    {
        foreach (var item in PhoneBookHelper.phoneDictionary)
        {
            Console.WriteLine($"{item.Key.ToString().PadRight(5)} | {item.Value.description}");
        }
    }
    // === Ці методи для обробника === \\
    private static int ReadInput()
    {
        while (true)
        {
            Console.Write("your option by ID: ");
            if (int.TryParse(Console.ReadLine(), out int selectedID))
            {
                return selectedID;
            }
            else
            {
                Console.WriteLine("Invalid input, try integer");
            }
        }
    }
    private static bool CheckInDictionary(int ID)
    {
        if (PhoneBookHelper.phoneDictionary.ContainsKey(ID))
        {
            Console.Clear();
            PhoneBookHelper.phoneDictionary[ID].action();
            return true;
        }
        else
        {
            Console.WriteLine("Invalid ID");
            return false;
        }
    }
}

internal static class PhoneBookOperations
{
    internal static void Add()
    {
        while (true)
        {
            Console.Write("what's name: ");
            string name = Console.ReadLine();
            if (name != null && name != string.Empty)
            {
                Console.Write("his/her nummer: ");
                string nummer = Console.ReadLine();
                if (nummer != null && nummer != string.Empty)
                {
                    PhoneBookHelper.listContacts.Add(name, nummer);
                    break;
                }
                else
                {
                    Console.WriteLine("nummer need to be longer than 0 characters");
                }
            }
            else
            {
                Console.WriteLine("Invalid input, name need to be bigger than 0 characters");
            }
        }
    }
    internal static void Remove()
    {
        while (true)
        {
            if (PhoneBookHelper.listContacts.Count == 0)
            {
                Console.WriteLine("empty contacts");
                break;
            }

            Console.Write("enter name/nummer to remove: ");

            string nameNummer = Console.ReadLine();

            if (nameNummer != null && nameNummer != string.Empty)
            {

                if (PhoneBookHelper.listContacts.ContainsKey(nameNummer))
                {
                    PhoneBookHelper.listContacts.Remove(nameNummer);

                    break;
                }

                else if (PhoneBookHelper.listContacts.ContainsValue(nameNummer))
                {
                    // знайти ключ по опису, зробив за допомогою ші
                    string keyToRemove = PhoneBookHelper.listContacts
                           .FirstOrDefault(kvp => kvp.Value == nameNummer)
                           .Key;

                    if (keyToRemove != null)
                    {
                        PhoneBookHelper.listContacts.Remove(keyToRemove);
                    }
                    else
                    {
                        Console.WriteLine("Description not found");
                    }

                    break;
                }

                else
                {
                    Console.WriteLine("Key/description not found");
                }

            }

            else
            {
                Console.WriteLine("Invalid input, name/description need to be bigger than 0 characters");
            }
        }
    }
    internal static void ReadList()
    {
        if (PhoneBookHelper.listContacts.Count >= 1)
        {
            foreach (var item in PhoneBookHelper.listContacts)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
        else
        {
            Console.WriteLine("Empty contacts");
        }
    }
}

internal static class PhoneBookHelper
{
    // стан програми
    internal static bool isRunning = true;
    // словник для обробника, меню
    internal static readonly Dictionary<int, (string description, Action action)> phoneDictionary = new()
    {
        { 0, ("Exit program", PhoneBookManager.ProgramExit) },
        { 1, ("Add contact to book", PhoneBookOperations.Add) },
        { 2, ("Remove contact by name/nummer", PhoneBookOperations.Remove) },
        { 3, ("View your current phone-book", PhoneBookOperations.ReadList) }
    };
    // список контактів
    internal static readonly Dictionary<string, string> listContacts = new();
}
