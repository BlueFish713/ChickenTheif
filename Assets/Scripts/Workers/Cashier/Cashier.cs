using System.Collections.Generic;
using UnityEngine;

public enum CashierStateType
{
    CashierWaitState,
    CashierGo2CatcherState,
    CashieGo2ChefState,
    CashieReturnState,
    CashieSellState,
    CashieAuctionState
}
public class Cashier : Worker
{
    List<UntrimmedData> untrimmedDatas = new List<UntrimmedData>();
    List<TrimmedData> trimmedDatas = new List<TrimmedData>();
    CashierState nowState;
    public CashierStateType nowStateType;
    WorkerManager WM;

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
        nowState.Exit();
        nowStateType = state;
        nowState = ReflectionBase.CreateInstanceFromType(ReflectionBase.TypeFromEnum(nowStateType));

    }

    public void AuctionConfirm()
    {
        // 말풍선 띄우기
        // 돈 벌기
    }
}
