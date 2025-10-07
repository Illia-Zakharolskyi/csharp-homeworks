using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace homework_tasks_13_08_2025
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                try
                {
                    TaskMenu();
                    UserOperation();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error! {ex.Message}");
                }
            }
        }
        public static void TaskMenu()
        {
            Thread.Sleep(3000);
            Console.Clear();
            string[] Menu = { "exit", "homework", "this is positive number?", "this number is even or odd?", "are these numbers equal?", "How old are you?",
                "is your number in range?", "what`s your note?", "Greetings by time of day", "Calculator", "what`s season is it?", "password validator", 
                "your year is Leap?", "will you have action in cinema by your ticket?", "Mini-Quiz", "Mini-Bank", "will you have action in shop?", 
                "enter correct login and password!", "Quess the number!", "Greetinngs by season and time of day"
            };
            Console.WriteLine("Your operations:");
            for (int i = 0; i < Menu.Length; i++)
            {
                Thread.Sleep(200);
                Console.WriteLine($"{i}. {Menu[i]}");
            }
        }
        public static void UserOperation()
        {
            Console.Write("Your choice: ");
            int UserOperatorChoice;
            if (int.TryParse(Console.ReadLine(), out UserOperatorChoice))
            {
                Thread.Sleep(1000);
                Console.Clear();
                if (UserOperatorChoice == 0)
                {
                    Console.WriteLine("Bye!");
                    Environment.Exit(0);
                    return;
                }
                switch (UserOperatorChoice)
                {
                    case 1:
                        Homework();
                        break;
                    case 2:
                        IsPositiveNumber(); 
                        break;
                    case 3:
                        IsEvenOdd();
                        break;
                    case 4:
                        ComprasionNumbers();
                        break;
                    case 5:
                        HowOld();
                        break;
                    case 6:
                        CheckRange();
                        break;
                    case 7:
                        WhatsNote();
                        break;
                    case 8:
                        GreetingByTime();
                        break;
                    case 9:
                        Calculator();
                        break;
                    case 10:
                        TimeOfYear();
                        break;
                    case 11:
                        PasswordValidator();
                        break;
                    case 12:
                        IsLeapYear();
                        break;
                    case 13:
                        TicketCinema();
                        break;
                    case 14:
                        Quiz();
                        break;
                    case 15:
                        MiniBank();
                        break;
                    case 16:
                        ShopWithAction();
                        break;
                    case 17:
                        LockingSystem();
                        break;
                    case 18:
                        QuessNumberWithHint();
                        break;
                    case 19:
                        SeasonAndTimesDay();
                        break;
                    default:
                        Console.WriteLine("not correct choice");
                        break;
                }
            }
        }
        public static void IfError(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine("to continue click some button");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Homework() // домашнє завдання
        {
            bool InHomeWork = true;
            while (InHomeWork)
            {
                Console.Write("Write Current hour (0-23): ");
                int CurrentTime;
                if (int.TryParse(Console.ReadLine(), out CurrentTime))
                {
                    if (CurrentTime < 0 || CurrentTime > 23)
                    {
                        Console.WriteLine($"Sorry, but {CurrentTime} is not real time in hour.");
                        InHomeWork = false;
                    }
                    if (CurrentTime >= 6 && CurrentTime <= 11)
                    {
                        Console.WriteLine("Good Morning!");
                    }
                    else if (CurrentTime >= 12 && CurrentTime <= 17)
                    {
                        Console.WriteLine("Have a good day!");
                    }
                    else if (CurrentTime >= 18 && CurrentTime <= 22)
                    {
                        Console.WriteLine("Good evening!");
                    }
                    else
                    {
                        Console.WriteLine("Go to sleep!");
                    }
                    InHomeWork = false;
                }
                else
                {
                    IfError("Not correct input, please print integer");
                }
            }
        }
        public static void IsPositiveNumber() //  з цього завдання  йде 1 рівень
        {
            bool InPositiveNumber = true;
            while (InPositiveNumber)
            {
                Console.Write("Enter the number: ");
                int UserNumber;
                if (int.TryParse(Console.ReadLine(), out UserNumber))
                {
                    if (UserNumber > 0)
                    {
                        Console.WriteLine("That`s positive Number!");
                    }
                    else if (UserNumber < 0)
                    {
                        Console.WriteLine("That`s not positive number!");
                    }
                    else
                    {
                        Console.WriteLine("this number is neither positive, nor not positive");
                    }
                        InPositiveNumber = false;
                }
                else
                {
                    IfError("Not correct input, you can write only integer");
                }
            }
        }
        public static void IsEvenOdd() // 1 рівень
        {
            bool InEvenOdd = true;
            while (InEvenOdd)
            {
                Console.Write("Enter the number: ");
                int EvenOdd;
                if (int.TryParse(Console.ReadLine(), out EvenOdd))
                {
                    if (EvenOdd % 2 == 0)
                    {
                        Console.WriteLine($"number {EvenOdd} is Even");
                    }
                    else if (EvenOdd % 2 != 0)
                    {
                        Console.WriteLine($"number {EvenOdd} is Odd");
                    }
                    InEvenOdd = false;
                }
                else
                {
                    IfError("not correct input, you can write only integer");
                }
            }
        }
        public static void ComprasionNumbers() // 1 рівень
        {
            bool InComprasionNumber = true;
            while (InComprasionNumber)
            {
                Console.Write("Enter number a: ");
                double NumberA;
                if (double.TryParse(Console.ReadLine(), out NumberA))
                {
                    Console.Write("Enter number b: ");
                    double NumberB;
                    if (Double.TryParse(Console.ReadLine(), out NumberB))
                    {
                        if (NumberA > NumberB)
                        {
                            Console.WriteLine("Number a is bigger!");
                        }
                        else if (NumberB > NumberA)
                        {
                            Console.WriteLine("Number b is bigger!");
                        }
                        else if (NumberA == NumberB)
                        {
                            Console.WriteLine("Number a and b is equal");
                        }
                        InComprasionNumber = false;
                    }
                    else
                    {
                        IfError("not correct input, you can write only integer, or floating-point number");
                    }
                }
                else
                {
                    IfError("not correct input, you can write only integer, or floating-point number");
                }
            }
        }
        public static void HowOld() //  з цього завдання  йде 2 рівень
        {
            bool InHowOld = true;
            while (InHowOld)
            {
                Console.Write("How old are you? ");
                int UserAge;
                if (int.TryParse(Console.ReadLine(), out UserAge))
                {
                    if (UserAge < 12)
                    {
                        Console.WriteLine("Child");
                    }
                    else if (UserAge >= 12 && UserAge <= 17)
                    {
                        Console.WriteLine("Teenager");
                    }
                    else if (UserAge >= 18 && UserAge <= 59)
                    {
                        Console.WriteLine("Adult");
                    }
                    else if (UserAge >= 60)
                    {
                        Console.WriteLine("Aged man");
                    }
                    InHowOld = false;
                }
                else
                {
                    IfError("not correct input, you can write only integer");
                }
            }
        }
        public static void CheckRange() // 2 рівень
        {
            bool InCheckRange = true;
            while (InCheckRange)
            {
                Console.Write("Enter the number: ");
                double UserRangeNumber;
                if (double.TryParse(Console.ReadLine(), out UserRangeNumber))
                {
                    if (UserRangeNumber >= 10 && UserRangeNumber <= 20)
                    {
                        Console.WriteLine("number in range 10-20");
                    }
                    else
                    {
                        Console.WriteLine("number is not in range");
                    }
                    InCheckRange = false;
                }
                else
                {
                    IfError("not correct input, you can write only integer, or floating-point number");
                }
            }
        }
        public static void WhatsNote() // 2 рівень
        {
            bool InWhatsNote = true;
            while (InWhatsNote)
            {
                Console.Write("Your note(0-100): ");
                int UserNote;
                if (int.TryParse(Console.ReadLine(), out UserNote))
                {
                    if (UserNote < 0 || UserNote > 100)
                    {
                        Console.WriteLine("this is not correct note");
                    }
                    else if (UserNote >= 90 && UserNote <= 100)
                    {
                        Console.WriteLine("Perfectly");
                    }
                    else if (UserNote >= 75 && UserNote <= 89)
                    {
                        Console.WriteLine("Good");
                    }
                    else if (UserNote >= 60 && UserNote <= 74)
                    {
                        Console.WriteLine("satisfactory");
                    }
                    else if (UserNote < 60)
                    {
                        Console.WriteLine("unsatisfactory");
                    }
                    InWhatsNote = false;
                }
                else
                {
                    IfError("not correct input, you can write only integer");
                }
            }
        }
        public static void GreetingByTime() //  з цього завдання  йде 3 рівень
        {
            bool InGreetingByTime = true;
            while (InGreetingByTime)
            {
                Console.Write("Write Current hour (0-23): ");
                int CurrentTime;
                if (int.TryParse(Console.ReadLine(), out CurrentTime))
                {
                    if (CurrentTime < 0 || CurrentTime > 23)
                    {
                        Console.WriteLine($"Sorry, but {CurrentTime} is not real time.");
                        InGreetingByTime = false;
                    }
                    if (CurrentTime >= 6 && CurrentTime <= 11)
                    {
                        Console.WriteLine("Good Morning!");
                    }
                    else if (CurrentTime >= 12 && CurrentTime <= 17)
                    {
                        Console.WriteLine("Have a good day!");
                    }
                    else if (CurrentTime >= 18 && CurrentTime <= 22)
                    {
                        Console.WriteLine("Good evening!");
                    }
                    else
                    {
                        Console.WriteLine("Go to sleep!");
                    }
                    InGreetingByTime = false;
                }
                else
                {
                    IfError("not correct input, you can write only integer");
                }
            }
        }
        public static void Calculator() // 3 рівень
        {    
            bool InCalculator = true;
            while (InCalculator)
            {
                Console.Write("Enter first number: ");
                double FirstNumber;
                if (double.TryParse(Console.ReadLine(), out FirstNumber))
                {
                    Console.Write("Enter second number: ");
                    double SecondNumber;
                    if (double.TryParse(Console.ReadLine(), out SecondNumber))
                    {
                        Console.Write("What? +, -, *, /? ");
                        char SelectedOperator;
                        if (char.TryParse(Console.ReadLine(), out SelectedOperator))
                        {
                            if (SelectedOperator == '+')
                            {
                                Console.WriteLine($"Result of addition these 2 numbers = {FirstNumber + SecondNumber}");
                            }
                            else if (SelectedOperator == '-')
                            {
                                Console.WriteLine($"Result of subtraction these 2 numbers = {FirstNumber - SecondNumber}");
                            }
                            else if (SelectedOperator == '*')
                            {
                                Console.WriteLine($"Result of multiplication these 2 numbers = {FirstNumber * SecondNumber}");
                            }
                            else if (SelectedOperator == '/')
                            {
                                Console.WriteLine($"Result of division these 2 numbers = {FirstNumber / SecondNumber}");
                            }
                            Console.WriteLine("what do you want? `c` is continue, `e` is exit");
                            char ContinueExit;
                            if (Char.TryParse(Console.ReadLine(), out ContinueExit))
                            {
                                if (ContinueExit == 'c')
                                {
                                    Console.Clear();
                                    Console.WriteLine("Continue...");
                                }
                                else if (ContinueExit == 'e')
                                {
                                    InCalculator = false;
                                }
                            }
                            else 
                            {
                                IfError("not correct input, you can write only 1 char");
                            }
                        }
                        else
                        {
                            IfError("not correct input, you can choice only 1 char");
                        }
                    }
                    else
                    {
                        IfError("not correct input, you can write only integer/floating-point number");
                    }
                }
                else
                {
                    IfError("not correct input, you can write only integer/floating-point number");
                }
            }
        }
        public static void TimeOfYear() // 3 рівень
        {
            bool InTimeOfYear = true;
            while (InTimeOfYear)
            {
                Console.Write("Enter month(1-12): ");
                int SelectedMonth;
                if (int.TryParse(Console.ReadLine(), out SelectedMonth))
                {
                    if (SelectedMonth > 12 || SelectedMonth < 1)
                    {
                        Console.WriteLine("not correct month, month start from 1 month, and finish by 12 month");
                    }
                    else if (SelectedMonth == 12 || SelectedMonth == 1 || SelectedMonth == 2)
                    {
                        Console.WriteLine("Winter");
                    }
                    else if (SelectedMonth >= 3 && SelectedMonth <= 5)
                    {
                        Console.WriteLine("spring");
                    }
                    else if (SelectedMonth >= 6 && SelectedMonth <= 8)
                    {
                        Console.WriteLine("Summer");
                    }
                    else if (SelectedMonth >= 9 && SelectedMonth <= 11)
                    {
                        Console.WriteLine("Autumm");
                    }
                    InTimeOfYear = false;
                }
                else
                {
                    IfError("not correct input, you can write only integer");
                }
            }
        }
        public static void PasswordValidator() //  з цього завдання  йде 4 рівень
        {
            string password = "admin123";
            bool InPasswordValidator = true;
            while (InPasswordValidator)
            {
                Console.Write("Enter password: ");
                string userPassword = Console.ReadLine();
                if (userPassword == password)
                {
                    Console.WriteLine("You allow to entrance!");
                    InPasswordValidator = false;
                }
                else
                {
                    Console.WriteLine("Not correct password");
                }
            }
        }
        public static void IsLeapYear() // 4 рівень
        {
            bool InLeapYear = true;
            while (InLeapYear)
            {
                Console.Write("Enter the year: ");
                int UsersYear;
                if (int.TryParse(Console.ReadLine(), out UsersYear))
                {
                    if (UsersYear % 400 == 0)
                    {
                        Console.WriteLine("The year is leap");
                    }
                    else if (UsersYear % 4 == 0 && UsersYear % 100 != 0)
                    {
                        Console.WriteLine("The year is leap");
                    }
                    else
                    {
                        Console.WriteLine("This year is not leap");
                    }
                    InLeapYear = false;
                }
                else
                {
                    IfError("not correct input, you can write only integer");
                }
            }
        }
        public static void TicketCinema() // 4 рівень
        {
            double CostTicket = 100;
            bool InTicketCinema = true;
            while (InTicketCinema)
            {
                Console.Write("Your Age: ");
                int UserAge;
                if (int.TryParse(Console.ReadLine(), out UserAge))
                {
                    Console.Write("is today wednesday (y/n): ");
                    char Wednesday;
                    if (char.TryParse(Console.ReadLine(), out Wednesday))
                    {
                        if (UserAge < 12 || UserAge > 60)
                        {
                            CostTicket -= 50;
                        }
                        if (Wednesday == 'y')
                        {
                            CostTicket *= 0.7;
                        }
                        else if (Wednesday != 'y' || Wednesday != 'n')
                        {
                            Console.WriteLine("not correct choice, you can write only y(yes), or n(no)");
                        }
                        Console.WriteLine($"Your ticket`s cost: {CostTicket}");
                        InTicketCinema = false;
                    }
                }
                else
                {
                    IfError("not correct input, in `your age:` you can write only integer, in `is today wensday:` only 1 char");
                }
            }
            
        }
        public static void Quiz() // з цього завдання  йде 5 рівень
        {
            int UserPoints = 0;
            bool InQuiz = true;
            while (InQuiz)
            {
                Console.Write("Can a variable of type bool be converted to any other type(example to integer)? a-yes, b-no, c-maybe: ");
                char UserAnswer1;
                if (char.TryParse(Console.ReadLine(), out UserAnswer1))
                {
                    Console.Write("Which of the following is not a data type? a-string, b-integer, c-var: ");
                    char UserAnswer2;
                    if (char.TryParse(Console.ReadLine(), out UserAnswer2))
                    {
                        Console.Write("What keyword is used to declare a variable whose data type is inferred by the compiler at compile time? a-dynamic, b-var, c-val: ");
                        char UserAnswer3;
                        if (char.TryParse(Console.ReadLine(), out UserAnswer3))
                        {
                            if (UserAnswer1 == 'b' || UserAnswer2 == 'c' || UserAnswer3 == 'b')
                            {
                                UserPoints += 1;
                            }
                            else if (UserPoints == 3)
                            {
                                Console.WriteLine("Perfectly!");
                            }
                            else if (UserPoints == 2)
                            {
                                Console.WriteLine("Good!");
                            }
                            else if (UserPoints == 1)
                            {
                                Console.WriteLine("you need to learn. but okay, you know some!");
                            }
                            else if (UserPoints == 0)
                            {
                                Console.WriteLine("Bad. You need learn");
                            }
                            InQuiz = false;
                        }
                        else
                        {
                            IfError("not correct input, you can write only 1 char");
                        }
                    }
                    else
                    {
                        IfError("not correct input, you can write only 1 char");
                    }
                }
                else
                {
                    IfError("not correct input, you can write only 1 char");
                }
            }
        }
        public static void MiniBank() // 5 рівень
        {
            bool IsPinTrue = false;
            string PinCode = "qwerty1234";
            Double BankAccount = 0;
            string UserPin;
            do
            {
                Console.Write("PIN: ");
                UserPin = Console.ReadLine();
                if (UserPin != PinCode)
                {
                    Console.WriteLine("not correct pin");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
            while (UserPin != PinCode);
            {
                IsPinTrue = true;
            }
            bool InMiniBank = true;
            while (InMiniBank)
            {
                if (IsPinTrue == true)
                {
                    string FormatedBankAccount = BankAccount.ToString("N2");
                    Console.Write("What you will make? ´+´ is top up balance, ´-´ is withdraw money from balance, ´=´ is check your current balance, ´x´ is exit: ");
                    char UserChoiceBank;
                    if (char.TryParse(Console.ReadLine(), out UserChoiceBank))
                    {
                        if (UserChoiceBank == '+' || UserChoiceBank == '-')
                        {
                            Console.Write("how much dollars? ");
                            double UserMoney = Convert.ToDouble(Console.ReadLine());
                            if (UserChoiceBank == '+')
                            {
                                BankAccount += UserMoney;
                            }
                            else if (UserChoiceBank == '-')
                            {
                                if (UserMoney > BankAccount)
                                {
                                    Console.WriteLine("Not enough money");
                                    continue;
                                }
                                else if (UserMoney <= BankAccount)
                                {
                                    BankAccount -= UserMoney;
                                }
                            }
                        }
                        else if (UserChoiceBank == '=')
                        {
                            Console.WriteLine($"Your balance: {FormatedBankAccount}$");
                        }
                        else if (UserChoiceBank == 'x')
                        {
                            InMiniBank = false;
                        }
                        else
                        {
                            Console.WriteLine("Not availible operation");
                            continue;
                        }
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Your operation was succeful!");
                    }
                    else
                    {
                        IfError("not correct input, you can write only 1 char");
                    }
                }
            }
        }
        public static void ShopWithAction() // 5 рівень
        {

            char IsTodaySunday;
            do
            {
                Console.Write("today is sunday(y/n)? ");
                if (Char.TryParse(Console.ReadLine(), out IsTodaySunday))
                {
                    if (IsTodaySunday == 'y')
                    {
                        IsTodaySunday = 'y';
                        break;
                    }
                    else if (IsTodaySunday == 'n')
                    {
                        IsTodaySunday = 'n';
                        break;
                    }
                    else
                    {
                        Console.WriteLine("not correct input, try y or n");
                    }
                }
                else
                {
                    IfError("not correct input, you can write only 1 char");
                }
            }
            while (IsTodaySunday != 'y' || IsTodaySunday != 'n'); 
            {
                Console.WriteLine("Okay!");
            }

            bool IsDeliveryFree = false;
            double UserProductsCost = 0;
            bool InShopWithAction = true;
            while (InShopWithAction)
            {
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine(@"
                1 - Bread: packing 500g, action 10%, cost 3$(without action)
                2 - Milk: packing 1.9 liters, action 10%, cost 3$(without action)
                3 - Soda: bottle 600ml, without action, cost 3$
                4 - wine: bottle 1l, without action, cost 6$
                5 - fruits: bag with differents content(apples, pears, grapes, orange), without action, cost 6$
                6 - vegetables: bag with different content(potatoes, tomatoes, cucumbers), without action, 6$
                7 - exit from shop
            ");
                Console.Write("What one product you want to take(1-7)? ");
                int UserProduct;
                if (int.TryParse(Console.ReadLine(), out UserProduct))
                {
                    if (UserProduct == 7)
                    {
                        break;
                    }
                    else if (UserProduct == 1 || UserProduct == 2)
                    {
                        UserProductsCost += 123.78 * 0.9;
                    }
                    else if (UserProduct == 3)
                    {
                        UserProductsCost += 123.78;
                    }
                    else if (UserProduct >= 4 && UserProduct <= 6)
                    {
                        UserProductsCost += 247.55;
                    }
                    else
                    {
                        Console.WriteLine("Not correct Input, try again(you can only enter the number from 1 to 7)");
                        continue;
                    }

                    Console.WriteLine("if you want buy some other product enter 1, if you want buy current product/s enter 2");
                    char UserChoiceShop;
                    if (char.TryParse(Console.ReadLine(), out UserChoiceShop))
                    {
                        if (UserChoiceShop == '1')
                        {
                            continue;
                        }
                        else if (UserChoiceShop == '2')
                        {
                            if (UserProductsCost >= 500)
                            {
                                IsDeliveryFree = true;
                            }
                            if (IsTodaySunday == 'y')
                            {
                                UserProductsCost *= 0.95;
                            }
                            Console.WriteLine($"Your costs all products: {UserProductsCost}₴");
                            if (IsDeliveryFree == false)
                            {
                                Console.WriteLine("Your delivery is not free");
                            }
                            else
                            {
                                Console.WriteLine("Your delivery is free!");
                            }
                            InShopWithAction = false;
                        }
                    }
                    else
                    {
                        IfError("not correct input, you can write only 1 char(1 or 2)");
                    }
                }
                else
                {
                    IfError("not correct input, you can write only 1 char(y/n)");
                }
            }
        }
        public static void LockingSystem() // 5 рівень
        {
            int LockingTries = 3;
            string UserLogin = "ProKillerIvan777";
            string UserPassword = "thisishardpassword1234";
            bool InLockingSystem = true;
            while (InLockingSystem)
            {
                    Console.Write("Enter your Login: ");
                    string EnteredLogin = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    string EnteredPassword = Console.ReadLine();
                    if (EnteredLogin != UserLogin || EnteredPassword != UserPassword)
                    {
                        LockingTries--;
                        Console.WriteLine("Not correct Login/Password, Try again");
                        if (LockingTries == 0)
                        {
                            Console.WriteLine("Access blocked");
                            InLockingSystem = false;
                        }
                    }
                    else if (EnteredLogin == UserLogin && EnteredPassword == UserPassword)
                    {
                        Console.WriteLine("Welcome to the system!");
                        InLockingSystem = false;
                    }
            }
        }
        public static void QuessNumberWithHint() // 5 рівень
        {
            int UserQuesses = 0;
            Random random = new Random();
            int RandomNumber = random.Next(1, 101);
            bool InQuessNumberWithHint = true;
            while (InQuessNumberWithHint)
            {
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Quess the number! the number is from 1 to 100: ");
                int UserQuess;
                if (int.TryParse(Console.ReadLine(), out UserQuess))
                {
                    if (UserQuess < 1 || UserQuess > 100)
                    {
                        Console.WriteLine("To small/large number! max. number is 100, min. number is 1");
                    }
                    else if (UserQuess == RandomNumber)
                    {
                        UserQuesses++;
                        Console.WriteLine($"You win! your tries: {UserQuesses}");
                        InQuessNumberWithHint = false;
                    }
                    else if (UserQuess < RandomNumber)
                    {
                        UserQuesses++;
                        Console.WriteLine("your input smaller than random number!");
                    }
                    else if (UserQuess > RandomNumber)
                    {
                        UserQuesses++;
                        Console.WriteLine("your input bigger than random number!");
                    }
                    if (UserQuesses > 7)
                    {
                        Console.WriteLine($"You lose! secret number was {RandomNumber}");
                        InQuessNumberWithHint = false;
                    }
                }
                else
                {
                    IfError("not correct input, you can write only integer");
                }
            }
        }
        public static void HelpForSeasonAndTimesDay(int SelectedHour)
        {  
            if (SelectedHour >= 6 && SelectedHour <= 11)
            {
                Console.WriteLine("Good Morning!");
            }
            else if (SelectedHour >= 12 && SelectedHour <= 17)
            {
                Console.WriteLine("have a good Good day!");
            }
            else if (SelectedHour >= 18 && SelectedHour <= 22)
            {
                Console.WriteLine("have a good evening!");
            }
            else
            {
                Console.WriteLine("Good night!");
            }
        }
        public static void SeasonAndTimesDay() // 5 рівень
        {
            bool InSeasonAndTimesDay = true;
            while (InSeasonAndTimesDay)
            {
                Console.Write("Enter the number of month(1-12): ");
                int SelectedMonth;
                if (int.TryParse(Console.ReadLine(), out SelectedMonth))
                {
                    Console.Write("Enter the hour(0-23): ");
                    int SelectedHour;
                    if (int.TryParse(Console.ReadLine(), out SelectedHour))
                    {
                        if (SelectedMonth <= 0 || SelectedMonth >= 13 || SelectedHour <= -1 || SelectedHour >= 24)
                        {
                            Console.WriteLine("Not correct input, number of month can only be from 1 to 12, and hour can only be from 0 to 23, Try again");
                        }
                        switch (SelectedMonth)
                        {
                            case 12: case 1: case 2:
                                Console.WriteLine("Current month is winter");
                                HelpForSeasonAndTimesDay(SelectedHour);
                                InSeasonAndTimesDay = false;
                                break;
                            case 3: case 4: case 5:
                                Console.WriteLine("Current month is spring");
                                HelpForSeasonAndTimesDay(SelectedHour);
                                InSeasonAndTimesDay = false;
                                break;
                            case 6: case 7: case 8:
                                Console.WriteLine("Current month is summer");
                                HelpForSeasonAndTimesDay(SelectedHour);
                                InSeasonAndTimesDay = false;
                                break;
                            case 9: case 10: case 11:
                                Console.WriteLine("Current month is autumm");
                                HelpForSeasonAndTimesDay(SelectedHour);
                                InSeasonAndTimesDay = false;
                                break;
                            default:
                                Console.WriteLine("not correct choice, you can write only from 1 to 12");
                                break;
                        }
                    }
                    else
                    {
                        IfError("not correct input, you can write only integer(0-23)");
                    }
                }
                else
                {
                    IfError("not correct input, you can write only integer(1-12)");
                }
            }
        }
    }
}