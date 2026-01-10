// .Net 9.0
using System;

// Domain
using CardGame.src.Domain.Models;

namespace CardGame.src.Domain.Formatters;

internal class CardFormatter
{
    internal void CardsInRow(List<Card> cards)
    {
        List<string[]> rendered = cards.Select(c => c.Render()).ToList(); 
        int height = rendered[0].Length; 

        for (int line = 0; line < height; line++)
        {
            foreach (var card in cards)
            {
                string[] cardLines = card.Render();  

                if (line == 3) 
                {
                    string fullLine = cardLines[line];  
                    
                    int start = fullLine.IndexOf(card.Rarity.ToString()); 
                    int end = start + card.Rarity.ToString().Length; 
                    string left = fullLine.Substring(0, start); 
                    
                    string rarity = fullLine.Substring(start, card.Rarity.ToString().Length); 
                    string right = fullLine.Substring(end); 
                    
                    Console.ForegroundColor = ConsoleColor.White; 
                    Console.Write(left); 
                    
                    Console.ForegroundColor = GetRarityColor(card.Rarity.ToString()); 
                    Console.Write(rarity); 
                    
                    Console.ForegroundColor = ConsoleColor.White; 
                    Console.Write(right); 
                    
                    Console.ResetColor();
                } 
                else 
                { 
                    Console.Write(cardLines[line]); 
                }
            }
            Console.WriteLine();
        } 
    }
    private ConsoleColor GetRarityColor(string rarityText) 
    { 
        return rarityText switch 
        { 
            "Common" => ConsoleColor.Cyan, 
            "Rare" => ConsoleColor.Blue, 
            "Epic" => ConsoleColor.Magenta, 
            "Legendary" => ConsoleColor.Yellow, 
            _ => ConsoleColor.White 
        }; 
    }
}