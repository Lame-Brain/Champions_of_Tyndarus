using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using CoT_Game;

public static class SaveLoad
{
    public static List<Hero> Roster = new List<Hero>();

    private static string savePath;

    public static void InitSaveLoad()
    {
        string _rosterName = "Roster" + GameManager.GAME.SaveSlot.ToString("000") + ".sav";
        savePath = Path.Combine(Application.persistentDataPath, _rosterName);
        if (File.Exists(savePath)) LoadRoster();
    }

    public static void SaveRoster()
    {
        using (var writer = new BinaryWriter(File.Open(savePath, FileMode.Create)))
        {
            if (Roster.Count > 0)
            {
                writer.Write(Roster.Count);
                for (int _i = 0; _i < Roster.Count; _i++)
                {
                    writer.Write(Roster[_i].name);
                    writer.Write(Roster[_i].title);
                    writer.Write(Roster[_i].upbringing);
                    writer.Write(Roster[_i].heritage);
                    writer.Write(Roster[_i].alignment.ToString());
                    writer.Write(Roster[_i].race.ToString());
                    writer.Write(Roster[_i].gender.ToString());
                    writer.Write(Roster[_i].portrait);
                    writer.Write(Roster[_i].strength);
                    writer.Write(Roster[_i].vitality);
                    writer.Write(Roster[_i].endurance);
                    writer.Write(Roster[_i].intelligence);
                    writer.Write(Roster[_i].agility);
                    writer.Write(Roster[_i].charisma);
                    writer.Write(Roster[_i].current_Health);
                    writer.Write(Roster[_i].max_Health);
                    writer.Write(Roster[_i].drain_Health);
                    writer.Write(Roster[_i].current_Morale);
                    writer.Write(Roster[_i].max_Morale);
                    writer.Write(Roster[_i].current_Mana);
                    writer.Write(Roster[_i].max_Mana);
                    writer.Write(Roster[_i].drain_Mana);
                    writer.Write(Roster[_i].current_Actions);
                    writer.Write(Roster[_i].max_Actions);
                    writer.Write(Roster[_i].weeksOld);
                    writer.Write(Roster[_i].XP);
                    writer.Write(Roster[_i].XP_NNL);
                    writer.Write(Roster[_i].XP_level);
                    writer.Write(Roster[_i].XP_drain);
                    writer.Write(Roster[_i].attack_bonus);
                    writer.Write(Roster[_i].damage_bonus);
                    writer.Write(Roster[_i].dodge_bonus);
                    writer.Write(Roster[_i].block_bonus);
                    writer.Write(Roster[_i].mental_bonus);
                    writer.Write(Roster[_i].stealth_bonus);
                    writer.Write(Roster[_i].wealth);
                    writer.Write(Roster[_i].current_weapon);
                    writer.Write(Roster[_i].current_armor);
                    writer.Write(Roster[_i].skills.Count);
                    if (Roster[_i].skills.Count > 0) for (int _c = 0; _c < Roster[_i].skills.Count; _c++)
                            writer.Write(Roster[_i].skills[_c]);
                    writer.Write(Roster[_i].spells.Count);
                    if (Roster[_i].spells.Count > 0) for (int _c = 0; _c < Roster[_i].spells.Count; _c++)
                            writer.Write(Roster[_i].spells[_c]);
                    writer.Write(Roster[_i].prayers.Count);
                    if (Roster[_i].prayers.Count > 0) for (int _c = 0; _c < Roster[_i].prayers.Count; _c++)
                            writer.Write(Roster[_i].prayers[_c]);
                    writer.Write(Roster[_i].equipment.Count);
                    if (Roster[_i].equipment.Count > 0) for (int _c = 0; _c < Roster[_i].equipment.Count; _c++)
                            writer.Write(Roster[_i].equipment[_c]);
                    writer.Write(Roster[_i].effects.Count);
                    if (Roster[_i].effects.Count > 0) for (int _c = 0; _c < Roster[_i].effects.Count; _c++)
                            writer.Write(Roster[_i].effects[_c]);
                }
            }
        }
    }

