using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using Unity.VisualScripting;

public class CustomerManager : MonoBehaviour
{
    public GameObject customerPrebfab;
    private List<GameObject> customers = new List<GameObject>();
    public int priceCallingRepeat = 3;
    private Repository repository;

    void Start()
    {
        repository = SingletonManager.Get<Repository>();
    }

    public void MakeCustomer()
    {
        GameObject customer = Instantiate(customerPrebfab);
        customers.Add(customer);
    }

    void Auction(Cashier cashier, UntrimmedData data)
    {
        int originalPrice = repository.price[data.fish];
        float priceUp = UnityEngine.Random.Range(5f, 10f); // 가격 뻥튀기 배율
        int price = (int)(Math.Round(originalPrice * priceUp / 100f) * 100f); // xx00원 형태로 정리
        StartCoroutine(AuctionCoroutine(originalPrice, price, cashier));
    }

    IEnumerator AuctionCoroutine(int originalPrice, int price, Cashier cashier)
    {
        for (int i = 0; i < priceCallingRepeat; i++)
        {
            int index = UnityEngine.Random.Range(0, customers.Count);
            Customer customerCode = customers[index].GetComponent<Customer>();
            float lerp = Mathf.Lerp(originalPrice, price, 1f / priceCallingRepeat * (i + 1));
            customerCode.CallPrice((int)(Math.Round(lerp / 100f) * 100f));

            yield return new WaitForSeconds(0.5f);
        }
        
        cashier.AuctionConfirm();
    }
}
