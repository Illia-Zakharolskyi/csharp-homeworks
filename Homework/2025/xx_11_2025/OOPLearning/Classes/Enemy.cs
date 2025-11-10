using System;
using System.Net;

namespace OOPLearning.Classes;

internal class Enemy
{
    // Ідентифікація
    internal string Name { get; init; } = "Ворог";

    // Здоров'я
    private float health;
    private float maxHealth = 100f;

    // Атака
    private float currentAttackPower;
    private float baseAttackPower = 20f;

    // Властивість для перевірки чи ворог живий
    internal bool IsAlive => health > 0;

    // Рівень ворога
    internal int level = 1;

    // init сеттер з валідацією для MaxHealth
    internal float MaxHealth
    {
        get => maxHealth;
        init
        {
            if (value < 1 || value > 200)
            {
                Console.WriteLine("Не корректне значення MaxHealth, встановлено 100 хп.");
                maxHealth = 100f;
            }
            else
            {
                maxHealth = value;
            }
            // Встановлюємо початкове здоров'я рівним максимальному при ініціалізації
            health = maxHealth;
        }
    }

    // init сеттер з валідацією для BaseAttackPower
    internal float BaseAttackPower
    {
        get => baseAttackPower;
        init
        {
            if (value < 1 || value > 40)
            {
                Console.WriteLine("Не корректне значення, встановлено 20 одиниць атаки.");
                baseAttackPower = 20f;
            }
            else
            {
                baseAttackPower = value;
            }
            // Встановлюємо потужність атаки рівною базовій при ініціалізації
            currentAttackPower = baseAttackPower;
        }
    }

    // Методи класу
    internal void ShowInfoByCreation()
    {
        Console.WriteLine($"Створено ворога: {Name}, Рівень: {level}, Здоров'я: {health:F2}/{maxHealth:F2}, Атака: {currentAttackPower:F2}");
    }
    internal void AttackTarget(Enemy target)
    {
        if (!IsAlive)
        {
            Console.WriteLine($"{Name} повалений і не може атакувати");
            return;
        }

        target.ReceiveDamage(currentAttackPower, Name);
        Console.WriteLine($"{Name} атакує {target.Name}a, завдаючи {currentAttackPower:F2} одиниць збитку. Здоров'я {target.Name}a тепер: {target.health:F2}");

        if (!target.IsAlive)
        {
            Console.WriteLine($"{Name} повалює {target.Name}a!");
        }
    }

    internal void ReceiveDamage(float damage, string damagerName)
    {
        if (!IsAlive)
        {
            Console.WriteLine($"{Name} вже повалений і не може отримувати більше збитку");
            return;
        }

        health -= damage;

        if (health <= 0)
        {
            health = 0;
        }
    }

    internal void Heal(float amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("кількість лікування повинна бути більше ніж 0");
            return;
        }
        if (!IsAlive)
        {
            Console.WriteLine($"{Name} повалений і не може лікуватися");
            return;
        }

        // Обмеження лікування до максимального здоров'я
        float healedAmount = Math.Min(amount, maxHealth - health);
        health += healedAmount;

        Console.WriteLine($"{Name} лікується на {healedAmount:F2} одиниць. Здоров'я тепер: {health:F2}");
    }

    internal void LevelUp()
    {
        level++;

        // Збільшення максимального здоров'я та базової атаки при підвищенні рівня
        maxHealth = maxHealth * 1.1f; // 10%
        baseAttackPower = baseAttackPower * 1.05f; // 5%

        // Оновлення поточного здоров'я та атаки
        health = maxHealth;
        currentAttackPower = baseAttackPower;

        Console.WriteLine($"{Name} підвищив рівень до {level}! Нове максимальне здоров'я: {maxHealth:F2}, нова базова атака: {baseAttackPower:F2}");
    }
}