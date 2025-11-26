using System;

namespace OOPLearning3.Domain.Defaults;

internal static class WeaponDefaults
{
    internal const float DefaultDamage = 30.00f;
    internal const float FatigueMultiplier = 0.98f;

    // довжини за замовчуванням
    internal const float DefaultBladeLength = 0.8f; // в метрах

    // Множники спеціальної атаки
    internal const float SwordSpecialAttackMultiplier = 2.0f;

    // кількість за замовчуванням
    internal const int BowDefaultArrowCount = 15;

    // маскимальні рівні
    internal const int MaxSharpenLevel = 3;

    // множники збитку
    internal static readonly float[] SharpenLevelDamageMultipliers = { 1.20f, 1.15f, 1.10f };
}
