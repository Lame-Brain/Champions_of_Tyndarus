using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoT_Game;

public class Monster : Character
{
    public string name_single, name_plural, type_single, type_pural;
    public Dice hitDice;
    public List<Dice> attack = new List<Dice>();
    public int loot;
}
