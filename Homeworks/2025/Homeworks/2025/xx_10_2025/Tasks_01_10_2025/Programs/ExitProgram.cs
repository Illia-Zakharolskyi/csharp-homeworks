using System;
using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;

namespace Tasks_01_10_2025.Programs;

internal class ExitProgram : IRunnable
{
    public void Run()
    {
        Environment.Exit(0);
    }
}