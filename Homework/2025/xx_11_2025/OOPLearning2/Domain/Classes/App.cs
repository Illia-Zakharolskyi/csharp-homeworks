using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLearning2.Domain.Classes;

internal class App
{
    internal string Name { get; init; } = "невідома програма";
    internal int RequiredBatteryForInstallation { get; init; } = 5;
    internal int RequiredBatteryForDelete { get; init; } = 8;
    private int batteryConsumption;

    internal int BatteryConsumption
    {
        get => batteryConsumption;
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Споживання батареї не може бути від'ємним. Встановлено базове значення 10%.");
                batteryConsumption = 10;
            }
            else
            {
                batteryConsumption = value;
            }
        }
    }

    internal void Run(Smartphone smartphone)
    {
        smartphone.ConsumeBattery(BatteryConsumption);
        Console.WriteLine($"Додаток {Name} запущено, він споживає {BatteryConsumption}% батареї.");
    }
}
