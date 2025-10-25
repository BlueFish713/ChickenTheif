using System.Collections;
using UnityEngine;

public class CashierSellState : CashierState
{
    public override void Handle(Cashier cashier)
    {
        base.Handle(cashier);
        _cashier.StartCoroutine(Sell());
    }

    IEnumerator Sell()
    {
        foreach (TrimmedData data in _cashier.trimmedDatas)
        {
            int price = SingletonManager.Get<Repository>().price[data.fish];
            // 돈 벌기
            yield return new WaitForSeconds(0.1f);
        }
        _cashier.trimmedDatas.Clear();

        _cashier.TryChangeState(CashierStateType.CashierWaitState);
    }
}