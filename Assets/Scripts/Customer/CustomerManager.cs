using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public GameObject customerPrebfab;
    private List<GameObject> customers = new List<GameObject>();

    private void MakeCustomer()
    {
        GameObject customer = Instantiate(customerPrebfab);
        customers.Add(customer);
    }

    void Auction()
    {
        for (int i = 0; i < 3; i++)
        {
            Random.Range(0, customers.Count); // 만드는중
        }
    }
}
