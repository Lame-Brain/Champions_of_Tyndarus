using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : SerializedMonoBehaviour
{
    public static MapManager MAP;

    public TextAsset csvMap, csvFeatures;
    [HideInInspector] 
    public int[,] terrain_map, feature_map;

    public int mapx, mapy;

    [Button(ButtonSizes.Small)]
    private void LoadCSV()
    {
        //terrain
        string[] rowlines = csvMap.text.Split(new char[] { '\n' });
        string[] firstline = rowlines[0].Split(new char[] { ','} );
        mapx = firstline.Length;
        mapy = rowlines.Length;
        terrain_map = new int[mapx, mapy];
        for (int y = 0; y < mapy; y++)
            for(int x = 0; x < mapx; x++)
            {
                terrain_map[x, y] = IntFromString(firstline[x]);
                if(y < mapy - 1) firstline = rowlines[y].Split(new char[] { ',' });
            }

        //features
        rowlines = csvFeatures.text.Split(new char[] { '\n' });
        firstline = rowlines[0].Split(new char[] { ',' });
        mapx = firstline.Length;
        mapy = rowlines.Length;
        feature_map = new int[mapx, mapy];
        for (int y = 0; y < mapy; y++)
            for (int x = 0; x < mapx; x++)
            {
                feature_map[x, y] = IntFromString(firstline[x]);
                if (y < mapy - 1) firstline = rowlines[y].Split(new char[] { ',' });
            }
    }

    public GameObject bridge_prefab, deepwater_prefab, water_prefab, river_prefab, beach1_prefab, beach2_prefab, beach3_prefab, stone_prefab, dirt_prefab, grass_prefab, sand_prefab;
    public GameObject citadel_prefab, hill_prefab, mountain_prefab, stones_prefab, tower_prefab, trees_prefab, village_prefab, hill_cave_prefab, keep_prefab, lith_prefab, mountain_cave_prefab, ruin_prefab;


    private void Awake()
    {
        MAP = this;        
    }

    private void Start()
    {
        DrawMap();
    }

    private int IntFromString(string s)
    {
        int result = 0;
        if (int.TryParse(s, out result)) { } else result = 0;
        return result;
    }

    public void DrawMap()
    {
        //north is 0,0,0
        //east is 0,0,270
        //south is 0,0,180
        //west is 0,0,90
        for(int y = 0; y < mapy; y++)
            for(int x = 0; x < mapx; x++)
            {
                if (terrain_map[x, y] == 0) Instantiate(bridge_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 180), this.transform); //bridge north
                if (terrain_map[x, y] == 1) Instantiate(bridge_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 90), this.transform); //bridge east
                if (terrain_map[x, y] == 2) Instantiate(bridge_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 0), this.transform); //bridge south
                if (terrain_map[x, y] == 3) Instantiate(bridge_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 270), this.transform); //bridge west

                if (terrain_map[x, y] == 8) Instantiate(river_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 180), this.transform); //river north
                if (terrain_map[x, y] == 9) Instantiate(river_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 90), this.transform); //river east
                if (terrain_map[x, y] == 10) Instantiate(river_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 0), this.transform); //river south
                if (terrain_map[x, y] == 12) Instantiate(river_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 270), this.transform); //river west

                if (terrain_map[x, y] == 4) Instantiate(deepwater_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 0), this.transform); //deepwater
                if (terrain_map[x, y] == 6) Instantiate(dirt_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 0), this.transform); //dirt
                if (terrain_map[x, y] == 7) Instantiate(grass_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 0), this.transform); //grass
                if (terrain_map[x, y] == 13) Instantiate(sand_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 0), this.transform); //sand
                if (terrain_map[x, y] == 14) Instantiate(water_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 0), this.transform); //shallow water
                if (terrain_map[x, y] == 15) Instantiate(stone_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 0), this.transform); //rock

                if (terrain_map[x, y] == 16) Instantiate(beach1_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 90), this.transform); //beach south
                if (terrain_map[x, y] == 18) Instantiate(beach1_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 180), this.transform); //beach east
                if (terrain_map[x, y] == 21) Instantiate(beach1_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 0), this.transform); //beach west
                if (terrain_map[x, y] == 22) Instantiate(beach1_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 270), this.transform); //beach north


                if (terrain_map[x, y] == 19) Instantiate(beach2_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 0), this.transform); //beach water ne
                if (terrain_map[x, y] == 20) Instantiate(beach2_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 270), this.transform); //beach water se
                if (terrain_map[x, y] == 28) Instantiate(beach2_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 180), this.transform); //beach water sw
                if (terrain_map[x, y] == 5) Instantiate(beach2_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 90), this.transform); //beach, water nw


                if (terrain_map[x, y] == 26) Instantiate(beach3_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 0), this.transform); //beach sand ne
                if (terrain_map[x, y] == 27) Instantiate(beach3_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 270), this.transform); //beach sand se
                if (terrain_map[x, y] == 24) Instantiate(beach3_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 180), this.transform); //beach sand sw
                if (terrain_map[x, y] == 25) Instantiate(beach3_prefab, new Vector3(x * -1, 0, y), Quaternion.Euler(90, 0, 90), this.transform); //beach sand nw

                
                if (feature_map[x, y] == 0) Instantiate(citadel_prefab, new Vector3(x * -1, .31f, y), Quaternion.identity, this.transform); //citadel
                if (feature_map[x, y] == 1) Instantiate(hill_prefab, new Vector3(x * -1, .31f, y), Quaternion.identity, this.transform); //hill (no cave)
                if (feature_map[x, y] == 3) Instantiate(mountain_prefab, new Vector3(x * -1, .31f, y), Quaternion.identity, this.transform); //mountain (no cave)
                if (feature_map[x, y] == 4) Instantiate(stones_prefab, new Vector3(x * -1, .31f, y), Quaternion.identity, this.transform); //standing stones
                if (feature_map[x, y] == 5) Instantiate(tower_prefab, new Vector3(x * -1, .31f, y), Quaternion.identity, this.transform); //tower
                if (feature_map[x, y] == 6) Instantiate(trees_prefab, new Vector3(x * -1, .31f, y), Quaternion.identity, this.transform); //trees
                if (feature_map[x, y] == 7) Instantiate(village_prefab, new Vector3(x * -1, .31f, y), Quaternion.identity, this.transform); //village
                if (feature_map[x, y] == 8) Instantiate(hill_cave_prefab, new Vector3(x * -1, .31f, y), Quaternion.identity, this.transform); //hill with cave
                if (feature_map[x, y] == 9) Instantiate(keep_prefab, new Vector3(x * -1, .31f, y), Quaternion.identity, this.transform); //keep
                if (feature_map[x, y] == 10) Instantiate(lith_prefab, new Vector3(x * -1, .31f, y), Quaternion.identity, this.transform); //monolith
                if (feature_map[x, y] == 11) Instantiate(mountain_cave_prefab, new Vector3(x * -1, .31f, y), Quaternion.identity, this.transform); //mountain with cave
                if (feature_map[x, y] == 12) Instantiate(ruin_prefab, new Vector3(x * -1, .31f, y), Quaternion.identity, this.transform); //ruins

            }
    }
}
