// .NET 9.0
using System;

namespace Lesson_10_12_2025.UI.Interfaces;

internal interface IMenu
{
    void Display();
    Dictionary<int, (string description, Action action)> GetActionMap();
}
