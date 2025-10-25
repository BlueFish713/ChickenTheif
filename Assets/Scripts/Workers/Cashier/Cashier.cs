using System.Collections.Generic;
using System.ComponentModel.Design;
using DG.Tweening;
using UnityEngine;

public enum CashierStateType
{
    CashierWaitState,
    CashierGo2CatcherState,
    CashierGo2ChefState,
    CashierReturnState,
    CashierSellState,
    CashierAuctionState
}
public class Cashier : Worker
{
    
    public List<UntrimmedData> untrimmedDatas = new List<UntrimmedData>();
    public List<TrimmedData> trimmedDatas = new List<TrimmedData>();
    CashierState nowState;
    public CashierStateType nowStateType;
    public float conveySpeed;
    public float returnSpeed;
    public float rushSpeed = 4;
    public List<Catcher> firstRateCathcers = new List<Catcher>();

    public FishLayout fishLayout;

    public Ease moveEase = Ease.Linear;

    void Awake()
    {
        // EventManager.Subscribe(EventName.CallCashier, () =>
        // {
        //     if (nowStateType == CashierStateType.CashierWaitState)
        //         TryChangeState(CashierStateType.CashierGo2ChefState);
        // });
    }
    
    void Start()
    {
        WM = SingletonManager.Get<WorkerManager>();
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
    public virtual void TryChangeState(CashierStateType state)
    {
        if (nowState != null) nowState.Exit();
        nowStateType = state;
        nowState = ReflectionBase.CreateInstanceFromType(ReflectionBase.TypeFromEnum(nowStateType));
        nowState.Handle(this);
    }
}
