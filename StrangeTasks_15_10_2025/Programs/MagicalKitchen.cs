using StrangeTasks_15_10_2025.ProgramHeart.Core.Interfaces;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Collections.Dictionaries.ProgramsDicts;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Helpers.CollectionHelpers;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Helpers.DataHelpers;
using System;

namespace StrangeTasks_15_10_2025.Programs;

internal class MagicalKitchen : IRunnable
{
    public void Run()
    {
        Random rnd = new Random();
        string dish;


        string userAnswer = StringHelper.ReadString("Страві самій згенеруватися(так/ні, якщо ні ти введеш)? ", "не корректна відповідь", new List<string> { "так", "ні", "т", "н", "1", "0"}, true, "такої відповіді нажаль нема");

        if (userAnswer == "ні" || userAnswer == "н" || userAnswer == "0")
        {
            ListHelper.DisplayList("можливі фрукти:", MagicalKitchenDicts.dishesIngridients.Keys.ToList());

            dish = StringHelper.ReadString("який фрукт? ", "фрукт не може бути без назви", MagicalKitchenDicts.dishesIngridients.Keys.ToList(), true, "такого фрукту нажаль ще нема");
        }
        else
        {
            CreateNewDish(rnd, out dish);
        }

        int userIngridients = IntegersHelper.ReadInteger("скільки інгредиентів ти вже зробив/ла? ", "це не зовсім число, спробуй ще!");

        UpdateNecessaryIngridients(dish, ref userIngridients);

        if (userIngridients == 0)
            Console.WriteLine("Ти вже приготовив/ла страву!");
        else
            Console.WriteLine($"ще осталося інгрідіентів: {userIngridients}");

    }
    private static void CreateNewDish(Random rnd, out string newNameOfDish)
    {
        List<string> keys = MagicalKitchenDicts.dishesIngridients.Keys.ToList();

        newNameOfDish = keys[rnd.Next(keys.Count)];
    }
    private static void UpdateNecessaryIngridients(string dish, ref int usedIngridients)
    {
        usedIngridients = MagicalKitchenDicts.dishesIngridients[dish.ToLower()] - usedIngridients <= 0 ? 0 : MagicalKitchenDicts.dishesIngridients[dish.ToLower()] - usedIngridients;
    }
}
