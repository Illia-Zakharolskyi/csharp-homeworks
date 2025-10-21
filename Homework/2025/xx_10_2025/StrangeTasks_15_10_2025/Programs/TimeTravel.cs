using StrangeTasks_15_10_2025.ProgramHeart.Core.Interfaces;
using System;

namespace StrangeTasks_15_10_2025.Programs;

internal class TimeTravel : IRunnable
{
    public void Run()
    {
        Random rnd = new Random();
        int startYear = 0;
        int endYear = 0;
        double energy = 100.00;

        GetStartingYearOfTravel(ref startYear);
        GetEndYearOfTravel(rnd, startYear, out endYear);

        Console.WriteLine($"початок рока подорожі в часі {startYear}, кінець подорожі {endYear}, єнергія до подорожі {energy}");

        UpdateEnergyAfterTraveled(ref energy, startYear, endYear);

        Console.WriteLine($"залишок енергії після подорожі: {energy:F2}");
    }
    private static void GetStartingYearOfTravel(ref int year)
    {
        year = DateTime.Now.Year;
    }
    private static void GetEndYearOfTravel(Random rnd, int startYear, out int endYear)
    {
        endYear = startYear + rnd.Next(startYear);
    }
    private static void UpdateEnergyAfterTraveled(ref double energy, int startYear, int EndYear)
    {
        const double minusEnergyAfterOneYear = 0.01;
        int intervalBetweenYears = EndYear - startYear;

        energy = energy / (intervalBetweenYears == 0 ? 1 : intervalBetweenYears * minusEnergyAfterOneYear);
    }
}
