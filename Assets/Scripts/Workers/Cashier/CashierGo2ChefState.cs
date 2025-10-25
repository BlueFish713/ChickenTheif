using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

public class CashierGo2ChefState : CashierState
{
    Chef chef;
    int index = 0;
    public override void Handle(Cashier cashier)
    {
        base.Handle(cashier);
        index = 0;
        Repeat();
    }

    void Repeat()
    {
        if (index < WM.chefs.Count)
        {
            chef = WM.chefs[index];
            ReceiveTrimmedDatas(chef.trimmedDatas);
            Tween t = _cashier.transform.DOMoveX(chef.transform.position.x, _cashier.conveySpeed);
            t.OnComplete(Repeat);
            index++;
        }
        else
        {
            _cashier.TryChangeState(CashierStateType.CashierReturnState);
        }
    }
    
    void ReceiveTrimmedDatas(List<TrimmedData> datas)
    {
        foreach (TrimmedData fish in datas)
        {
            TrimmedData data = new TrimmedData();
            data.fish = fish.fish;
            data.rate = fish.rate;
            _cashier.trimmedDatas.Add(data);
        }
    }
}