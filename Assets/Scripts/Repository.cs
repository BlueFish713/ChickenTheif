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
    
    public Dictionary<FishType, string> fishName = new Dictionary<FishType, string>
    {
        {FishType.BaekSangARi, "백상아리"}, 
        {FishType.BaJiRak, "바지락"},
        {FishType.BokEo, "복어"},
        {FishType.DaeGu, "대구"},
        {FishType.GarChi, "갈치"},
        {FishType.GaRiBi, "가리비"},
        {FishType.GoDeungEo, "고등어"},
        {FishType.GwangEo, "광어"},
        {FishType.HaePaRi, "해파리"},
        {FishType.HaeSam, "해삼"},
        {FishType.JanFish, "잔물고기"},
        {FishType.JangEo, "장어"},
        {FishType.JeonBok, "전복"},
        {FishType.JeonEo, "전어"},
        {FishType.KiJoGae, "키조개"},
        {FishType.MunEo, "문어"},
        {FishType.NakJi, "낙지"},
        {FishType.OJingEo, "오징어"},
        {FishType.OkDom, "옥돔"},
        {FishType.SeongGe, "성게"}
        
    };
    // void Awake()
    // {
    //     if (Instance == null)
    //         Instance = this;
    //     else
    //         Destroy(gameObject);
    // }
}


