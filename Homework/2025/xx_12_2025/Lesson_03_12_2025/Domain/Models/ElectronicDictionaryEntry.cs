// .NET9.0
using System;

namespace Lesson_03_12_2025.Domain.Models;

internal class ElectronicDictionaryEntry
{
    internal string Word { get; init; } = string.Empty;
    internal string Definition { get; set; } = string.Empty;

    internal ElectronicDictionaryEntry(string word, string definition)
    {
        Word = word;
        Definition = definition;
    }

    public override string ToString()
    {
        return $"{Word}|{Definition}";
    }
}
