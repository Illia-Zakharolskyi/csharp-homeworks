using System;

namespace OOPLearning2.Domain.Classes;

internal class Weapon
{
    // Збиток
    private float damage = 20;

    // Діапазон
    private int range = 5;

    // геттери та init сеттери
    internal float Damage
    {
        get => damage;
        init
        {
            if (value <= 0)
            {
                Console.WriteLine("Збиток не може бути меньшим чи равним 0. Встановленно базове значення");
                damage = 20;
            }
            else
            {
                damage = value;
            }
        }
    }
    internal int Range
    {
        get => range;
        init
        {
            if (value <= 0)
            {
                Console.WriteLine("Діапазон не моде бути меньшим чи равним 0. Встановленно базове значення");
                range = 5;
            }
        }
    }
}
