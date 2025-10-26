#nullable enable

using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[Singleton, RequireInScene]
public class UpgradeManager : MonoBehaviour
{
    public void Upgrade(WorkerType workerType)
    {
        switch (workerType)
        {
            case WorkerType.Cashier:
                UpgradeCashier();
                break;
            case WorkerType.Chef:
                UpgradeChef();
                break;
            case WorkerType.Fisher:
                UpgradeFisher();
                break;
            case WorkerType.Diver:
                UpgradeDiver();
                break;
        }
    }
    
    [Button("UpgradeCashier")]
    public void UpgradeCashier()
    {
        if (SingletonManager.Get<WorkerManager>().cashierLevel < 4)
        SingletonManager.Get<WorkerManager>().cashierLevel += 1;
        EventManager.Publish(EventName.Upgrade);
    }

    [Button("UpgradeChef")]
    public void UpgradeChef()
    {
        if (SingletonManager.Get<WorkerManager>().chefLevel < 4)
        SingletonManager.Get<WorkerManager>().chefLevel += 1;
        EventManager.Publish(EventName.Upgrade);
    }

    [Button("UpgradeFisher")]
    public void UpgradeFisher()
    {
        if (SingletonManager.Get<WorkerManager>().fisherLevel < 4)
        SingletonManager.Get<WorkerManager>().fisherLevel += 1;
        EventManager.Publish(EventName.Upgrade);
    }

    [Button("UpgradeDiver")]
    public void UpgradeDiver()
    {
        if (SingletonManager.Get<WorkerManager>().diverLevel < 4)
        SingletonManager.Get<WorkerManager>().diverLevel += 1;
        EventManager.Publish(EventName.Upgrade);
    }
}
