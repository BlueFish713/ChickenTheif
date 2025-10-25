using DG.Tweening;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public WorkerType workerType;
    [SerializeField] private Worker _worker;
    [SerializeField] private Vector3 spawnOffset;

    public void Assign(Worker worker)
    {
        _worker = worker;
        _worker.transform.position = spawnOffset + transform.position;
        _worker.Assign(this);
    }

    public bool Assigned()
    {
        if (_worker == null) return true;
        else return false;
    }
}
