using StrangeTasks_15_10_2025.ProgramHeart.Core.Interfaces;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Helpers.DataHelpers;
using System;

namespace StrangeTasks_15_10_2025.Programs;

internal class ComputerMasterSimulator : IRunnable
{
    public void Run()
    {
        double userEstFPS = FloatingHelper.ReadDouble("введи очікуваний FPS: ", "це не зовсім число, спробуй краще!");

        double realFPS;
        GetComputerFPS(userEstFPS, out realFPS);

        Console.WriteLine($"Справжній FPS з очікуваного: {realFPS}");

        UpgradeComputerFPS(ref  realFPS);
        Console.WriteLine($"FPS під бустом: {realFPS}");
    }
    private static void GetComputerFPS(double estimatedFPS, out double realFPS)
    {
        realFPS = estimatedFPS - estimatedFPS * 0.25;
    }
    private static void UpgradeComputerFPS(ref double FPS)
    {
        FPS += FPS * 0.10;
    }
}
