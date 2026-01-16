// .Net 9.0
using System;

// Domain
using CardGame.src.Domain.Models;

namespace CardGame.src.Infastructure.DTO;

internal class CharacterStats
{
    public required string Name { get; set; }
    public required int MaxHealth { get; set; }
    public required int MaxMana { get; set; }
}
