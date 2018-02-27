﻿
namespace DeathDungeon.Models
{
    // Enum to specify the different attributes allowd.
    // Not spcified is considered not initialize and returns unknown
    // All other attributes have explicted values.

    public enum AttributeEnum
    {
        // Not specified
        undefined = 0,

        // The speed of the character, impacts movement, and initiative
        Speed = 10,

        // The defense score, to be used for defending against attacks
        Defense = 12,

        // The Attack score to be used when attacking
        Attack = 14,

        // Current Health which is always at or below MaxHealth
        CurrentHealth = 16,

        // The highest value health can go
        MaxHealth = 18,
    }
}