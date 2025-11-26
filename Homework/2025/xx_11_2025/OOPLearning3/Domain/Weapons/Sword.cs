using System;

using OOPLearning3.Domain.Defaults;
using OOPLearning3.Domain.Interfaces;
using OOPLearning3.Domain.Models;

namespace OOPLearning3.Domain.Weapons;

internal class Sword : Weapon, ISharpenable
{
    // Довжини
    private float bladeLength;

    // рівні
    public int SharpenLevel { get; private set; } = 0;

    // Властивість для bladeLength
    internal float BladeLength
    {
        get => bladeLength;
        set
        {
            if (value <= 0)
            {
                Console.WriteLine($"Не корректне значення '{value}' для довжини меча, встановлено значення за замовченням");
                bladeLength = WeaponDefaults.DefaultBladeLength;
            }
            else
            {
                bladeLength = value;
            }
        }
    }
    // методи классу
    public void Sharpen()
    {
        if (SharpenLevel == WeaponDefaults.MaxSharpenLevel)
        {
            Console.WriteLine($"Досягнуто максимального рівня загострювання({SharpenLevel} рівень загострювання)");
            return;
        }

        SharpenLevel++;
        basicDamage *= WeaponDefaults.SharpenLevelDamageMultipliers[SharpenLevel - 1];
        currentDamage = basicDamage;

        Console.WriteLine($"поточний рівень загострювання: {(SharpenLevel == WeaponDefaults.MaxSharpenLevel ? $"{SharpenLevel} (максимальний)" : $"{SharpenLevel}")}");
    }

    // override методи
    internal override void Attack()
    {
        Console.WriteLine($"мечом з назвою {Name} завдаючи {currentDamage:F2} одиниць шкоди");
        ApplyFatigue();
    }

    internal override void DisplayStats()
    {
        Console.WriteLine($"меч з назвою: {Name}, базовий збиток {Name}: {basicDamage:F2}, поточний збиток {Name}: {currentDamage:F2}, довжина {Name}: {bladeLength:F2} метрів, завдано ударів з допомогою {Name}: {attackCount}");
    }

    internal override void SpecialAttack()
    {
        float specialDamage = currentDamage * WeaponDefaults.SwordSpecialAttackMultiplier;

        Console.WriteLine($"мечом з назвою {Name} завдаючи {specialDamage:F2} одиниць шкоди");
        ApplyFatigue();
    }
}