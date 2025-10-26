using Unity.VisualScripting;
using UnityEngine;

public class CashierWaitState : CashierState
{

    public override void Handle(Cashier cashier)
    {
        base.Handle(cashier);

        if (_cashier.untrimmedDatas.Count != 0)
        {
            _cashier.TryChangeState(CashierStateType.CashierAuctionState);
        }
        else if (_cashier.trimmedDatas.Count != 0)
        {
            _cashier.TryChangeState(CashierStateType.CashierSellState);
        }
    }
    
    public override void Update()
    {
        _cashier.GetComponent<Animator>().Play("CashierWait");
    }
}