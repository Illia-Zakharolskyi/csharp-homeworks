using System;
using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.Dictionaries;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class MathExperiment : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("Welcome to Math Experiment!/Ласкаво просимо до Математичного Експерименту!", '/', "", "-", true);

        // можливі відповіді для операцій
        List<string> possibleAnswers = MathExperimentDict.operations.Keys.ToList();
        possibleAnswers.Add("exit"); possibleAnswers.Add("вихід");

        // вивод можливих операцій
        CollectionsHelper.PrintCollection(MathExperimentDict.operations.Keys, "Available operations(можливі операції):", '-', '-', true, ", ");

        // цикл програми
        while (true)
        {
            string userOperation = StringHelper.ReadString("Enter operation, if you want to exit enter exit(введи операцію, якшо хочеш вийти напиши вихід): ", "Invalid text, text need to be not empty(не коректний текст, текст повинен бути не пустим)", possibleAnswers.ToArray(), "Not correct operation(не коректна операція)", true);
            if (userOperation == "exit" || userOperation == "вихід")
                break;
            decimal userNummerA = FloatingPointNumbersHelper.ReadDecimal("Enter Nummer A(введи Число А): ", "Invalid input, try number(не коректний ввід, спробуй число)");
            decimal userNummerB = FloatingPointNumbersHelper.ReadDecimal("Enter Nummer B(введи Число Б): ", "Invalid input, try number(не коректний ввід, спробуй число)");

            var result = ExperimentCalculate(userNummerA, userNummerB, userOperation);

            Console.WriteLine($"{result.NummerA} {MathExperimentDict.operationSymbols[userOperation]} {result.NummerB} = {result.Result} ");
        }
    }
    private static (decimal Result, decimal NummerA, decimal NummerB, string Operation) ExperimentCalculate(decimal a, decimal b, string operation)
    {
        decimal result = MathExperimentDict.operations[operation](a, b);
        return (result, a, b, operation);
    }
}
