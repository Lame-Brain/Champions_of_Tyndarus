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
    public GameObject mana_bar_go, spell_button_go, text_prefab;
    public Transform condition_detail;
    public TextMeshProUGUI main_detail, inventory_detail, skills_detail, history_detail, magic_detail;

    public void UpdateScreen(Hero hero)
    {
        thisHero = hero;
        string _he = "he", _his = "his", _him = "him";

        if (thisHero.max_Mana <= 0)
        {
            mana_bar_go.SetActive(false);
            spell_button_go.SetActive(false);
        }
        else
        {
            mana_bar_go.SetActive(true);
            spell_button_go.SetActive(true);
        }

        portrait.sprite = AssetManager.instance.Portraits[thisHero.portrait];
        health_bar.fillAmount = ((thisHero.max_Health - thisHero.drain_Health) - thisHero.current_Health) / (thisHero.max_Health - thisHero.drain_Health);
        morale_bar.fillAmount = (thisHero.max_Morale - thisHero.current_Morale) / thisHero.max_Morale;
        if(thisHero.max_Mana > 0) mana_bar.fillAmount = ((thisHero.max_Mana - thisHero.drain_Mana) - thisHero.current_Mana) / (thisHero.max_Mana - thisHero.drain_Mana);
        actions_bar.fillAmount = (thisHero.max_Actions - thisHero.current_Actions) / thisHero.max_Actions;
        xp_bar.fillAmount = ((thisHero.XP_NNL + thisHero.XP_drain) - thisHero.XP) / (thisHero.XP_NNL+ thisHero.XP_drain);

        main_detail.text = "Here at [Location] stands <color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color>. It is [Time] and the day is [Weather].";

        GameObject _go = null;              
        
        if (thisHero.effects.Contains("poison")) { _go = Instantiate(text_prefab, condition_detail); _go.GetComponent<TextMeshProUGUI>().text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color> is poisoned."; }
        if (thisHero.effects.Contains("regen")) { _go = Instantiate(text_prefab, condition_detail); _go.GetComponent<TextMeshProUGUI>().text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color>'s health is regenerating."; }
        if (thisHero.effects.Contains("curse")) { _go = Instantiate(text_prefab, condition_detail); _go.GetComponent<TextMeshProUGUI>().text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color> is cursed."; }
        if (thisHero.effects.Contains("bless")) { _go = Instantiate(text_prefab, condition_detail); _go.GetComponent<TextMeshProUGUI>().text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color> is blessed."; }
        if (thisHero.effects.Contains("held")) { _go = Instantiate(text_prefab, condition_detail); _go.GetComponent<TextMeshProUGUI>().text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color> is helpless."; }
        if (thisHero.effects.Contains("stone")) { _go = Instantiate(text_prefab, condition_detail); _go.GetComponent<TextMeshProUGUI>().text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color>has been turned to stone."; }
        if (thisHero.effects.Contains("severed")) { _go = Instantiate(text_prefab, condition_detail); _go.GetComponent<TextMeshProUGUI>().text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color>'s magic has been severed."; }
        if (thisHero.effects.Contains("blind")) { _go = Instantiate(text_prefab, condition_detail); _go.GetComponent<TextMeshProUGUI>().text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color> is blind."; }
        if (thisHero.effects.Contains("heroic")) { _go = Instantiate(text_prefab, condition_detail); _go.GetComponent<TextMeshProUGUI>().text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color> is feeling heroic."; }
        if (thisHero.effects.Contains("unconcious")) { _go = Instantiate(text_prefab, condition_detail); _go.GetComponent<TextMeshProUGUI>().text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color> is unconcious."; }
        if (thisHero.effects.Contains("catatonic")) { _go = Instantiate(text_prefab, condition_detail); _go.GetComponent<TextMeshProUGUI>().text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color> is not responding.."; }
        if (thisHero.effects.Contains("dead")) { _go = Instantiate(text_prefab, condition_detail); _go.GetComponent<TextMeshProUGUI>().text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color> is dead"; }
        if (thisHero.effects.Contains("ashes")) { _go = Instantiate(text_prefab, condition_detail); _go.GetComponent<TextMeshProUGUI>().text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color> has been reduced to ashes."; }
        if (!thisHero.effects.Contains("poison") && !thisHero.effects.Contains("regen") && !thisHero.effects.Contains("curse") && !thisHero.effects.Contains("bless") && !thisHero.effects.Contains("held") 
            && !thisHero.effects.Contains("stone") && !thisHero.effects.Contains("severed") && !thisHero.effects.Contains("blind") && !thisHero.effects.Contains("heroic") && !thisHero.effects.Contains("unconcious") 
            && !thisHero.effects.Contains("catatonic") && !thisHero.effects.Contains("dead") && !thisHero.effects.Contains("ashes"))
        { 
            _go = Instantiate(text_prefab, condition_detail); 
            _go.GetComponent<TextMeshProUGUI>().text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color> has no special conditions."; 
        }    

        if (thisHero.gender == CoT_Game.Gender.she) { _he = "she"; _his = "her"; _him = "her"; }
        if(thisHero.gender == CoT_Game.Gender.it) { _he = "it"; _his = "its"; _him = "it"; }
        inventory_detail.text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color> is wearing " + thisHero.current_armor + " and is wielding " + thisHero.current_weapon + ", " + _he + " is ";
        if (thisHero.equipment.Count == 0) 
            inventory_detail.text += "carrying nothing else.";
        else
        {
            inventory_detail.text += "also carrying " + thisHero.equipment[0];

            if (thisHero.equipment.Count == 2) inventory_detail.text += " and " + thisHero.equipment[1];


            if (thisHero.equipment.Count > 2)
            {
                for (int _i = 1; _i < (thisHero.equipment.Count - 1); _i++)
                    inventory_detail.text += ", " + thisHero.equipment[_i];
                inventory_detail.text += ", and " + thisHero.equipment[thisHero.equipment.Count];
            }
        }
        inventory_detail.text += "\n<color=green>" + thisHero.name + "</color> has <color=yellow>" + thisHero.wealth.ToString("0.00") + " lucrum</color>.";

        if(thisHero.skills.Count == 0)
            skills_detail.text = "<color=green>" + thisHero.name + "</color> has no special skills.";
        else
        {
            skills_detail.text = "<color=green>" + thisHero.name + "</color> has these skills:\n";
            for (int _i = 1; _i < thisHero.skills.Count; _i++)
                skills_detail.text += thisHero.skills[_i] + "\n";
        }

        history_detail.text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color> is from <color=red>" + thisHero.heritage + "</color> and is " + ((int)thisHero.weeksOld / 52) + " years old." +
            "\n" + CoT_Namespace.Capitalize(_he) + " was born ";
        if (thisHero.upbringing == "Noble") history_detail.text += "to a Noble family, and will more likely be accepted by the peerage, but will find others to be uncomfortable in " + _his + " presence.";
        if (thisHero.upbringing == "Merchant") history_detail.text += "to a wealthy family, but is not a noble. " + CoT_Namespace.Capitalize(_he) + " is likely to be accepted by the middle classes, but will be looked down upon by nobles and will be disdained by the commoners.";
        if (thisHero.upbringing == "Trade") history_detail.text += "to a skilled tradesman for a father, but was not noble or rich. " + CoT_Namespace.Capitalize(_he) + " is likely to be accepted by the middle classes, but will be looked down upon by nobles.";
        if (thisHero.upbringing == "Street") history_detail.text += "in the gutter and raised in the street. " + CoT_Namespace.Capitalize(_he) + " is likely to be looked down upon by both noble and middle classes";
        if (thisHero.upbringing == "Farmer") history_detail.text += "in the country. " + CoT_Namespace.Capitalize(_he) + " is likely to be looked down upon by any of the other classes, but is better prepared to take care of " + _him + "self in the wilds.";

        magic_detail.text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color>";
        if (thisHero.spells.Count > 0)
        {
            magic_detail.text += " knows the following spells:\n";
            for (int _i = 0; _i < thisHero.spells.Count; _i++) magic_detail.text += thisHero.spells[_i] + "\n";
            if (thisHero.prayers.Count > 0) magic_detail.text = "<color=green>" + thisHero.name + "</color> the <color=blue>" + thisHero.title + "</color>";
        }

        if (thisHero.prayers.Count > 0)
        {
            magic_detail.text += " knows the following prayers:\n";
            for (int _i = 0; _i < thisHero.prayers.Count; _i++) magic_detail.text += thisHero.prayers[_i] + "\n";
        }

    }

    public void CloseScreen()
    {
        transform.parent.GetComponent<Main_UI_Overlay>().UpdateScreen();
        Destroy(this.gameObject);
    }
}
