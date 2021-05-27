using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Char
{
    public class Character : IComparable<Character>
    {
        // Basic Stats
        int strength;       // Physical melee attacks
        int dexterity;      // Physical ranged attacks
        int intelligence;   // Magic attacks
        int constituition;  // HP
        int wisdom;         // Crit chance, initiative
        int charisma;       // self explanatory

        /* FOR LATER
        // Combat stats
        int health;
        int physicalArmour;
        int magicalArmour;
        int actionPt;
        int actionPtRecovery;

        // Mastery levels
        int pyromancy;      // fire
        int hydrokinesis;   // water
        int geomancy;       // earth
        int aerokinesis;    // air
        int electromancy;   // electric

        int necromancy;     // death
        int summoning;      // summoning
        */

        // Currently set to comparing based on initiative/wisdom directly.
        public int CompareTo(Character other)
        {
            if (this.wisdom < other.wisdom) return -1;
            return 1;
        }
    } // Character
} // namespace
