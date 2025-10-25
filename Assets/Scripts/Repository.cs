using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

[Singleton, RequireInScene]
public class Repository : MonoBehaviour // 싱글톤
{
    //public static Repository Instance { get; private set; }

    [SerializedDictionary("FishType", "Price")]
    public SerializedDictionary<FishType, int> price = new SerializedDictionary<FishType, int>
    {
        {FishType.StarFish, 1000},
        {FishType.BlueFish, 2000}
    };
    // void Awake()
    // {
    //     if (Instance == null)
    //         Instance = this;
    //     else
    //         Destroy(gameObject);
    // }
}


