using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

[Singleton, RequireInScene]
public class CustomerManager : MonoBehaviour
{
    public GameObject customerPrebfab;
    public Transform spawnPos;
    public List<GameObject> customers = new List<GameObject>();
    [BoxGroup("Slot List")] public List<CustomerSlot> customerSlots = new List<CustomerSlot>();

    int index = 0;

    void Awake()
    {
        InvokeRepeating("InitLine", 0, 0.2f);
    }

    [Button("Make")]
    public void MakeCustomer()
    {
        index = GetAvailableSlot(customerSlots);
        if (index != -1)
        {
            GameObject customer = Instantiate(customerPrebfab);
            customer.transform.position = spawnPos.position;
            if (customer.TryGetComponent<Customer>(out Customer component))
            {
                customers.Add(customer);
                customerSlots[index].Assign(component);
            }
            else return;
        }
    }

    private int GetAvailableSlot(List<CustomerSlot> slotList)
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i] == null) continue;
            if (!slotList[i].Assigned()) return i;
        }
        return -1;
    }

    [Button("InitLine")]
    public void InitLine()
    {
        for (int i = 0; i < customerSlots.Count; i++)
        {
            if (customerSlots[i] == null) continue;
            if (!customerSlots[i].Assigned())
            {
                if (i+1 == customerSlots.Count || !customerSlots[i+1].Assigned())
                {
                    MakeCustomer();
                    break;
                }
                else
                {
                    customerSlots[i].Assign(customerSlots[i + 1]._cus);
                    customerSlots[i + 1].Deassign();
                    break;
                }
            }
        }
    }
    
    
[Button("NextCustomer")]
    public void NextCustomer()
    {
        customerSlots[0].Deassign();
        Destroy(customers[0], 0.1f);
        customers.RemoveAt(0);
    }
}
