using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GAME;
    public Main_UI_Overlay ui;
    public int SaveSlot;

    public Hero[] partySlot = new Hero[4];
    public List<Hero[]> partyList = new List<Hero[]>();
    public int PartyIndex;

    private void Awake()
    {
        GAME = this;
    }

    private void Start()
    {        
        SaveLoad.InitSaveLoad();
        DebugRosterSetup();
        DebugPartySetup();

        ui.UpdateScreen();
    }

    private void DebugRosterSetup()
    {
        Hero[] _hero = new Hero[4];

        #region Dair
        _hero[0] = new Hero();
        _hero[0].alignment = CoT_Game.Alignment.good;
        _hero[0].race = CoT_Game.Race.human;
        _hero[0].gender = CoT_Game.Gender.he;
        _hero[0].name = "Dair";
        _hero[0].title = "Warrior";
        _hero[0].upbringing = "Noble";
        _hero[0].heritage = "Westal Kingdom";
        _hero[0].portrait = 5;
        _hero[0].strength = 3;
        _hero[0].vitality = 1;
        _hero[0].endurance = 1;
        _hero[0].intelligence = -2;
        _hero[0].agility = -1;
        _hero[0].charisma = 0;
        _hero[0].current_Health = 10;
        _hero[0].max_Health = 10; 
        _hero[0].drain_Health = 0;
        _hero[0].current_Morale = 10;
        _hero[0].max_Morale = 10;
        _hero[0].current_Mana = 0;
        _hero[0].max_Mana = 0;
        _hero[0].drain_Mana = 0;
        _hero[0].current_Actions = 5;
        _hero[0].max_Actions = 5;
        _hero[0].weeksOld = 1040f;
        _hero[0].XP = 0;
        _hero[0].XP_NNL = 1000;
        _hero[0].XP_level = 1;
        _hero[0].XP_drain = 0;
        _hero[0].attack_bonus = 0;
        _hero[0].damage_bonus = 0;
        _hero[0].dodge_bonus = 0;
        _hero[0].block_bonus = 0;
        _hero[0].mental_bonus = 0;
        _hero[0].stealth_bonus = 0;
        _hero[0].wealth = 100f;
        _hero[0].current_armor = "Breastplate";
        _hero[0].current_weapon = "Longsword";
        _hero[0].skills.Add("light armor");
        _hero[0].skills.Add("medium armor");
        _hero[0].skills.Add("heavy armor");
        _hero[0].skills.Add("light weapon");
        _hero[0].skills.Add("medium weapon");
        _hero[0].skills.Add("heavy weapon");
        _hero[0].skills.Add("captain");
        #endregion

        #region Bandon
        _hero[1] = new Hero();
        _hero[1].alignment = CoT_Game.Alignment.good;
        _hero[1].race = CoT_Game.Race.human;
        _hero[1].gender = CoT_Game.Gender.he;
        _hero[1].name = "Bandon";
        _hero[1].title = "Devout";
        _hero[1].upbringing = "Merchant";
        _hero[1].heritage = "Westal Kingdom";
        _hero[1].portrait = 19;
        _hero[1].strength = 0;
        _hero[1].vitality = 1;
        _hero[1].endurance = 2;
        _hero[1].intelligence = 1;
        _hero[1].agility = -3;
        _hero[1].charisma = 1;
        _hero[1].current_Health = 10;
        _hero[1].max_Health = 10;
        _hero[1].drain_Health = 0;
        _hero[1].current_Morale = 10;
        _hero[1].max_Morale = 10;
        _hero[1].current_Mana = 10;
        _hero[1].max_Mana = 10;
        _hero[1].drain_Mana = 0;
        _hero[1].current_Actions = 5;
        _hero[1].max_Actions = 5;
        _hero[1].weeksOld = 1240f;
        _hero[1].XP = 0;
        _hero[1].XP_NNL = 1000;
        _hero[1].XP_level = 1;
        _hero[1].XP_drain = 0;
        _hero[1].attack_bonus = 0;
        _hero[1].damage_bonus = 0;
        _hero[1].dodge_bonus = 0;
        _hero[1].block_bonus = 0;
        _hero[1].mental_bonus = 0;
        _hero[1].stealth_bonus = 0;
        _hero[1].wealth = 100f;
        _hero[1].current_armor = "Breastplate";
        _hero[1].current_weapon = "Mace";
        _hero[1].skills.Add("light armor");
        _hero[1].skills.Add("medium armor");
        _hero[1].skills.Add("heavy armor");
        _hero[1].skills.Add("light weapon");
        _hero[1].skills.Add("medium weapon");
        _hero[1].skills.Add("cleric");
        _hero[1].prayers.Add("Bless");
        _hero[1].prayers.Add("Cure Light Wounds");
        #endregion

        #region Jinx
        _hero[2] = new Hero();
        _hero[2].alignment = CoT_Game.Alignment.good;
        _hero[2].race = CoT_Game.Race.human;
        _hero[2].gender = CoT_Game.Gender.he;
        _hero[2].name = "Jinx";
        _hero[2].title = "Lucky Fingers";
        _hero[2].upbringing = "Street";
        _hero[2].heritage = "Falmverg";
        _hero[2].portrait = 8;
        _hero[2].strength = -1;
        _hero[2].vitality = -1;
        _hero[2].endurance = 0;
        _hero[2].intelligence = -2;
        _hero[2].agility = 3;
        _hero[2].charisma = -1;
        _hero[2].current_Health = 10;
        _hero[2].max_Health = 10;
        _hero[2].drain_Health = 0;
        _hero[2].current_Morale = 10;
        _hero[2].max_Morale = 10;
        _hero[2].current_Mana = 0;
        _hero[2].max_Mana = 0;
        _hero[2].drain_Mana = 0;
        _hero[2].current_Actions = 7;
        _hero[2].max_Actions = 7;
        _hero[2].weeksOld = 950f;
        _hero[2].XP = 0;
        _hero[2].XP_NNL = 1000;
        _hero[2].XP_level = 1;
        _hero[2].XP_drain = 0;
        _hero[2].attack_bonus = 0;
        _hero[2].damage_bonus = 0;
        _hero[2].dodge_bonus = 0;
        _hero[2].block_bonus = 0;
        _hero[2].mental_bonus = 0;
        _hero[2].stealth_bonus = 0;
        _hero[2].wealth = 50f;
        _hero[2].current_armor = "Leathers";
        _hero[2].current_weapon = "Dagger";
        _hero[2].skills.Add("light armor");
        _hero[2].skills.Add("light weapon");
        _hero[2].skills.Add("skullduggery");
        #endregion

        #region Zaldon
        _hero[3] = new Hero();
        _hero[3].alignment = CoT_Game.Alignment.good;
        _hero[3].race = CoT_Game.Race.human;
        _hero[3].gender = CoT_Game.Gender.he;
        _hero[3].name = "Zaldon";
        _hero[3].title = "Wise";
        _hero[3].upbringing = "Noble";
        _hero[3].heritage = "Tower of Zaldon";
        _hero[3].portrait = 0;
        _hero[3].strength = -3;
        _hero[3].vitality = -3;
        _hero[3].endurance = 3;
        _hero[3].intelligence = 3;
        _hero[3].agility = -3;
        _hero[3].charisma = 1;
        _hero[3].current_Health = 20;
        _hero[3].max_Health = 20;
        _hero[3].drain_Health = 0;
        _hero[3].current_Morale = 20;
        _hero[3].max_Morale = 20;
        _hero[3].current_Mana = 20;
        _hero[3].max_Mana = 20;
        _hero[3].drain_Mana = 0;
        _hero[3].current_Actions = 3;
        _hero[3].max_Actions = 3;
        _hero[3].weeksOld = 5240f;
        _hero[3].XP = 0;
        _hero[3].XP_NNL = 1000;
        _hero[3].XP_level = 1;
        _hero[3].XP_drain = 0;
        _hero[3].attack_bonus = 0;
        _hero[3].damage_bonus = 0;
        _hero[3].dodge_bonus = 0;
        _hero[3].block_bonus = 0;
        _hero[3].mental_bonus = 0;
        _hero[3].stealth_bonus = 0;
        _hero[3].wealth = 15f;
        _hero[3].current_armor = "Robes";
        _hero[3].current_weapon = "Staff";
        _hero[3].skills.Add("mage");
        _hero[3].skills.Add("arcane lore");
        _hero[3].spells.Add("Fireball");
        _hero[3].spells.Add("MageShield");
        #endregion

        SaveLoad.Roster.Add(_hero[0]);
        SaveLoad.Roster.Add(_hero[1]);
        SaveLoad.Roster.Add(_hero[2]);
        SaveLoad.Roster.Add(_hero[3]);
        SaveLoad.SaveRoster();
    }

    private void DebugPartySetup()
    {
        PartyIndex = 0;
        partyList.Clear();
        partySlot[0] = SaveLoad.Roster[0];
        partySlot[1] = SaveLoad.Roster[1];
        partySlot[2] = SaveLoad.Roster[2];
        partySlot[3] = SaveLoad.Roster[3];
        partyList.Add(partySlot);
    }
}
