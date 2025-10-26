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
        Tween t = _cashier.transform.DOMoveX(_cashier._slot.transform.position.x, MoveBase.GetDuration(_cashier.transform.position, _cashier._slot.transform.position, _cashier.returnSpeed));
        _cashier.GetComponent<SpriteRenderer>().flipX = MoveBase.GetFlipX(_cashier.transform.position, _cashier._slot.transform.position);
        t.OnComplete(OnReturnedToSlot);
    }

    void OnReturnedToSlot()
    {
        _cashier.TryChangeState(CashierStateType.CashierWaitState);
    }
    public override void Update()
    {
        _cashier.GetComponent<Animator>().Play("CashierWalk");
    }
}