using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;
using System.Media;


class StartProgram
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        while (true)
        {
            TaskMenu();
            UserOperation();
        }
    }
    static void TaskMenu()
    {
        Thread.Sleep(2000);
        Console.Clear();
        List<string> Menu = new List<string> {  "", "день тижня", "оцінки", "місяця року", "калькулятор операцій", "казкова планета кольорів", "чат бот для транспорту",
            "тип змінної", "міні гра", "вийти" };
        Console.WriteLine("операції:");
        for (int i = 1; i < Menu.Count; i++)
        {
            Thread.Sleep(250);
            Console.WriteLine($"{i}. {Menu[i]}");
        }
    }
    static void UserOperation()
    {
        Console.Write("твій вибір: ");
        int SelectedTask;
        if (int.TryParse(Console.ReadLine(), out SelectedTask))
        {
            Thread.Sleep(1000);
            Console.Clear();
            switch (SelectedTask)
            {
                case 1:
                    DayWeekLevel1();
                    break;
                case 2:
                    NotesLevel1();
                    break;
                case 3:
                    MonthsYearLevel2();
                    break;
                case 4:
                    CalculatorOperationLevel2();
                    break;
                case 5:
                    FairyPlanetOfColoursLevel3();
                    break;
                case 6:
                    ChatBotLevel3();
                    break;
                case 7:
                    PatternMatching();
                    break;
                case 8:
                    MiniGame();
                    break;
                case 9:
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("не коректний вибір");
                    break;
            }
        }
        else
        {
            Console.WriteLine("ти можеш вибрати тільки чісло");
        }
    }
    static void DayWeekLevel1()
    {
        Console.Write("яка доба неділі(1-7): ");
        int SelectedDay;
        if (int.TryParse(Console.ReadLine(), out SelectedDay))
        {
            switch (SelectedDay)
            {
                case 1:
                    Console.WriteLine("понеділок");
                    break;
                case 2:
                    Console.WriteLine("вівторок");
                    break;
                case 3:
                    Console.WriteLine("середа");
                    break;
                case 4:
                    Console.WriteLine("четверг");
                    break;
                case 5:
                    Console.WriteLine("п`ятниця");
                    break;
                case 6:
                    Console.WriteLine("субота");
                    break;
                case 7:
                    Console.WriteLine("неділя");
                    break;
                default:
                    Console.WriteLine("не коретний вибір");
                    break;
            }
        }
        else
        {
            Console.WriteLine("ти можеш вибрати тільки чісло");
        }
    }
    static void NotesLevel1()
    {
        const int PerfectlyNote = 5;
        const int GoodNote = 4;
        const int SatisfactoryNote = 3;
        const int BadNote = 2;
        const int VeryBadNote = 1;

        Console.Write("твоя оцінка(1-5): ");
        int SelectedNote;
        if (int.TryParse(Console.ReadLine(), out SelectedNote))
        {
            switch (SelectedNote)
            {
                case PerfectlyNote:
                    Console.WriteLine("відмінно!");
                    break;
                case GoodNote:
                    Console.WriteLine("добре!");
                    break;
                case SatisfactoryNote:
                    Console.WriteLine("достатьно");
                    break;
                case BadNote:
                    Console.WriteLine("погано");
                    break;
                case VeryBadNote:
                    Console.WriteLine("дуже погано");
                    break;
                default:
                    Console.WriteLine("це не правдива оцінка");
                    break;
            }
        }
        else
        {
            Console.WriteLine("ти можеш вибрати тільки ціле число");
        }
    }
    static void MonthsYearLevel2()
    {
        Console.Write("введи місяць(1-12): ");
        int SelectedMonth;
        if (int.TryParse(Console.ReadLine(), out SelectedMonth))
        {
            switch (SelectedMonth)
            {
                case 1:
                    Console.WriteLine("січень, зима");
                    break;
                case 2:
                    Console.WriteLine("лютий, зима");
                    break;
                case 3:
                    Console.WriteLine("березень, весна");
                    break;
                case 4:
                    Console.WriteLine("квітень, весна");
                    break;
                case 5:
                    Console.WriteLine("травень, весна");
                    break;
                case 6:
                    Console.WriteLine("червень, літо");
                    break;
                case 7:
                    Console.WriteLine("липень, літо");
                    break;
                case 8:
                    Console.WriteLine("серпень, літо");
                    break;
                case 9:
                    Console.WriteLine("вересень, осінь");
                    break;
                case 10:
                    Console.WriteLine("жовтень, осінь");
                    break;
                case 11:
                    Console.WriteLine("листопад, осінь");
                    break;
                case 12:
                    Console.WriteLine("грудень, зима");
                    break;
                default:
                    Console.WriteLine("не коректний місяць");
                    return;
            }
        }
        else
        {
            Console.WriteLine("ти можеш вибрати тільки ціле число");
        }
    }
    static void CalculatorOperationLevel2()
    {
        Console.Write("вибери операцію(+,-,*,/): ");
        char SelecredOperation;
        if (Char.TryParse(Console.ReadLine(), out SelecredOperation))
        {
            switch (SelecredOperation)
            {
                case '+':
                    Console.WriteLine("це додавання");
                    break;
                case '-':
                    Console.WriteLine("це віднімання");
                    break;
                case '*':
                    Console.WriteLine("це множення");
                    break;
                case '/':
                    Console.WriteLine("це ділення");
                    break;
                default:
                    Console.WriteLine("не відома операція");
                    return;
            }
        }
        else
        {
            Console.WriteLine("невідома операція");
        }
    }
    static void FairyPlanetOfColoursLevel3()
    {
        List<string> Menu = new List<string> { "красний", "помаранчевий", "чорний", "синій", "рожевий", "зелений", "жовтий" };
        Console.WriteLine("кольори для персонажей:");
        foreach (string item in Menu)
        {
        Console.WriteLine(item);
        }
        Console.Write("твій колір: ");
        string SelectedColour = Console.ReadLine();
        switch (SelectedColour)
        {
            case "красний":
                Console.WriteLine("дракон");
                break;
            case "помаранчевий":
                Console.WriteLine("свінка пепе");
                break;
            case "чорний":
                Console.WriteLine("бєтмен");
                break;
            case "синій":
                Console.WriteLine("смурфік");
                break;
            case "рожевий":
                Console.WriteLine("фєєчка вінкс");
                break;
            case "зелений":
                Console.WriteLine("лісовик");
                break;
            case "жовтий":
                Console.WriteLine("сонячний ельф");
                break;
            default:
                Console.WriteLine("в списку нема такого коліру");
                return;
        }
    }
    static void ChatBotLevel3()
    {
        List<string> Menu = new List<string> { "автобус", "поїзд", "літак", "велисопед" };
        Console.WriteLine("транспорти для перевірки:");
        foreach (string item in Menu)
        {
            Console.WriteLine(item);
        }
        Console.Write("твій транспорт: ");
        string SelectedTransport = Console.ReadLine();
        switch (SelectedTransport)
        {
            case "автобус":
                Console.WriteLine("+-7 годин");
                break;
            case "поїзд":
                Console.WriteLine("+-4 години");
                break;
            case "літак":
                Console.WriteLine("+- пів години");
                break;
            case "велосипед":
                Console.WriteLine("+-1 доба");
                break;
            default:
                Console.WriteLine("невідомий транспорт");
                return;
        }
    }
    static void PatternMatching()
    {
        Console.Write("введи щось: ");
        string UserInput = Console.ReadLine();
        object obj = null;
        if (int.TryParse(UserInput, out int IntValue))
        {
            obj = IntValue;
        }
        else if (double.TryParse(UserInput, out double DoubleValue))
        {
            obj = DoubleValue;
        }
        else if (bool.TryParse(UserInput, out bool BoolValue))
        {
            obj = BoolValue;
        }
        else if (char.TryParse(UserInput, out char CharValue))
        {
            obj = CharValue;
        }
        else
        {
            obj = UserInput;
        }
        switch (obj)
        {
            case int i:
                Console.WriteLine("ціле число");
                break;
            case double d:
                Console.WriteLine("десяткові дроби");
                break;
            case bool b:
                Console.WriteLine("істина/не істина");
                break;
            case string s:
                Console.WriteLine("рядок");
                break;
            case null:
                Console.WriteLine("пустота");
                break;
            default:
                Console.WriteLine("невідомий тип");
                return;
        }
    }
    static void MiniGame()
    {
        string className = "";
        int Hp = 0;
        string Ability = "";
        List<string> charakters = new List<string>
        {
            "1. воїн",
            "2. маг",
            "3. лучник"
        };

        void Warrior()
        {
            className = "воїн";
            Hp = 100;
            Ability = "удар кулаком"; 
        }
        void Magicain()
        {
            className = "Маг";
            Hp = 60;
            Ability = "закляття на смерть";
        }
        void Archer()
        {
            className = "лучник";
            Hp = 70;
            Ability = "стріла";
        }

        foreach (string item in charakters)
        {
            Console.WriteLine(item);
        }
        Console.Write("персонаж: ");
        string selectedCharakter = Console.ReadLine();
        if (int.TryParse(selectedCharakter, out int currentCharakter))
        {
            switch (currentCharakter)
            {
                case 1:
                    Warrior();
                    break;
                case 2:
                    Magicain();
                    break;
                case 3:
                    Archer();
                    break;
                default:
                    Console.WriteLine("такого персонажу нема");
                    return;
            }
            Console.WriteLine($"твій класс: {className}, хп: {Hp},  скіл: {Ability}");
            Thread.Sleep(1000);
        }
        else
        {
            Console.WriteLine("не коректний ввод");
        }
    }
}
