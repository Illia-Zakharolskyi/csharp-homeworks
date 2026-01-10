// .Net 9.0
using System;
using System.Text.Json.Serialization;

namespace CardGame.src.Domain.Models;

public class Card
{
    public string Name { get; set; }
    public string Rarity { get; set; }
    public int AttackPower { get; set; }
    public int ManaCost { get; set; }

    public Card(string name, int attackPower, int manaCost, string rarity)
    {
        Name = name;
        AttackPower = attackPower;
        ManaCost = manaCost;
        Rarity = rarity;
    }

    internal string[] Render()
    {
        int width = Name.Length + 4;

        string rarityText = $"{Rarity}";
        string atkText = $"{AttackPower} Збитку";
        string manaText = $"{ManaCost} Мани";

        int contentWidth = width - 2; 

        int rarityPaddingLeft = Math.Max(0, (contentWidth - rarityText.Length) / 2);
        int rarityPaddingRight = Math.Max(0, contentWidth - rarityText.Length - rarityPaddingLeft);
        int atkPaddingLeft = Math.Max(0, (contentWidth - atkText.Length) / 2); 
        int atkPaddingRight = Math.Max(0, contentWidth - atkText.Length - atkPaddingLeft);
        int manaPaddingLeft = Math.Max(0, (contentWidth - manaText.Length) / 2);
        int manaPaddingRight = Math.Max(0, contentWidth - manaText.Length - manaPaddingLeft);

        return new[] 
        { 
            $"|{new string('-', width)}|", 
            $"|  {Name}  |", 
            $"|{new string(' ', width)}|",
            $"| {new string(' ', rarityPaddingLeft)}{rarityText}{new string(' ', rarityPaddingRight)} |",
            $"|{new string(' ', width)}|",
            $"| {new string(' ', atkPaddingLeft)}{atkText}{new string(' ', atkPaddingRight)} |",
            $"|{new string(' ', width)}|",
            $"| {new string(' ', manaPaddingLeft)}{manaText}{new string(' ', manaPaddingRight)} |",
            $"|{new string('-', width)}|" 
        };
    }
}