using System;

namespace OOPLearning.Classes;

internal class BankAccount
{
    internal string OwnerName { get; init; } = string.Empty; // можна ініціалізувати лише під час створення об'єкта
    internal decimal Balance { get; private set; } = 0m; // можливо лише для читання ззовні, змінюється лише методами класу

    internal void ShowAccountInfo()
    {
        Console.WriteLine($"Власник рахунку: {OwnerName}, кошти: {Balance:F2}");
    }

    internal void WithdrawMoney(decimal amount)
    {
        if (amount <= 0 || amount > Balance)
        {
            Console.WriteLine("Сума для зняття некоректна або недостатньо коштів");
            return;

        }
        Balance -= amount;
        Console.WriteLine($"З рахунку знялося {amount} грошей");
    }

    internal void DepositMoney(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"на рахунок прийшли {amount} грошей");
    }
}