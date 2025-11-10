using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OOPLearning.Classes;

internal class KnightSword
{
    // Ідентификація
    internal string SwordOwner { get; init; } = string.Empty;

    // Збиток
    private float currentAttackPower;
    internal float baseAttackPower = 35;

    // Прочність
    private float currentDurability;
    private float baseDurability = 110f;

    // Властивість для перевірки чи меч зламаний
    internal bool IsBroken => currentDurability <= 0;

    // Рівень меча
    internal int swordLevel = 1;

    // init сеттери для baseAttackPower
    internal float BaseAttackPower
    {
        get => currentAttackPower;
        init
        {
            if (value < 1 || value > 150)
            {
                Console.WriteLine("Значення не входить у дозволенний базовий збиток меча лицаря, базовий збиток поставленно за замовченням");
                baseAttackPower = 35;
            }
            else
            {
                baseAttackPower = value;
            }

            // Встановлюємо потужність атаки рівною базовій при ініціалізації
            currentAttackPower = baseAttackPower;
        }
    }

    // init сеттери для baseDurability
    internal float BaseDurability
    {
        get => currentDurability;
        init
        {
            if (value < 50 || value > 200)
            {
                Console.WriteLine("Значення не входить у дозволенний базовий рівень міцності меча лицаря, базова міцність поставленно за замовченням");
                baseDurability = 110;
            }
            else
            {
                baseDurability = value;
            }
            // Встановлюємо поточну міцність рівною базовій при ініціалізації
            currentDurability = baseDurability;
        }
    }

    // методи класу
    internal void ShowSwordInfo()
    {
        Console.WriteLine($"Власник нового меча: {SwordOwner}, пошкодження: {baseAttackPower:F2}, міцність: {baseDurability}");
    }

    internal void ShowSwordDurability()
    {
        var durabilityLevels = new Dictionary<float, string>
        {
            { baseDurability * 0.70f, "Міцність меча висока" }, // 70% від базової міцності
            { baseDurability * 0.50f, "Міцність меча середня" }, // 50% від базової міцності
            { baseDurability * 0.30f, "Міцність меча низька" }, // 30% від базової міцності
            { baseDurability * 0.01f,  "Міцність меча дуже низька" }, // 1% від базової міцності
            { 0.00f,  "Меч зламаний" } // 0.00 міцності
        };

        foreach (var level in durabilityLevels)
        {
            if (currentDurability >= level.Key)
            {
                Console.WriteLine(level.Value);
                return;
            }
        }
    }

    internal void Attack(Enemy target)
    {
        if (IsBroken)
        {
            Console.WriteLine("Меч зламаний та не може атакувати");
            return;
        }

        target.ReceiveDamage(currentAttackPower, SwordOwner);
        currentDurability -= 3;
        if (currentDurability < 0) currentDurability = 0;

        Console.WriteLine($"{SwordOwner} наніс {currentAttackPower:F2} одиниць збитку {target.Name}y маючи тепер {currentDurability} одиниць міцності меча");
    }

    internal void UpgradeSword()
    {
        if (IsBroken)
        {
            Console.WriteLine("Меч зламаний та не може бути покращений");
            return;
        }

        swordLevel++;

        // Збільшуємо базовий збиток та міцність меча при кожному рівні
        baseAttackPower += baseAttackPower * 0.20f;
        baseDurability += baseDurability * 0.10f;

        // Оновлюємо поточні значення збитку та міцності
        currentAttackPower = baseAttackPower;
        currentDurability = baseDurability;

        Console.WriteLine($"Меч {SwordOwner} покращено до рівня {swordLevel}. Новий збиток: {baseAttackPower:F2} одиниць, нова міцність: {baseDurability:F2} одиниць");
    }
}