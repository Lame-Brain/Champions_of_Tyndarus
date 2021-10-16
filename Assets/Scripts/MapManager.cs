using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : SerializedMonoBehaviour
{
    public static MapManager MAP;

    public TextAsset csvMap;
    public int[,] terrain_map;

    [Button(ButtonSizes.Small)]
    private void LoadCSV()
    {
        string[] rowlines = csvMap.text.Split(new char[] { '\n' });
        string[] firstline = rowlines[0].Split(new char[] { ','} );
        terrain_map = new int[firstline.Length, rowlines.Length];
        for (int y = 0; y < rowlines.Length; y++)
            for(int x = 0; x < firstline.Length; x++)
            {
                terrain_map[x, y] = IntFromString(firstline[x]);
                if(y < rowlines.Length - 1) firstline = rowlines[0].Split(new char[] { ',' });
            }
    }

    private void Awake()
    {
        MAP = this;        
    }

    private int IntFromString(string s)
    {
        int result = 0;
        if (int.TryParse(s, out result)) { } else result = 0;
        return result;
    }
}
