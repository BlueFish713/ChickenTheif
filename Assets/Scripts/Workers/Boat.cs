using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public float period = 30; //배가 바다에 있는 시간
    public float moveX = 30;
    public Ease inease = Ease.InCubic;
    public Ease outease = Ease.OutCubic;
    public List<Fisher> loadedFishers = new List<Fisher>(); //배에 탄 어부 배열
    float boatX = 0;

    public bool onOcean = false;

    WorkerManager WM;

    void Start()
    {
        onOcean = false;
        WM = SingletonManager.Get<WorkerManager>();
    }

    void Awake()
    {
        boatX = transform.position.x;
        //BoatGo 이벤트가 발생하면 GoCoroutine, 애니메이션을 실행함
        EventManager.Subscribe(EventName.BoatGo, () =>
        {
            onOcean = true;
            StartCoroutine(GoCoroutine());
            transform.DOMoveX(boatX+moveX, 5).SetEase(inease).SetAutoKill();
        });

        //BoatRetrunStart 이벤트가 발생하면 애니메이션을 실행함
        EventManager.Subscribe(EventName.BoatRetrunStart, () =>
        {
            Tween t = transform.DOMoveX(boatX, 5).SetEase(outease).SetAutoKill();
            t.OnComplete(() => EventManager.Publish(EventName.BoatRetrunFinished));
        });

        //BoatRetrunFinished 이벤트가 발생하면 WhenBoatReturned를 실행함
        EventManager.Subscribe(EventName.BoatRetrunFinished, WhenBoatReturned);
    }

    //배에 어부를 실을 때 호출
    public void Load(Fisher fisher)
    {
        fisher.transform.SetParent(transform);
        //fisher.TryChangeState(CatcherStateType.CatcherWorkState);
        if (fisher.nowStateType == CatcherStateType.CatcherWorkState) loadedFishers.Add(fisher);
        CheckToGo();
    }

    //배 출발해도 되는지 체크 -> 정원이 맞으면 BoatGo 이벤트 호출
    [Button("CheckToGo")]
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
        onOcean = false;
        //배에 탄 사람들 운반하도록 시킴
        foreach (var fisher in loadedFishers)
        {
            fisher.TryChangeState(CatcherStateType.CatcherConveyState);
            fisher.transform.SetParent(null);
        }

        //배에 탄 사람들 비움
        loadedFishers.Clear();
    }
}