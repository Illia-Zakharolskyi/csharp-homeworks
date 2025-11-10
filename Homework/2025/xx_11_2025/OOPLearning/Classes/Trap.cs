namespace OOPLearning.Classes;

internal class Trap
{
    internal bool isTriggered { get; private set; } = false;

    internal void TriggerTrap()
    {
        if (isTriggered)
        {
            Console.WriteLine("Пастка вже була активована раніше!");
            return;
        }

        isTriggered = true;
        Console.WriteLine("Пастку було активовано!");
    }

    internal void ResetTrap()
    {
        if (!isTriggered)
        {
            Console.WriteLine("Пастка вже скинута і готова до активації!");
            return;
        }

        isTriggered = false;
        Console.WriteLine("Пастку було скинуто");
    }
}
