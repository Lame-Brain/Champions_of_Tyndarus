using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character_Sheet_Controller : MonoBehaviour
{
    public Hero thisHero;
    public Image portrait;
    public Image health_bar, morale_bar, mana_bar, actions_bar, xp_bar;
    public GameObject mana_bar_go, spell_button_go;
    public TextMeshProUGUI main_detail, condition_detail, inventory_detail, skills_detail, history_detail, magic_detail;

    private void Start()
    {
        UpdateScreen();
    }

    public void UpdateScreen()
    {
    }
}
