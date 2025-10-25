using System;
using System.Collections.Generic;
using UnityEngine;

public class Repository : MonoBehaviour // 싱글톤
{
     public static Repository Instance { get; private set; }
    public Dictionary<FishType, int> price = new Dictionary<FishType, int>
    {
        {FishType.StarFish, 1000},
        {FishType.BlueFish, 2000}
    };
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}


