// .Net 9.0
using System;

// Application
using CardGame.src.Application.Utilities.Validators;

namespace CardGame.src.Domain.Models;

public class Character
{
    internal readonly string Name;

    internal readonly int MaxHealth;
    internal int CurrentHealth;

    internal readonly int MaxMana;
    internal int CurrentMana;

    private readonly bool IsPlayer;

    private List<Card> Deck = new();
    internal List<Card> Hand { get; private set; }

    private readonly Random _rnd = new();

    private readonly Dictionary<string, double> _characterManaRegen = new()
    {
        { "Вампір", 0.1 },
        { "Привід", 0.1 },
        { "Оборотень", 0.1 },
        { "Німфа", 0.1 },
        { "Відьма", 0.07 }
    };

    internal Character(string name, int maxHealth, int maxMana, bool isPlayer, List<Card> deck)
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        MaxMana = maxMana;
        CurrentMana = maxMana;
        IsPlayer = isPlayer;
        Deck = deck;
        Hand = new();
    }

    internal bool IsAlive() => CurrentHealth > 0;
    internal List<Card> GetHand() => Hand;
    internal void ResetStats()
    {
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;
    }

    protected void TakeDamage(Character attacker, Card card)
    {
        CurrentHealth -= card.AttackPower;
    }
    internal void Heal(int amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;
    }

    internal void UseMana(Card card)
    {
        CurrentMana -= card.ManaCost;
        if (CurrentMana < 0)
            CurrentMana = 0;
    }

    internal void HandClear()
    {
        Hand.Clear();
    }

    internal void DrawCard()
    {
        if (Deck.Count <= 0) return;

        double roll = _rnd.NextDouble() * 100;

        Dictionary<string, int> rarityChances = new()
        {
            { "Common", 50 },
            { "Rare", 30 },
            { "Epic", 15 },
            { "Legendary", 5 }
        };

        double cumulative = 0; 
        string? selectedRarity = null;

        foreach (var rc in rarityChances) 
        { 
            cumulative += rc.Value; 

            if (roll <= cumulative) 
            { 
                selectedRarity = rc.Key; break; 
            } 
        }

        List<Card> filteredDeck = Deck.Where(card => card.Rarity == selectedRarity).ToList();

        Card drawnCard = filteredDeck[_rnd.Next(filteredDeck.Count)];
        Hand.Add(drawnCard);
    }
    internal void Attack(Character target)
    {
        if (IsPlayer)
        {
            PlayerAttackLogic(target);
        }
        else
        {
            EnemyAttackLogic(target);
        }

        RegenerateManaPercent(_characterManaRegen[Name]);
    }
    private void PlayerAttackLogic(Character target)
    {
        List<Card> availableCards = Hand.Where(card => card.ManaCost <= CurrentMana).ToList();

        if (availableCards.Count == 0)
        {
            Console.WriteLine("У вас недостатньо мани для використання будь-якої картки. Пропускаєте хід.");
            return;
        }

        int userChoice = InetegerValidator.ReadInteger(
            promptMessage: "Виберіть картку для атаки (введіть номер картки): ",
            invalidInputMessage: "Невірне введення. Спробуйте ще раз.",
            allowedAnswers: Enumerable.Range(1, Hand.Count).ToList(),
            invalidChoiceMessage: "Такої картки немає в руці."
        );

        Card playerCard = Hand[userChoice - 1];

        if (playerCard.ManaCost > CurrentMana)
        {
            Console.WriteLine("Недостатьно мани для карточки, вибери іншу");
            Attack(target);
            return;
        }

        Hand.Remove(playerCard);
        UseMana(playerCard);
        target.TakeDamage(this, playerCard);

        Console.WriteLine($"гравець використував картку '{playerCard.Name}' завдаючи ворогу {playerCard.AttackPower} одиниць збитку");
        return; 
    }
    private void EnemyAttackLogic(Character target)
    {
        List<Card> availableCards = Hand.Where(card => card.ManaCost <= CurrentMana).ToList();

        if (availableCards.Count == 0)
        {
            Console.WriteLine("Ворог не має достатньо мани для використання карток і пропускає хід.");
            return;
        }

        Thread.Sleep(2);

        int choice = _rnd.Next(availableCards.Count);
        Card enemyCard = availableCards[choice];

        Hand.Remove(enemyCard);
        UseMana(enemyCard);
        target.TakeDamage(this, enemyCard);

        Console.WriteLine($"Ворог використував картку '{enemyCard.Name}' завдаючи гравцю {enemyCard.AttackPower} одиниць збитку");
        return;
    }
    private void RegenerateManaPercent(double percent) 
    { 
        int regen = (int)Math.Ceiling(MaxMana * percent); 
        CurrentMana = Math.Min(MaxMana, CurrentMana + regen); 
    }
}