using System;
using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.Programs;

namespace Tasks_01_10_2025.ProgramHeart.Utilities.Dictionaries;

internal static class MainDict
{
    internal static readonly Dictionary<int, (string description, IRunnable program)> mainDict = new()
    {
        { 0, ("Exit program(вийти з програми)", new ExitProgram() ) },
        { 1, ("Password generator(генератор паролю)", new PasswordGenerator() ) },
        { 2, ("Currency convertor(конвертер валют)", new CurrencyConvertor() ) },
        { 3, ("Magical string calculator(магічний калькулятор рядків)", new MagicCalculateStrings() ) },
        { 4, ("Calculate avarage notes(калькулятор середнього бала)", new CalculateAvarageNotes() ) },
        { 5, ("Who are you for your data birthday(хто ви по даті народження)", new WhoAreYouForBirthday() ) },
        { 6, ("Maze of arguments(лабирінт аргументів)", new ArgumentsMaze() ) },
        { 7, ("Math experiment(математичний експеремент)", new MathExperiment() ) },
        { 8, ("Greetings by name(привітання по імені)", new GreetingsByName() ) },
        { 9, ("Doubling number(подвоєння числа)", new DoublingNumber() ) },
        { 10, ("Area of rectangle(площа прямокутника)", new AreaOfRectangle() ) },
        { 11, ("Min value betwen numbers(мінімальне значення між числами)", new MinValueBetweenNumbers() ) },
        { 12, ("Is number even(чи є число парним)", new IsNumberEven() ) },
        { 13, ("Simple concatanation(проста конкантенація)", new EasyConcatanation() ) },
        { 14, ("Thirst letter from word(перша буква слова)", new ThirstLetterFromWord() ) }
    };
}