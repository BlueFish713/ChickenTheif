using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public float period = 30; //배가 바다에 있는 시간
    public List<Fisher> loadedFishers = new List<Fisher>(); //배에 탄 어부 배열
        
    WorkerManager WM;

    void Start()
    {
        WM = SingletonManager.Get<WorkerManager>();
    }

    void Awake()
    {
        //BoatGo 이벤트가 발생하면 GoCoroutine을 실행함
        EventManager.Subscribe(EventName.BoatGo, () => StartCoroutine(GoCoroutine()));

        //BoatRetrunFinished 이벤트가 발생하면 WhenBoatReturned를 실행함
        EventManager.Subscribe(EventName.BoatRetrunFinished, WhenBoatReturned);
    }

    //배에 어부를 실을 때 호출
    public void Load(Fisher fisher)
    {
        fisher.TryChangeState(CatcherStateType.WorkState);
        if (fisher.nowStateType == CatcherStateType.WorkState) loadedFishers.Add(fisher);
        CheckToGo();
    }

    //배 출발해도 되는지 체크 -> 정원이 맞으면 BoatGo 이벤트 호출
    void CheckToGo()
    {
        if (WM.fishers.Count <= loadedFishers.Count)
        {
            EventManager.Publish(EventName.BoatGo);
        }
    }

    //BoatGo -> 
    IEnumerator GoCoroutine()
    {
        //period만큼 기다림
        yield return new WaitForSecondsRealtime(period);

        //배에 탄 사람들이 period 동안 물고기를 잡은 것으로 함
        foreach (var fisher in loadedFishers)
        {
            fisher.CatchWhileTime(period);
        }

        //배가 도착(BoatRetrunStart 이벤트)
        EventManager.Publish(EventName.BoatRetrunStart);
    }
    
    //BoatRetrunFinished -> 
    void WhenBoatReturned()
    {
        //배에 탄 사람들 운반하도록 시킴
        foreach (var fisher in loadedFishers)
        {
            fisher.TryChangeState(CatcherStateType.ConveyState);
        }

        //배에 탄 사람들 비움
        loadedFishers.Clear();
    }
}