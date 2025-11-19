using System;

namespace OOPLearning2.Domain.Classes;

internal class Character
{
    // Властивості/Поля
    internal string Name { get; init; } = "Персонаж";
    private float health = 50;
    internal int[] coordinates { get; private set; } = new int[2] { 0, 0 };
    internal Weapon weapon {  get; set; } = new Weapon();

    // Властивості для private полів
    internal float Health
    {
        get => health;
        set
        {
            if (value < 0f)
            {
                Console.WriteLine("Хп не може бути меньше 0, встановленно хп за замовчуванням");
                health = 50;
            }
            else
            {
                health = value;
            }
        }
    }

    // Методи класу
    internal bool IsAlive => health > 0;

    internal void DisplayInfo()
    {
        Console.WriteLine($"Хп {Name}a: {health:F2}");
    }

    internal void Attack(Character target)
    {
        if (!IsAlive)
        {
            Console.WriteLine($"{Name} вже відкинувся та не може атакувати {target.Name}");
            return;
        }

        target.ReceiveDamage(this);

        if (!target.IsAlive)
        {
            Console.WriteLine($"{Name} повалює {target.Name}!");
        }
    }

    internal void ReceiveDamage(Character attacker)
    {
        if (health == 0)
        {
            Console.WriteLine($"{Name} вже відкинувся, в нього нема хп щоб отримати збиток від {attacker.Name}");
            return;
        }

        health -= attacker.weapon.Damage;

        if (health < 0) health = 0;
        Console.WriteLine($"{Name} отримав {attacker.weapon.Damage} одиниць збитку від {attacker.Name}, маючи тепер {health:F2} хп");
    }
}
