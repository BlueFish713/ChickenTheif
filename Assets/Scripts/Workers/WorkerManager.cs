#nullable enable

using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[Singleton, RequireInScene]
public class WorkerManager : MonoBehaviour
{
    [BoxGroup("Worker List")] public List<Cashier> cashiers = new List<Cashier>();
    [BoxGroup("Worker List")] public List<Chef> chefs = new List<Chef>();
    [BoxGroup("Worker List")] public List<Fisher> fishers = new List<Fisher>();
    [BoxGroup("Worker List")] public List<Diver> divers = new List<Diver>();

    public Chef? GetAvailableChef()
    {
        for (int i = chefs.Count - 1; i >= 0; i--)
        {
            if (chefs[i] == null) continue;
            if (chefs[i].working) return chefs[i];
        }
        return null;
    }
}
