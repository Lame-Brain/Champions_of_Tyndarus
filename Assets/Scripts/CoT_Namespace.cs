using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoT_Game
{
    public enum Alignment { good, neutral, evil }
    public enum Race { human, elf, dwarf, darkling, beast, were, dragon, undead }
    public enum Effect { poison, regen, curse, bless, held, stone, severed, blind, heroic, unconcious, catatonic, dead, ashes }
    public enum Gender { he, she, it }

    /* Effect List with definitions
     * poison = loses health every step
     * regen = gain health every step
     * curse = 50% to fail every action
     * bless = immunity to spells and gaining negative effects
     * held = unable to act (asleep, paralyzed, etc...)
     * stone = like held, but unable to lose health, gain health, etc. Basically minor death
     * severed = unable to cast magic
     * blind = severe penalty in combat
     * heroic = major bonus in combat
     * unconcious = health is 0 or below. moves to death when at -max_health
     * catatonic = morale is at 0 or below. basically held.
     * dead = this character is unable to act until ressurected
     * ashes = this character is unable to act until Restored
     */
    public class Dice 
    {
        private int num, sides, bonus;
        public Dice(int n, int s, int b)
        {
            this.num = n;
            this.sides = s;
            this.bonus = b;
        }
        public int Roll(Dice d)
        {
            int _result = 0;
            for (int _i = 0; _i < d.sides; _i++)
                _result += Random.Range(1, d.sides + 1) + d.bonus;
            return _result;
        }
    }
}

public static class CoT_Namespace
{
    public static string Capitalize(string s)
    {
        if (string.IsNullOrEmpty(s)) return string.Empty;

        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }
}
