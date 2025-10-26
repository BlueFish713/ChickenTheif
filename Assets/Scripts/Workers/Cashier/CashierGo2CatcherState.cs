using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CashierGo2CatcherState : CashierState
{
    Catcher catcher;
    public int index = 0;
    float _rushSpeed;
    public override void Handle(Cashier cashier)
    {
        base.Handle(cashier);
        index = 0;
        _rushSpeed = _cashier.rushSpeed;
        Repeat();
    }

    void Repeat()
    {
        if (index < _cashier.firstRateCathcers.Count)
        {
            catcher = _cashier.firstRateCathcers[index];
            Tween t = _cashier.transform.DOMoveX(catcher.transform.position.x, MoveBase.GetDuration(_cashier.transform.position, catcher.transform.position, _cashier.rushSpeed)).SetEase(_cashier.moveEase).SetAutoKill();
            index++;
            t.OnComplete(() =>
            {
                if (catcher.firstData != null) _cashier.untrimmedDatas.Add((UntrimmedData)catcher.firstData);
                
                catcher.firstData = null;
                catcher.hasFirstData = false;
                if (catcher.firstData != null) _cashier.fishLayout.Load((UntrimmedData)catcher.firstData);
                GameObject.Destroy(catcher.firstDisplay);

                Repeat();
            });
        }
        else
        {
            _cashier.firstRateCathcers.Clear();
            _cashier.TryChangeState(CashierStateType.CashierReturnState);
        }
    }

    void ReceiveFirstRateDatas(List<FirstData> datas)
    {
        foreach (FirstData fish in datas)
        {
            UntrimmedData data = new UntrimmedData();
            data.fish = fish.untrimmedData.fish;
            data.rate = fish.untrimmedData.rate;
            _cashier.untrimmedDatas.Add(data);
        }
    }
}