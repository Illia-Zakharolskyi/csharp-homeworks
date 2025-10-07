using System;
using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class WhoAreYouForBirthday : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("welcome to zodiac-finder!/ласкаво просимо до зодіака-знаходчика!", '/', "", "-", true);

        // виводимо приклад
        Console.WriteLine("You can write your date birthday only like this: 0000 00 00  where first 0 is year, second month and third day");
        Console.WriteLine("Ви можете записати дату народження тільки таким чином: 0000 00 00, де перша цифра 0 означає рік, друга — місяць, а третя — день.");

        // отримуємо данні
        DateTime userBirthdayTime = GetDateTimeFromUser("Your date of birthday(твоя дата народження): ", "Invalid date of birthday(не корректна дата народження)");

        // отримаємо знак зодіака
        string zodiacs = GetZodiac(userBirthdayTime);
        string[] splitedZodiacs = zodiacs.Split('/');

        string zodiacUkr = splitedZodiacs[0];
        string zodiacEng = splitedZodiacs[1];

        // виводимо результат
        Console.WriteLine($"Your sign of zodiac : {zodiacEng}");
        Console.WriteLine($"твій знак зодіака: {zodiacUkr}");
    }
    private static DateTime GetDateTimeFromUser(string promtMessage, string invalidInputMessage)
    {
        while (true)
        {
            Console.Write(promtMessage);

            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                return date;

            else
                Console.WriteLine(invalidInputMessage);
        }
    }
    private static string GetZodiac(DateTime birthday)
    {
        if (birthday.Month == 1)
            return "Козеріг/Capricorn";
        else if (birthday.Month == 2)
            return "Водолій/Aquarius";
        else if (birthday.Month == 3)
            return "Риби/Pisces";
        else if (birthday.Month == 4)
            return "Овен/Aries";
        else if (birthday.Month == 5)
            return "Телець/Taurus";
        else if (birthday.Month == 6)
            return "Близнюки/Gemini";
        else if (birthday.Month == 7)
            return "Рак/Cancer";
        else if (birthday.Month == 8)
            return "Лев/Leo";
        else if (birthday.Month == 9)
            return "Діва/Virgo";
        else if (birthday.Month == 10)
            return "Терези/Libra";
        else if (birthday.Month == 11)
            return "Скорпіон/Scorpio";
        else if (birthday.Month == 12)
            return "Стрілець/Sagittarius";
        else
            return "Unknown/Невідомо";
    }
}
