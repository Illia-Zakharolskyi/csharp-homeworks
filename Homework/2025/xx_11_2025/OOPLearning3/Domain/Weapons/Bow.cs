using System;


using OOPLearning3.Domain.Defaults;
using OOPLearning3.Domain.Interfaces;
using OOPLearning3.Domain.Models;

namespace OOPLearning3.Domain.Weapons;

internal class Bow : Weapon, IReloadable
{
    // кількість стріл
    private int currentArrowCount;
    private int maxArrowCount;

    // Властивість для maxArrowCount
    internal int MaxArrowCount
    {
        get => maxArrowCount;
        init
        {
            if (value <= 0)
            {
                Console.WriteLine($"Не корректне значення '{value}' для кількість стріл у лука, встановлено значення за замовченням");
                maxArrowCount = WeaponDefaults.BowDefaultArrowCount;
            }
            else
            {
                maxArrowCount = value;
            }

            currentArrowCount = maxArrowCount;
        }
    }

    // властивість для currentArrowCount
    internal int CurrentArrowCount
    {
        get => currentArrowCount;
    }

    // Методи классу
    public void Reload()
    {
        if (currentArrowCount == maxArrowCount)
        {
            Console.WriteLine($"Кількість стріл максимальна({MaxArrowCount} стріл), нема сенсу перезаряджатися");
            return;
        }

        currentArrowCount = maxArrowCount;
        Console.WriteLine($"Кількість стріл поповнилась до максимума({MaxArrowCount} стріл)!");
    }

    // override методи
    internal override void Attack()
    {
        if (currentArrowCount <= 0)
        {
            Console.WriteLine("Недостатьно стріл для вистрілу луку");
            return;
        }

        currentArrowCount--;

        Console.WriteLine($"луком з ім'ям {Name} завдаючи {currentDamage:F2} одиниць урону");
        ApplyFatigue();
    }
    internal override void SpecialAttack()
    {
        if (currentArrowCount <= 0)
        {
            Console.WriteLine("Недостатьно стріл для спеціального вистрілу луку");
            return;
        }

        float specialDamage = currentDamage * currentArrowCount;

        Console.WriteLine($"луком випускаючи всі стріли та завдаючи {specialDamage:F2} одиниць шкоди");
        ApplyFatigue(currentArrowCount);
        currentArrowCount = 0;
    }

    internal override void DisplayStats()
    {
        Console.WriteLine($"лук з назвою: {Name}, базовий збиток {Name}: {basicDamage:F2}, поточний збиток {Name}: {currentDamage:F2}, кількість стріл у {Name}: {currentArrowCount}, було вистрілів з луку {Name}: {attackCount}");
    }
}
