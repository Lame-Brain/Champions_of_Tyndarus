using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Main_UI_Overlay : MonoBehaviour
{
    public GameObject[] PartyMember_Slot;
    public Image[] PartyMember_portrait;
    public GameObject Character_Sheet_Prefab;

    // Update is called once per frame

    public void UpdateScreen()
    {
        if (GameManager.GAME.partyList.Count > 0)
        {
            Hero[] _hero = GameManager.GAME.partyList[GameManager.GAME.PartyIndex];
            for (int _i = 0; _i < 4; _i++)
            {
                PartyMember_Slot[_i].SetActive(false);
                if (_hero[_i] != null) 
                { 
                    PartyMember_Slot[_i].SetActive(true);
                    PartyMember_portrait[_i].sprite = AssetManager.instance.Portraits[_hero[_i].portrait];
                }
                    
            }            
        }
    }

    public void OpenCharacterSheet(int _index)
    {
        GameObject _go = Instantiate(Character_Sheet_Prefab, transform);
        Hero[] _hero = GameManager.GAME.partyList[GameManager.GAME.PartyIndex];
        _go.GetComponent<Character_Sheet_Controller>().UpdateScreen(_hero[_index]);
        
    }
}
