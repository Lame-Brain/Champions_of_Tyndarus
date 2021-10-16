using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : SerializedMonoBehaviour
{
    public static MapManager MAP;

    public bool[,] terrain_map;

    [OnInspectorInit]
    private void initTable()
    { 
        terrain_map = new bool[66, 64]; 
    }

    private void Awake()
    {
        MAP = this;        
    }
}
