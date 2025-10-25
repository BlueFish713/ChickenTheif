#nullable enable

using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[Singleton, RequireInScene]
public class WorkerManager : MonoBehaviour
{
    const int maxCashier = 3;
    const int maxChef = 3;
    const int maxFisher = 3;
    const int maxDiver = 3;

    [BoxGroup("Worker List")] public List<Cashier> cashiers = new List<Cashier>();
    [BoxGroup("Worker List")] public List<Chef> chefs = new List<Chef>();
    [BoxGroup("Worker List")] public List<Fisher> fishers = new List<Fisher>();
    [BoxGroup("Worker List")] public List<Diver> divers = new List<Diver>();
    
    [Space(5)]
    [BoxGroup("Worker Prefab")] public GameObject cashierPrefab;
    [BoxGroup("Worker Prefab")] public GameObject chefPrefab;
    [BoxGroup("Worker Prefab")] public GameObject fisherPrefab;
    [BoxGroup("Worker Prefab")] public GameObject diverPrefab;

    [Space(5)]
    [BoxGroup("Slot List")] public List<Slot> cashierSlots = new List<Slot>();
    [BoxGroup("Slot List")] public List<Slot> chefSlots = new List<Slot>();
    [BoxGroup("Slot List")] public List<Slot> fisherSlots = new List<Slot>();
    [BoxGroup("Slot List")] public List<Slot> diverSlots = new List<Slot>();
    [SerializeField, Space(5)] public Boat boat;
    [SerializeField, Space(5)] public Transform fisherSpawnPosition;

    [Button("CreateChef")]
    public void CreateChef()
    {
        CreateWorker(WorkerType.Chef);
    }

    [Button("CreateCashier")]
    public void CreateCashier()
    {
        CreateWorker(WorkerType.Cashier);
    }

    [Button("CreateFisher")]
    public void CreateFisher()
    {
        CreateWorker(WorkerType.Fisher);
    }

    [Button("CreateDiver")]
    public void CreateDiver()
    {
        CreateWorker(WorkerType.Diver);
    }

    public Chef? GetAvailableChef()
    {
        for (int i = chefs.Count - 1; i >= 0; i--)
        {
            if (chefs[i] == null) continue;
            if (!chefs[i].working) return chefs[i];
        }
        return null;
    }

    public void CreateWorker(WorkerType workerType)
    {
        int index = 0;
        switch (workerType)
        {
            case WorkerType.Cashier:
                index = GetAvailableSlot(cashierSlots);
                if (index != -1)
                {
                    GameObject worker = Instantiate(cashierPrefab);
                    if (worker.TryGetComponent<Cashier>(out Cashier component))
                    {
                        cashiers.Add(component);
                        cashierSlots[index].Assign(component);
                    }
                    else return;
                }
                break;
            case WorkerType.Chef:
                index = GetAvailableSlot(chefSlots);
                if (index != -1)
                {
                    GameObject worker = Instantiate(chefPrefab);
                    if (worker.TryGetComponent<Chef>(out Chef component))
                    {
                        chefs.Add(component);
                        chefSlots[index].Assign(component);
                    }
                    else return;
                }
                break;
            case WorkerType.Fisher:
                index = GetAvailableSlot(fisherSlots);
                if (index != -1)
                {
                    GameObject worker = Instantiate(fisherPrefab);
                    if (worker.TryGetComponent<Fisher>(out Fisher component))
                    {
                        fishers.Add(component);
                        fisherSlots[index].Assign(component);
                    }
                    else return;
                }
                break;
            case WorkerType.Diver:
                index = GetAvailableSlot(diverSlots);
                if (index != -1)
                {
                    GameObject worker = Instantiate(diverPrefab);
                    if (worker.TryGetComponent<Diver>(out Diver component))
                    {
                        divers.Add(component);
                        diverSlots[index].Assign(component);
                    }
                    else return;
                }
                break;
        }
    }
    
    private int GetAvailableSlot(List<Slot> slotList)
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i] == null) continue;
            if (slotList[i].Assigned()) return i;
        }
        return -1;
    }
}
