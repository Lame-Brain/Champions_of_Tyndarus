using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GAME;
    public int SaveSlot;


    private void Awake()
    {
        GAME = this;
    }

    private void Start()
    {
        SaveLoad.InitSaveLoad();
    }
}
