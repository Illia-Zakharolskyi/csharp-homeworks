using System;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Threading;

class Program
{
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("welcome to my program! What you want to make?");
                List();
                Thread.Sleep(3000);
                Console.Write("");
                int UserChoice;
                if (int.TryParse(Console.ReadLine(), out UserChoice))
                {
                    switch (UserChoice)
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine("click some button to exit");
                            Console.ReadKey();
                            return;
                        case 1:
                            a();
                            Program1();
                            break;
                        case 2:
                            a();
                            Program2();
                            break;
                        case 3:
                            a();
                            Program3();
                            break;
                        case 4:
                            a();
                            Program4();
                            break;
                        case 5:
                            a();
                            Program5();
                            break;
                        case 6:
                            a();
                            Program6();
                            break;
                        default:
                            Console.WriteLine("Sorry, but your input is not correct. You can choice only 0, 1, 2, 3, 4, 5, 6, or 7.");
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number from 0 to 6.");
                }
            } catch (Exception ex) { Console.WriteLine($"not correct input: {ex.Message}"); }
            
        }
    }

    static void List()
    {
        Console.WriteLine(" 0 - exit \n 1 - Is there enough money for ice cream? \n 2 - walk \n 3 - Is your birth year high? \n 4 - Is it possible to divide pizza to all friends? \n 5 - can you go to the movie? \n 6 - Do you have a birthday present?");
    }

    static void a()
    {
        Thread.Sleep(1000);
        Console.Clear();
    }
    static void Program1()
    {
        int eis = 20;
        Console.Write("How many griven do you have: ");
        int ValueGrivni = int.Parse(Console.ReadLine());
        int YourBar = ValueGrivni - eis;
        int YouNeedMore = eis - ValueGrivni;
        if (ValueGrivni >= 20)
        {
            Console.WriteLine($"Yes, you can buy eis, and you will have {YourBar} griven");
        }
        else if (ValueGrivni < 20)
        {
            Console.WriteLine($"No, you can`t. You need {YouNeedMore} more griven.");
        }
        else
        {
            Console.WriteLine("Not correct input. try again");
        }
    }
    static void Program2()
    {
        Console.Write("is there rain? (y/n): ");
        char YesNo1 = Char.Parse(Console.ReadLine());
        Console.Write("is it windy? (y/n): ");
        char YesNo2 = Char.Parse(Console.ReadLine());
        Console.Write("has you umbrella? (y/n): ");
        char YesNo3 = Convert.ToChar(Console.ReadLine());
        if (YesNo1 == 'y' && YesNo2 == 'y')
        {
            Console.WriteLine("No, you can`t go to the street");
        }
        else if (YesNo1 == 'y' && YesNo3 == 'y')
        {
            Console.WriteLine("You can go to the street");
        }
        else if (YesNo1 == 'y' && YesNo2 == 'y')
        {
            Console.WriteLine("You can go to the street");
        }
        else
        {
            Console.WriteLine("idk, decide for yourself");
        }
    }
    static void Program3()
    {
        Console.Write("Your birthday: ");
        int Birthday = int.Parse(Console.ReadLine());
        if (Birthday % 400 == 0)
        {
            Console.WriteLine("your year of birthday is high");
        }
        else if (Birthday % 100 == 0)
        {
            Console.WriteLine("your year of birthday is not high");
        }
        else if (Birthday % 4 == 0)
        {
            Console.WriteLine("Your year of birthday is high");
        }
        else
        {
            Console.WriteLine("your year of birthday is not high");
        }
    }
    static void Program4()
    {
        Console.Write("how many slices of pizza: ");
        int SlicesPizza = int.Parse(Console.ReadLine());
        Console.Write("how many friends: ");
        int Friends = int.Parse(Console.ReadLine());
        if (SlicesPizza % Friends == 0)
        {
            Console.WriteLine("Yes, you can share pizza");
        }
        else
        {
            Console.WriteLine("You not can share pizza");
        }
    }
    static void Program5()
    {
        Console.Write("your age: ");
        int Age = int.Parse(Console.ReadLine());
        Console.Write("Is there adult supervision? (y/n): ");
        char Adult = Char.Parse(Console.ReadLine());
        if (Age < 16 && Adult == 'n')
        {
            Console.WriteLine("You can`t go to the cinema");
        }
        else if (Age >= 16)
        {
            Console.WriteLine("You can go to the cinema");
        }
        else
        {
            Console.WriteLine("Print correct! you print NOT correct");
        }
    }
    static void Program6()
    {
        Console.Write("you have birthday? (y/n): ");
        char Birthday = Char.Parse(Console.ReadLine());
        Console.Write("have ypu been good this year? (yes/no): ");
        char Good = char.Parse(Console.ReadLine());
        if (Birthday == 'y' && Good == 'y')
        {
            Console.WriteLine("Happy birthday! you will get the presen today!");
        }
        else
        {
            Console.WriteLine("No, You NOT will get the present this year!!");
        }
    }
}