using System;
using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class AreaOfRectangle : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle($"Ласкаво просимо до Калькулятора Площі Прямокутника/!", '/', "", "", true);

        // приймаємо дані
        decimal userWidth = FloatingPointNumbersHelper.ReadDecimal("Введи ширину прямокутника: ", "не коректний ввід, спробуй число");
        decimal userHigh = FloatingPointNumbersHelper.ReadDecimal("Введи висоту прямокутника: ", "не коректний ввід, спробуй число");

        // рахуємо площу
        decimal cubeArea = CalculateArea(userWidth, userHigh);

        // виводимо результат
        Console.WriteLine($"Площа прямокутника зі шириною {userWidth:F2} та висотою {userHigh:F2} дорівнює {cubeArea:F2}");
    }
    private static  decimal CalculateArea(decimal width, decimal high)
    {
        return width * high;
    }
}
