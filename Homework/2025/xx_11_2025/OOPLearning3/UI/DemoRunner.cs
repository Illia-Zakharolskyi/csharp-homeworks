using System;

using OOPLearning3.Application.Helpers.Formatters;
using OOPLearning3.Domain.Models;
using OOPLearning3.Domain.Weapons;

namespace OOPLearning3.UI;

internal static class DemoRunner
{
    internal static void RunAllDemos()
    {
        List<Action> actions = new()
        {
            () => RunPlayersBowAndSwordDemo(),
            () => RunPlayerSwordDemo(),
            () => RunPlayerBowDemo(),
        };

        Console.WriteLine(new string('=', 10) + " Початок всіх презентацій " + new string('=', 10));
        Console.WriteLine();
        RunDemoActionsFormatter.RunActions(actions, "Демонстрація", '*', 70);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " Кінець всіх презентацій " + new string('=', 10));
    }
    internal static void RunPlayersBowAndSwordDemo()
    {
        Weapon weapon1 = new Sword()
        {
            Name = "екскалібур",
            BasicDamage = 32.45f,
            BladeLength = 1.2f
        };
        Weapon weapon2 = new Bow()
        {
            BasicDamage = 43.01f,
            MaxArrowCount = 10,
        };

        Player player1 = new Player(
            name: "Алекс",
            equippedWeapon: weapon1
        );
        Player player2 = new Player(
            name: "Андрій",
            equippedWeapon: weapon2
        );

        List<Action> actions = new()
        {
           () => player1.DisplayInfoByCreating(),
           () => player2.DisplayInfoByCreating(),
           () => player1.WeaponAttack(),
           () => player2.WeaponAttack(),
           () => player1.DisplayWeaponStats(),
           () => player2.DisplayWeaponStats(),
           () => player1.ReloadWeapon(),
           () => player2.ReloadWeapon(),
           () => player1.SharpenWeapon(),
           () => player2.SharpenWeapon(),
           () => player1.DisplayWeaponStats(),
           () => player2.DisplayWeaponStats(),
           () => player1.SharpenWeapon(),
           () => player2.SpecialWeaponAttack(),
           () => player1.SpecialWeaponAttack(),
           () => player1.DisplayWeaponStats(),
           () => player2.DisplayWeaponStats(),
        };

        Console.WriteLine(new string('=', 10) + " Початок презентації дій з ігроком який має меч та ігроком який має лук " + new string('=', 10));
        Console.WriteLine();
        RunDemoActionsFormatter.RunActions(actions);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " Кінець презентації дій з ігроком який має меч та ігроком який має лук " + new string('=', 10));
    }
    internal static void RunPlayerSwordDemo()
    {
        Weapon sword = new Sword
        {
            Name = "Старий меч",
            BasicDamage = 20.0f,
            BladeLength = 0.9f
        };

        Player player = new Player(
            name: "Максим",
            equippedWeapon: sword
        );

        List<Action> actions = new()
        {
            () => player.DisplayInfoByCreating(),
            () => player.WeaponAttack(),
            () => player.DisplayWeaponStats(),
            () => player.ReloadWeapon(),
            () => player.SharpenWeapon(),
            () => player.SharpenWeapon(),
            () => player.DisplayWeaponStats(),
            () => player.SpecialWeaponAttack(),
        };

        Console.WriteLine(new string('=', 10) + " Початок презентації дій з ігроком який має меч " + new string('=', 10));
        Console.WriteLine();
        RunDemoActionsFormatter.RunActions(actions);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " Кінець презентації дій з ігроком який має меч " + new string('=', 10));
    }
    internal static void RunPlayerBowDemo()
    {
        Weapon bow = new Bow
        {
            Name = "Мисливський лук",
            BasicDamage = 15.0f,
            MaxArrowCount = 12
        };

        Player player = new Player("Олег", bow);

        List<Action> actions = new()
        {
            () => player.DisplayInfoByCreating(),
            () => player.DisplayWeaponStats(),
            () => player.WeaponAttack(),
            () => player.SpecialWeaponAttack(),
            () => player.ReloadWeapon(),
            () => player.DisplayWeaponStats(),
            () => player.SharpenWeapon(),
            () => player.SpecialWeaponAttack(),
            () => player.DisplayWeaponStats(),
        };

        Console.WriteLine(new string('=', 10) + " Початок презентації дій з ігроком який має лук " + new string('=', 10));
        Console.WriteLine();
        RunDemoActionsFormatter.RunActions(actions);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " Кінець презентації дій з ігроком який має лук " + new string('=', 10));
    }
}