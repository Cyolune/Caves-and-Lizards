using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatsNS {
    public class Stats {
        // All stats baseline is at 10
        // 0 - Str, 1 Str = 5 HP
        // 1 - Dex, change in 1 = change in 0.5 movement
        // 2 - Int
        // 3 - Con, 1 con = 10 HP
        // 4 - Wis, change in 1 = change in 1 initiative
        // 5 - Cha
        private List<float> stats = new List<float>();
        private List<List<float>> statMods = new List<List<float>>();        
        private List<float> initiativeMods = new List<float>();
        public float currentHP;
        public float HPpercent;
        public bool isAlive;
        public bool isInCombat;
        public Stats(float[] stats) {
            for (int i = 0; i < 6; i++) {
                this.stats[i] = stats[i];
            }
            currentHP = maxHP();
            HPpercent = 1f;
        }

        float move = 5;
        List<float> msMods = new List<float>();

        
        public float getStat(int i) {
            float stat = stats[i];
            foreach (float f in statMods[i]) {stat += f;}
            return stat;
        }

        public float initiative() {
            float finalInit = getStat(4);
            foreach (float f in initiativeMods) {finalInit += f;}
            return finalInit;
        }


        public float movement() {
            float moves = move + (stats[1] - 10) * 0.5f;
            foreach (float f in msMods) {moves += f;}
            return moves;
        }

        public float maxHP() {
            return getStat(0) * 5 + getStat(3) * 10;
        }

        public void takeDmg(float dmg) {
            currentHP -= dmg;
            if (currentHP <= 0) {
                currentHP = 0;
                isAlive = false;
                isInCombat = false;
            }
            HPpercent = currentHP / maxHP();
        }
        
        public void modifyStat(int statNum, float amount) {
            statMods[statNum].Add(amount);
            if (statNum == 3) {
                currentHP = HPpercent * this.maxHP(); // if con is modified, readjust current HP 
            }            
        }

    } // class
} // namespace