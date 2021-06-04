using System;
using System.Collections;
using System.Collections.Generic;
using PQNS;

namespace Char
{
    public class Character : IComparable<Character> 
    {
        public Character(int i) {
            this.initiative = i;
        }
        public int initiative;
        public bool isAlive = true;
        public bool isInCombat = false;
        public bool hasEndedTurn = false;

        // Currently set to comparing based on initiative directly.
        public int CompareTo(Character other)
        {
            // high intiative (-1) at front, low intiative (1) at back.
            if (this.initiative < other.initiative) return 1;
            return -1;
        }
    } // Character
} // namespace
