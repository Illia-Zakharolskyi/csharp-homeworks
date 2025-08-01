using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Tasks
{
    internal class Program
    {

        static void Main()
        {
            while (true)
            {
                try
                {
                    Task1();
                    Task2();
                    Task3();
                    Task4();
                    Task5();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"error! {ex.Message}");
                }
            }
        }
        static void Task1() // калькулятор настрою
        {
            Console.Write("Hello! What´s your name? ");
            string user_name = Console.ReadLine();
            Console.Write("How old are you? ");
            int user_age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Are you in a good mood(true/false)? ");
            bool user_mood = Convert.ToBoolean(Console.ReadLine());
            if (user_mood == true)
            {
                Console.WriteLine($"Nice to meet you, {user_name}. I am too {user_age} years old. Your mood is good? awesome!");
            }
            else if (user_mood == false)
            {
                Console.WriteLine($"Nice to meet you, {user_name}. I am too {user_age} years old. your mood is bad? that´s bad");
            }
        }
        static void Task2() // обчислення площі  прямокутника
        {
            Console.Write("What do you count in?(sentimeters/meters/...) ");
            string users_count = Console.ReadLine();
            Console.Write("Enter the square`s width: ");
            double square_width = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the square`s height: ");
            double square_height = Convert.ToDouble(Console.ReadLine());
            double squares_area = square_width * square_height;
            Console.WriteLine($"Squares area is: {squares_area} {users_count}²");
        }
        static void Task3() // конвертер валют
        {
            Console.Write("Convert grivnu to dollars? if y then yes, if n then convert dollars to grivnu (y/n) ");
            char user_choice = Char.ToLower(Convert.ToChar(Console.ReadLine()));
            if (user_choice == 'y')
            {
                Console.Write("how many griven? ");
                double users_grivni = Convert.ToDouble(Console.ReadLine());
                double converted_result = users_grivni / 40;
                Console.WriteLine($"{users_grivni}₴ in dollars is: {converted_result:F2}");
            }
            else if (user_choice == 'n')
            {
                Console.Write("how many dollars? ");
                double users_dollars = Convert.ToDouble(Console.ReadLine());
                double converted_result = users_dollars * 40;
                Console.WriteLine($"${users_dollars} in grivni is: {converted_result:F2}");
            }
        }
        static void Task4() // вгадай моє число
        {
            Random rnd = new Random();
            int secret_number = rnd.Next(1, 6);
            Console.Write("quess secret number(from 0 to 5): ");
            int user_quess = Convert.ToInt32(Console.ReadLine());
            if (user_quess == secret_number)
            {
                Console.WriteLine("You win!");
            }
            else if (user_quess != secret_number)
            {
                Console.WriteLine($"You lose! the secret number was {secret_number}");
            }
        }
        static void Task5() // Про себе
        {
            string my_name = "Illia";
            int my_age = 13;
            string my_favorite_color = "black";
            Console.WriteLine($"My name is {my_name}, I`m {my_age} years old, my favourite color is {my_favorite_color}");
            my_name = "Andrey";
            my_age = 16;
            my_favorite_color = "gray";
            Console.WriteLine($"My name is {my_name}, I`m {my_age} years old, my favourite color is {my_favorite_color}");
        }
    }
}
