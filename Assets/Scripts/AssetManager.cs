using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour
{
    public static AssetManager instance;

    public List<Sprite> Portraits = new List<Sprite>();
    public List<Sprite> NPC_Portraits = new List<Sprite>();
    public List<AudioSource> Songs = new List<AudioSource>();
    public List<AudioSource> Sounds = new List<AudioSource>();

    private void Awake()
    {
        if (AssetManager.instance == null)
        {
            AssetManager.instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
}
