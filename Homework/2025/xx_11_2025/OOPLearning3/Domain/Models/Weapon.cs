using System;

using OOPLearning3.Domain.Defaults;

namespace OOPLearning3.Domain.Models;

internal abstract class Weapon
{
    // Ідентифікація
    internal string Name { get; init; } = "без іменний";

    // Збиток
    protected float currentDamage { get; set; }
    protected float basicDamage { get; set; }

    // лічильник ударів
    protected int attackCount = 0;

    // Властивість для basicDamage
    internal float BasicDamage
    {
        get => basicDamage;
        init
        {
            if (value <= 0 )
            {
                Console.WriteLine($"Не корректне значення '{value}' для збитку зброї, встановлено значення за замовченням");
                basicDamage = WeaponDefaults.DefaultDamage;
                currentDamage = basicDamage;
            }
            else
            {
                basicDamage = value;
                currentDamage = basicDamage;
            }
        }
    }

    // Властивість для currentDamage
    internal float CurrentDamage
    {
        get => currentDamage;
    }

    // Втома після атаки
    protected void ApplyFatigue(int attacks = 1)
    {
        attackCount += attacks;
        currentDamage *= WeaponDefaults.FatigueMultiplier;
    }

    // Абстрактні методи
    internal abstract void Attack();
    internal abstract void SpecialAttack();
    internal abstract void DisplayStats();
}
