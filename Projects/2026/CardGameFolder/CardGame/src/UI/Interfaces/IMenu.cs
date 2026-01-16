// .Net 9.0
using System;

// UI
using CardGame.src.UI.Dispatchers;

namespace CardGame.src.UI.Interfaces;

internal interface IMenu
{
    void Display();
    Dictionary<int, (string description, Action action)> GetActionMap();
}
