using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using Unity.VisualScripting;

public class CustomerManager : MonoBehaviour
{
    public GameObject customerPrebfab;
    public List<GameObject> customers = new List<GameObject>();

    public void MakeCustomer()
    {
        GameObject customer = Instantiate(customerPrebfab);
        customers.Add(customer);
    }
}
