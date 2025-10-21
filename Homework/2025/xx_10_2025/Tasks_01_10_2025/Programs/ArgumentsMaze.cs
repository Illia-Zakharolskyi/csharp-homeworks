using System;
using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.Dictionaries;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class ArgumentsMaze : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("wecome to argument maze!/ласкаво просимо до лабиринта аргументів!", '/', "", "-", true);

        // можливі відповіді для userDirection
        List<string> possibleAnswers = ArgumentsMazeDict.directions.Keys.ToList();
        possibleAnswers.Add("exit"); possibleAnswers.Add("вихід");

        // виводимо можливі напрямки
        CollectionsHelper.PrintCollection(ArgumentsMazeDict.directions.Keys, "Available directions(можливі напрямки):", '-', '-', true);

        // сторюемо об'єкт
        PlayerCoordinates player = new PlayerCoordinates();

        // "ігровий" цикл
        while (true)
        {

            Console.WriteLine($"Current coordinates(поточні координати): X {player.X}, Y {player.Y}");

            string userDirection = StringHelper.ReadString("Enter direction, if you want to exit enter exit(введи напрямок, якшо хочеш вийти напиши вихід): ", "Invalid text, text need to be not empty(не коректний текст, текст повинен бути не пустим)", possibleAnswers.ToArray(), "Not correct direction(не коректний напрямок)", true);
            if (userDirection == "exit" || userDirection == "вихід")
                break;

            decimal userSteps = FloatingPointNumbersHelper.ReadDecimal("steps(кроки): ", "Invalid input, try number(не коректний ввід, спробуй число)");

            if (userSteps == 0)
                Console.WriteLine("Ти вирішив залишитися на місці. Можливо, це мудре рішення...");

            var newCoordinate = CoordinatesAfterMove(userDirection, userSteps, player.X, player.Y);
            player.Y = newCoordinate.newY;
            player.X = newCoordinate.newX;
        }
    }
    private static (decimal newX, decimal newY) CoordinatesAfterMove(string direction, decimal steps, decimal x, decimal y)
    {
        if (!ArgumentsMazeDict.directions.TryGetValue(direction, out var move))
        {
            Console.WriteLine("Unknown direction(невідомий напрямок): " + direction);
            return (x, y);
        }

        return (x + move.dx * steps, y + move.dy * steps);
    }
}

internal class PlayerCoordinates
{
    internal decimal X { get; set; }
    internal decimal Y { get; set; }
}
