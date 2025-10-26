using System.Collections;
using System;
using DG.Tweening;
using UnityEngine;
using System.Collections.Generic;

public class CashierAuctionState : CashierState
{
    public GameObject customManager;
    public override void Handle(Cashier cashier)
    {
        base.Handle(cashier);
        Auction();
    }
    void Auction()
    {
        Repository repository = SingletonManager.Get<Repository>();
        int originalPrice = repository.price[_cashier.untrimmedDatas[0].fish];
        float priceUp = UnityEngine.Random.Range(5f, 10f); // 가격 뻥튀기 배율
        int price = (int)(Math.Round(originalPrice * priceUp / 100f) * 100f); // xx00원 형태로 정리
        _cashier.StartCoroutine(AuctionCoroutine(originalPrice, price, _cashier.untrimmedDatas[0].fish));
    }

    IEnumerator AuctionCoroutine(int originalPrice, int price, FishType fish)
    {
        CustomerManager customManagerCode = SingletonManager.Get<CustomerManager>();
        List<GameObject> customers = customManagerCode.customers;

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 4; i++)
        {
            int index = UnityEngine.Random.Range(0, customers.Count);
            Customer customerCode = customers[index].GetComponent<Customer>();
            float lerp = Mathf.Lerp(originalPrice, price, 1f / 4 * (i + 1));
            customerCode.CallPrice((int)(Math.Round(lerp / 100f) * 100f));

            yield return new WaitForSeconds(0.5f);
        }

        _cashier.Say(string.Format("최고급 {0}, {1}원에 낙찰되었습니다!!", SingletonManager.Get<Repository>().fishName[fish], price));
        _cashier.Earn(price);
        _cashier.untrimmedDatas.Clear();
        _cashier.TryChangeState(CashierStateType.CashierWaitState);
    }
}