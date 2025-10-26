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
        _cashier.trimmedDatas.Reverse();
        foreach (TrimmedData data in _cashier.trimmedDatas)
        {
            int price = SingletonManager.Get<Repository>().price[data.fish];
            _cashier.Earn(price);
            _cashier.fishLayout.UnLoad();
            yield return new WaitForSeconds(0.2f);
        }
        _cashier.trimmedDatas.Clear();

        SingletonManager.Get<CustomerManager>().NextCustomer();

        _cashier.TryChangeState(CashierStateType.CashierWaitState);
    }
}