using OOPLearning2.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLearning2.Application.Routing.Dictionaries;

internal static class DemoActionMap
{
    internal static readonly Dictionary<int, (string description, Action action)> availableActions = new()
    {
        { 0, ("вихід", () => Environment.Exit(0)) },
        { 1, ("подивитися сценарій", () => DemoRunner.RunScenarioDemo()) },
    };
}

