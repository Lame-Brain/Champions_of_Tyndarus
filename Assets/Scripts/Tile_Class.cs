using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Class : MonoBehaviour
{
    public string base_terrain, terrain_feature, myName;
    public int num_mobs;
    public int[] mob_slot; //points to index in monster_roster
    public bool army_here, occupied, mobs_hidden;

    private void Awake()
    {
        mob_slot = new int[8];
    }
}
