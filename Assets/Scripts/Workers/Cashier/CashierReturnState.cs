using System.Collections;
using UnityEngine;
using DG.Tweening;

public class CashierReturnState : CashierState
{
    public override void Handle(Cashier cashier)
    {
        base.Handle(cashier);
        MoveToSlot();
    }

    void MoveToSlot()
    {
        Tween t = _cashier.transform.DOMoveX(_cashier._slot.transform.position.x, _cashier.conveySpeed);
        t.OnComplete(OnReturnedToSlot);
    }

    void OnReturnedToSlot()
    {
        _cashier.TryChangeState(CashierStateType.CashierWaitState);
    }
}