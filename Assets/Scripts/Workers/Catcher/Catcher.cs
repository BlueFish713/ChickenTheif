using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NUnit.Framework.Constraints;
using System;
using Unity.VisualScripting;

public enum CatcherStateType
{
    CatcherWaitState,
    CatcherConveyState,
    CatcherReturnState,
    CatcherWorkState
}

[Serializable]
public struct FirstData
{
    public UntrimmedData untrimmedData;
    public bool targeted;
}

public class Catcher : Worker
{
    //물고기를 잡는 주기
    public float catchPeriod = 5f;

    //한번에 소지할 수 있는 최대 물고기 수
    public int maxFishCount = 8;

    //소지하고 있는 물고기(UntrimmedData) List
    public List<UntrimmedData> untrimmedDatas = new List<UntrimmedData>();
    public UntrimmedData? firstData;
    public bool hasFirstData;

    public FishLayout fishLayout;

    //Catcher의 상태
    CatcherState nowState;
    public CatcherStateType nowStateType;

    //Catcher의 Convey속도
    [SerializeField] public float conveySpeed;

    public GameObject firstDisplayPrefab;
    public GameObject firstDisplay;

    public Ease moveEase = Ease.Linear;

    void Start()
    {
        base.WM = SingletonManager.Get<WorkerManager>();
    }

    void Update()
    {
        if (nowState != null) nowState.Update();
    }

    void FixedUpdate()
    {
        if (nowState != null) nowState.FixedUpdate();
    }

    //외부에서 호출, 상태 바꾸기
    public virtual void TryChangeState(CatcherStateType state)
    {
        if (nowState != null) nowState.Exit();
        nowStateType = state;
        nowState = ReflectionBase.CreateInstanceFromType(ReflectionBase.TypeFromEnum(nowStateType));
        nowState.Handle(this);
    }

    //물고기 잡기
    public virtual void Catch()
    {
        //만약 최대 소지 개수에 도달해있으면 return;
        if (untrimmedDatas.Count >= maxFishCount)
        {
            return;
        }

        //대충 Random이용해서 UntrimmedData 생성(구현 부탁)
        UntrimmedData caughtFish = new UntrimmedData();

        int rand = (int)UnityEngine.Random.Range(1, 5);
        if (rand == 3 && !hasFirstData)
        {
            caughtFish.fish = FishType.BlueFish;
            caughtFish.rate = RateType.First;

            firstData = caughtFish;
            hasFirstData = true;

            firstDisplay = Instantiate(firstDisplayPrefab);
            firstDisplay.transform.position = transform.position;
            firstDisplay.GetComponent<SpriteRenderer>().sprite = SingletonManager.Get<FishImageRepository>().fishImages[caughtFish.fish];
        }
        else
        {
            caughtFish.fish = FishType.StarFish;
            caughtFish.rate = RateType.Second;

            untrimmedDatas.Add(caughtFish);
            fishLayout.Load(caughtFish);
        }

        //잡은 물고기를 저장
    }
}