    public static void LoadRoster()
    {
        using (var reader = new BinaryReader(File.Open(savePath, FileMode.Open)))
        {
            Roster.Clear();
            int count = reader.ReadInt32();
            for (int _i = 0; _i < count; _i++)
            {
                Hero _loadedCharacter = new Hero();
                _loadedCharacter.name = reader.ReadString();
                _loadedCharacter.title = reader.ReadString();
                _loadedCharacter.upbringing = reader.ReadString();
                _loadedCharacter.heritage = reader.ReadString();

                string _s = reader.ReadString(); Alignment _alignEnum = (Alignment)System.Enum.Parse(typeof(Alignment), _s); _loadedCharacter.alignment = _alignEnum;
                _s = reader.ReadString(); Race _raceEnum = (Race)System.Enum.Parse(typeof(Race), _s); _loadedCharacter.race = _raceEnum;
                _s = reader.ReadString(); Gender _genderEnum = (Gender)System.Enum.Parse(typeof(Gender), _s); _loadedCharacter.gender = _genderEnum;

                _loadedCharacter.portrait = reader.ReadInt32();
                _loadedCharacter.strength = reader.ReadInt32();
                _loadedCharacter.vitality = reader.ReadInt32();
                _loadedCharacter.endurance = reader.ReadInt32();
                _loadedCharacter.intelligence = reader.ReadInt32();
                _loadedCharacter.agility = reader.ReadInt32();
                _loadedCharacter.charisma = reader.ReadInt32();
                _loadedCharacter.current_Health = reader.ReadSingle();
                _loadedCharacter.max_Health = reader.ReadSingle();
                _loadedCharacter.drain_Health = reader.ReadSingle();
                _loadedCharacter.current_Morale = reader.ReadSingle();
                _loadedCharacter.max_Morale = reader.ReadSingle();
                _loadedCharacter.current_Mana = reader.ReadSingle();
                _loadedCharacter.max_Mana = reader.ReadSingle();
                _loadedCharacter.drain_Mana = reader.ReadSingle();
                _loadedCharacter.current_Actions = reader.ReadSingle();
                _loadedCharacter.max_Actions = reader.ReadSingle();
                _loadedCharacter.weeksOld = reader.ReadSingle();
                _loadedCharacter.XP = reader.ReadSingle();
                _loadedCharacter.XP_NNL = reader.ReadSingle();
                _loadedCharacter.XP_level = reader.ReadInt32();
                _loadedCharacter.XP_drain = reader.ReadSingle();
                _loadedCharacter.attack_bonus = reader.ReadInt32();
                _loadedCharacter.damage_bonus = reader.ReadInt32();
                _loadedCharacter.dodge_bonus = reader.ReadInt32();
                _loadedCharacter.block_bonus = reader.ReadInt32();
                _loadedCharacter.mental_bonus = reader.ReadInt32();
                _loadedCharacter.stealth_bonus = reader.ReadInt32();
                _loadedCharacter.wealth = reader.ReadSingle();

                _loadedCharacter.current_weapon = reader.ReadString();
                _loadedCharacter.current_armor = reader.ReadString();

                int _skillCount = reader.ReadInt32();
                if (_skillCount > 0)
                {
                    _loadedCharacter.skills.Clear();
                    for (int _c = 0; _c < _skillCount; _c++)
                    {
                        string _skill = reader.ReadString();
                        _loadedCharacter.skills.Add(_skill);
                    }
                }

                int _spellCount = reader.ReadInt32();
                if (_spellCount > 0)
                {
                    _loadedCharacter.spells.Clear();
                    for (int _c = 0; _c < _spellCount; _c++)
                    {
                        string _spell = reader.ReadString();
                        _loadedCharacter.skills.Add(_spell);
                    }
                }

                int _prayerCount = reader.ReadInt32();
                if (_prayerCount > 0)
                {
                    _loadedCharacter.prayers.Clear();
                    for (int _c = 0; _c < _prayerCount; _c++)
                    {
                        string _prayer = reader.ReadString();
                        _loadedCharacter.prayers.Add(_prayer);
                    }
                }

                int _eqCount = reader.ReadInt32();
                if (_eqCount > 0)
                {
                    _loadedCharacter.equipment.Clear();
                    for (int _c = 0; _c < _eqCount; _c++)
                    {
                        string _eq = reader.ReadString();
                        _loadedCharacter.equipment.Add(_eq);
                    }
                }

                int _effectCount = reader.ReadInt32();
                if (_effectCount > 0)
                {
                    _loadedCharacter.effects.Clear();
                    for (int _c = 0; _c < _effectCount; _c++)
                    {
                        string _effect = reader.ReadString();
                        _loadedCharacter.effects.Add(_effect);
                    }
                }

                Roster.Add(_loadedCharacter);
            }
        }
    }
}
