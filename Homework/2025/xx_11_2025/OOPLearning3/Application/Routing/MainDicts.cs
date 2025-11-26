using System;

using OOPLearning3.UI;

namespace OOPLearning3.Application.Routing;

internal static class MainDicts
{
    internal static readonly Dictionary<int, (string description, Action action)> availableActions = new()
    {
        { 0, ("вихід", () => Environment.Exit(0)) },
        { 1, ("подивитися всі тестування", () => DemoRunner.RunAllDemos()) },
        { 2, ("подивитися тестування мечника та лучника", () => DemoRunner.RunPlayersBowAndSwordDemo()) },
        { 3, ("подивитися на тестування мечника", () => DemoRunner.RunPlayerSwordDemo()) },
        { 4, ("подивитися на тестування лучника", () => DemoRunner.RunPlayerBowDemo()) },
    };
}
