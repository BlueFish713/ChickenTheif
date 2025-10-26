using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CashierGo2ChefState : CashierState
{
    Chef chef;
    int index = 0;
    float _conveySpeed;
    public override void Handle(Cashier cashier)
    {
        base.Handle(cashier);
        index = 0;
        _conveySpeed = _cashier.conveySpeed;
        Repeat();
    }

    void Repeat()
    {
        if (index < WM.chefs.Count)
        {
            chef = WM.chefs[index];
            index++;
            Tween t = _cashier.transform.DOMoveX(chef.transform.position.x, MoveBase.GetDuration(_cashier.transform.position, chef.transform.position, _conveySpeed)).SetEase(_cashier.moveEase).SetAutoKill();

            t.OnComplete(() =>
            {
                ReceiveTrimmedDatas(chef.trimmedDatas);
                chef.trimmedDatas.Clear();
                Repeat(); 
            });
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
            _cashier.fishLayout.Load(data);
        }
    }
    public override void Update()
    {
        _cashier.GetComponent<Animator>().Play("CashierWalk");
    }
}