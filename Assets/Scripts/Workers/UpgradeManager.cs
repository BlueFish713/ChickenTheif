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
        SingletonManager.Get<WorkerManager>().cashierLevel += 1;
        EventManager.Publish(EventName.Upgrade);
    }

    [Button("UpgradeChef")]
    public void UpgradeChef()
    {
        SingletonManager.Get<WorkerManager>().chefLevel += 1;
        EventManager.Publish(EventName.Upgrade);
    }

    [Button("UpgradeFisher")]
    public void UpgradeFisher()
    {
        SingletonManager.Get<WorkerManager>().fisherLevel += 1;
        EventManager.Publish(EventName.Upgrade);
    }

    [Button("UpgradeDiver")]
    public void UpgradeDiver()
    {
        SingletonManager.Get<WorkerManager>().diverLevel += 1;
        EventManager.Publish(EventName.Upgrade);
    }
}
