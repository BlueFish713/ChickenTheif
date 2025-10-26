using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

[Singleton, RequireInScene]
public class Repository : MonoBehaviour // 싱글톤
{
    //public static Repository Instance { get; private set; }

    // [SerializedDictionary("FishType", "Price")]
    public Dictionary<FishType, int> price = new Dictionary<FishType, int>
    {
        {FishType.BaekSangARi, 50000}, 
        {FishType.BaJiRak, 18000},
        {FishType.BokEo, 4500},
        {FishType.DaeGu, 15000},
        {FishType.GarChi, 25000},
        {FishType.GaRiBi, 6000},
        {FishType.GoDeungEo, 10000},
        {FishType.GwangEo, 35000},
        {FishType.HaePaRi, 2000},
        {FishType.HaeSam, 45000},
        {FishType.JanFish, 1000},
        {FishType.JangEo, 26000},
        {FishType.JeonBok, 4600},
        {FishType.JeonEo, 2300},
        {FishType.KiJoGae, 12000},
        {FishType.MunEo, 18000},
        {FishType.NakJi, 22000},
        {FishType.OJingEo, 15000},
        {FishType.OkDom, 10000},
        {FishType.SeongGe, 2500 }
        
    };
    // void Awake()
    // {
    //     if (Instance == null)
    //         Instance = this;
    //     else
    //         Destroy(gameObject);
    // }
}


