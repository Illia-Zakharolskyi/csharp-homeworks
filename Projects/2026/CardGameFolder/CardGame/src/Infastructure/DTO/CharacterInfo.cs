// .Net 9.0
using System;

namespace CardGame.src.Infastructure.DTO;

internal class CharacterInfo
{
    public required string Name { get; set; }
    public required string RelativeCardsFilePath { get; set; }
    public required string RelativeCharacterCharacteristicsFilePath { get; set; }
}