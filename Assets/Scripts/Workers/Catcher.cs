using System.Collections.Generic;
using UnityEngine;

public enum CatcherState
{
    Wait,
    Convey,
    Return,
    Work
}

public class Catcher : Worker
{
    //물고기를 잡는 주기
    public float catchPeriod = 5f;

    //한번에 소지할 수 있는 최대 물고기 수
    public int maxFishCount = 5;

    //소지하고 있는 물고기(UntrimmedData) List
    List<UntrimmedData> untrimmedDatas = new List<UntrimmedData>();

    //Catcher의 상태
    public CatcherState nowState;

    WorkerManager WM;

    void Start()
    {
        WM = SingletonManager.Get<WorkerManager>();
    }

    //외부에서 호출, 상태 바꾸기
    public virtual void TryChangeState(CatcherState state)
    {
        nowState = state;
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

        //잡은 물고기를 저장
        untrimmedDatas.Add(caughtFish);
    }
}
