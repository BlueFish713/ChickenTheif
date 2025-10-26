#nullable enable

using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[Singleton, RequireInScene]
public class MoneyManager : MonoBehaviour
{
    public int balance;

    public int upgradeCost = 100;
    public int createCost = 100;
}
