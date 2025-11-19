using System;

namespace OOPLearning2.Domain.Classes;

internal class Smartphone
{
    internal string Model { get; init; } = "невідомий бренд";
    internal List<App> InstalledApps { get; set; } = new List<App>();
    private int batteryLevel;

    internal int BatteryLevel
    {
        get => batteryLevel;
        set
        {
            if (value < 0 || value > 100)
            {
                Console.WriteLine("Рівень заряду батареї повинен бути в межах від 0 до 100. Встановлено базове значення 100.");
                batteryLevel = 100;
            }
            else
            {
                batteryLevel = value;
            }
        }
    }

    internal void DisplayInfo()
    {
        Console.WriteLine($"Модель смартфону: {Model}, поточний заряд {BatteryLevel}%, Кількість встановленних додатків {InstalledApps.Count}");
    }

    internal void StartApp(App app)
    {
        if (!InstalledApps.Contains(app))
        {
            Console.WriteLine($"Додаток {app.Name} не встановлено на смартфоні.");
            return;
        }

        if (BatteryLevel < app.BatteryConsumption)
        {
            Console.WriteLine($"Недостатньо заряду батареї для запуску додатку {app.Name}.");
            return;
        }

        app.Run(this);

        if (BatteryLevel < 0)
        {
            BatteryLevel = 0;
        }
    }

    internal void ConsumeBattery(int amount)
    {
        if (batteryLevel < 0)
        {
            Console.WriteLine($"Телефон розрядженній та не може розрядитися ще");
            return;
        }

        batteryLevel -= amount;

        if (batteryLevel < 0) 
        { 
            batteryLevel = 0; 
        }

        Console.WriteLine($"Телефон розрядженно на {amount}%, текучий заряд {batteryLevel}%");
    }

    internal void ChargeBattery(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Телефон не може зарядится на мінусовий заряд");
            return;
        }

        batteryLevel += amount;

        if (batteryLevel > 100)
        {
            batteryLevel = 100;
        }

        Console.WriteLine($"Смартфон заряджено на {amount}%. Поточний заряд: {BatteryLevel}%");
    }

    internal void AddApp(App app)
    {
        if (InstalledApps.Contains(app))
        {
            Console.WriteLine($"Додаток {app.Name} вже встановлено на смартфоні.");
            return;
        }

        if (BatteryLevel < app.RequiredBatteryForInstallation)
        {
            Console.WriteLine($"Недостатньо заряду батареї для встановлення додатку {app.Name}.");
            return;
        }

        BatteryLevel -= app.RequiredBatteryForInstallation;
        InstalledApps.Add(app);

        if (BatteryLevel < 0)
        {
            BatteryLevel = 0;
        }

        Console.WriteLine($"Додаток {app.Name} успішно встановлено, використано батареї {app.RequiredBatteryForInstallation}");
    }
    internal void RemoveApp(App app)
    {
        if (!InstalledApps.Contains(app))
        {
            Console.WriteLine($"Додаток {app.Name} не встановлено на смартфоні.");
            return;
        }

        InstalledApps.Remove(app);
        Console.WriteLine($"Додаток {app.Name} успішно видалено.");
    }
}