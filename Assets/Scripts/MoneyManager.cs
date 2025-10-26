#nullable enable

using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[Singleton, RequireInScene]
public class MoneyManager : MonoBehaviour
{
    public int balance = 0;
    public float margin = 0.05f;
    public int upgradeCost = 100;
    public int createCost = 100;
    public int activeRate = 0;
}
