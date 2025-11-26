using System;

using OOPLearning3.Domain.Interfaces;

namespace OOPLearning3.Domain.Models;

internal class Player
{
    internal string Name { get; private set; }
    internal Weapon? EquippedWeapon { get; private set; }

    public Player(string name, Weapon? equippedWeapon)
    {
        Name = name;
        EquippedWeapon = equippedWeapon;
    }

    internal void DisplayInfoByCreating()
    {
        Console.WriteLine($"Создано нового персонажу з іменем {Name}");
    }

    internal void WeaponAttack()
    {
        if (EquippedWeapon == null)
        {
            Console.WriteLine($"У {Name} немає зброї щоб атакувати");
            return;
        }

        Console.Write($"{Name} Атакує ");
        EquippedWeapon.Attack();
    }

    internal void SpecialWeaponAttack()
    {
        if (EquippedWeapon == null)
        {
            Console.WriteLine($"у {Name} Немає зброї щоб атакувати");
            return;
        }

        Console.Write($"{Name} завдає спеціальний удар ");
        EquippedWeapon.SpecialAttack();
    }

    internal void DisplayWeaponStats()
    {
        if (EquippedWeapon == null)
        {
            Console.WriteLine($"нема екіпірованої зброї у {Name} щоб показати статистику");
            return;
        }

        Console.Write($"{Name} має ");
        EquippedWeapon.DisplayStats();
    }

    internal void SharpenWeapon()
    {
        if (EquippedWeapon == null)
        {
            Console.WriteLine($"нема екіпірованої зброї у {Name} щоб загострити її");
            return;
        }
        if (EquippedWeapon is not ISharpenable)
        {
            Console.WriteLine($"екіпірована зброя у {Name} не може бути загостренною");
            return;
        }

        Console.Write($"{Name} успішно загострив {EquippedWeapon.Name}! ");
        ISharpenable sharpenable = (ISharpenable)EquippedWeapon;
        sharpenable.Sharpen();
    }

    internal void ReloadWeapon()
    {
        if (EquippedWeapon == null)
        {
            Console.WriteLine($"нема екіпірованої зброї у {Name} щоб перезарядити її");
            return;
        }
        if (EquippedWeapon is not IReloadable)
        {
            Console.WriteLine($"екіпірована зброя у {Name} не може перезаряджатися");
            return;
        }

        Console.Write($"{Name} успішно перезарядив {EquippedWeapon.Name}! ");
        IReloadable reloadable = (IReloadable)EquippedWeapon;
        reloadable.Reload();
    }
}