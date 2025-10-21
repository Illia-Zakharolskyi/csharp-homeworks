using System;

namespace Tasks_01_10_2025.ProgramHeart.Utilities.Dictionaries;

internal class ArgumentsMazeDict
{
    // скільки кроків потребується, щоб рухатися в кожному напрямку
    // dx - direction x, dy - direction y
    internal static readonly Dictionary<string, (int dx, int dy)> directions = new()
    {
        { "up", (0, 1) },
        { "down", (0, -1) },
        { "left", (-1, 0) },
        { "right", (1, 0) },

        { "вверх", (0, 1) },
        { "вниз", (0, -1) },
        { "наліво", (-1, 0) },
        { "направо", (1, 0) }
    };
}
