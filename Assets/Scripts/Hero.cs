using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{
    public string name = "",
    title = "",
    upbringing = "",
    heritage = "";

    public float current_Health = 0f,
        drain_Health = 0f,
        current_Morale = 0f,
        max_Morale = 0f,
        current_Mana = 0f,
        max_Mana = 0f, 
        current_Actions = 0f,
        max_Actions = 0f,
        weeksOld = 0f;

    public int XP = 0,
        XP_NNL = 0,
        XP_level = 0,
        XP_drain = 0;

    public float wealth = 0f;

}
