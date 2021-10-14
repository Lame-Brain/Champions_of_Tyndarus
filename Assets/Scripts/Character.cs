using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoT_Game;

[System.Serializable]
public class Character
{
    public Alignment alignment;
    public Race race;
    public Gender gender;
    public int portrait = 0,
        strength = 0, //measures damage dealt in combat
        vitality = 0, //measures health gain
        endurance = 0, //measures morale
        intelligence = 0,
        agility = 0, //used for stealth and skullduggery
        charisma = 0; //used for persuasion and leadership
    public float
        max_Health = 0f;
    public int attack_bonus = 0,
        damage_bonus = 0,
        dodge_bonus = 0,
        block_bonus = 0,
        mental_bonus = 0,
        stealth_bonus = 0;
    public string current_weapon = "", 
        current_armor = "";
    public List<string> skills = new List<string>();
    public List<string> spells = new List<string>();
    public List<string> prayers = new List<string>();
    public List<string> equipment = new List<string>();
    public List<string> effects = new List<string>();    
}
