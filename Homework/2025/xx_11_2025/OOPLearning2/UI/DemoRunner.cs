using OOPLearning2.Application.Formatters;
using OOPLearning2.Domain.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLearning2.UI;

internal static class DemoRunner
{
    internal static void RunScenarioDemo()
    {
        App settings = new App
        {
            Name = "Налаштування",
            BatteryConsumption = 25,
            RequiredBatteryForInstallation = 10,
            RequiredBatteryForDelete = 15
        };
        App calls = new App
        {
            Name = "Дзвінки",
            BatteryConsumption = 15,
            RequiredBatteryForInstallation = 7,
            RequiredBatteryForDelete = 12
        };

        Smartphone myPhone = new Smartphone
        {
            Model = "SuperHeroPhone Ultimate Luxury Pro++ Delux",
            BatteryLevel = 100,
            InstalledApps = new List<App> { settings, calls }
        };

        var actions = new List<Action>
        {
            () => myPhone.DisplayInfo(),
            () => myPhone.StartApp(settings),
            () => myPhone.DisplayInfo(),
            () => myPhone.StartApp(calls),
            () => myPhone.DisplayInfo(),
            () => myPhone.RemoveApp(settings),
            () => myPhone.DisplayInfo(),
            () => myPhone.AddApp(settings),
            () => myPhone.DisplayInfo(),
            () => myPhone.StartApp(calls),
            () => myPhone.StartApp(calls),
            () => myPhone.StartApp(calls),
            () => myPhone.AddApp(calls),
            () => myPhone.DisplayInfo(),
            () => myPhone.ChargeBattery(30),
            () => myPhone.StartApp(settings),
            () => myPhone.DisplayInfo(),
        };

        Console.WriteLine(new string('=', 10) + " Початок презентації дій з об'єктами " + new string('=', 10));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(actions, "Дія Методу", '-', 50);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " Кінець презентації дій з об'єктами " + new string('=', 10));
    }
}
