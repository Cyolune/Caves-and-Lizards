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
        // StatMods and initiativeMods are flat bonuses and are additive.
        private List<List<float>> statMods = new List<List<float>>();        
        private List<float> initiativeMods = new List<float>();

        public bool isInCombat;
        // Constructor
        public Stats(float[] stats) {
            for (int i = 0; i < 6; i++) {
                this.stats.Add(stats[i]);
                this.statMods.Add(new List<float>());
            }
            currentHP = stats[0] * 5 + stats[3] * 10;
            HPpercent = 1f;
        }

        // purely stat stuff
        public enum Stat
        {
            STR = 0, DEX = 1, INT = 2, CON = 3, WIS = 4, CHA = 5
        }
        public float getFinalStat(int i) {
            float stat = stats[i];
            List<float> statModsArr = statMods[i];
            foreach (float f in statModsArr) {stat += f;}
            return stat;
        }
        public float getBaseStat(int i) {
            return stats[i];
        }
        public List<float> getStatMods(int i) {
            return statMods[i];
        }    
        public void modifyStat(int statNum, float amount) {
            statMods[statNum].Add(amount);
            if (statNum == 3) {
                currentHP = HPpercent * this.getMaxHP(); // if con is modified, readjust current HP 
            }            
        }
        public void removeStatMod(int statNum, float amount) {
            statMods[statNum].Remove(amount);
            if (statNum == 3) {
                currentHP = HPpercent * this.getMaxHP(); // if con is modified, readjust current HP 
            } 
        }


        // initiative
        public float getInitiative() {
            float finalInit = getFinalStat(4);
            foreach (float f in initiativeMods) {finalInit += f;}
            return finalInit;
        }
        
        // hp related stuff
        public float currentHP;
        public float HPpercent;
        public bool isAliveBool = true;
        public bool isAlive() {
            return this.isAliveBool;
        }
        public float getCurrentHP() {
            return currentHP;
        }
        public float getMaxHP() { // str * 5 + con * 10
            return getFinalStat(0) * 5 + getFinalStat(3) * 10;
        }

        public void takeDmg(float dmg) {
            currentHP -= dmg;
            if (currentHP <= 0) {
                currentHP = 0;
                isAliveBool = false;
                isInCombat = false;
            }
            HPpercent = currentHP / getMaxHP();
        }

        public void heal(float healAmt) {
            if (isAlive()) {
                float maxHP = getMaxHP();
                currentHP += healAmt;
                if (currentHP > maxHP) {
                    currentHP = maxHP;
                }
                HPpercent = currentHP / maxHP;
            }
        }
        
        // movement stuff
        // Amount of movement in distance, msMods are in %s and additive.
        float move = 5;
        List<float> msMods = new List<float>();
        public float getMovementPerAP() {
            float moves = move + (stats[1] - 10) * 0.5f;
            foreach (float f in msMods) {moves += f * move;}
            return moves;
        }

        // action points
        float AP = 0;
        float maxAP = 8;
        float APRecovery = 4;
        // AP recovery mods are flat and additive
        List<float> APRecoveryMods = new List<float>();

        public float getAP() {
            return this.AP;
        }
        public float getMaxAP() {
            return this.maxAP;
        }
        public float getBaseAPRecovery() {
            return this.APRecovery;
        }

        public float getFinalAPRecovery() {
            float recov = APRecovery;
            foreach (float f in APRecoveryMods) {
                recov += f;
            }
            if (recov < 0) {
                recov = 0;
            }
            return recov;
        }
        public void useAP(float amt) {
            AP -= amt;
            if (AP < 0) {
                AP = 0;
            }
        }
        public void increaseAP(float amt) {
            AP += amt;
            if (AP > maxAP) {
                maxAP = AP;
            }
        }
        public void recoverAP() {
            increaseAP(getFinalAPRecovery());
        }

        public void modifyAPRec(float amt) {
            APRecoveryMods.Add(amt);
        }

        public void removeAPRecovMod(float amt) {
            APRecoveryMods.Remove(amt);
        }
    } // class
} // namespace