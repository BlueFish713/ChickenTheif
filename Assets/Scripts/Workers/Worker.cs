using UnityEngine;

public class Worker : MonoBehaviour
{
    protected WorkerManager WM;
    public Slot _slot;
    public virtual void Assign(Slot slot)
    {
        WM = SingletonManager.Get<WorkerManager>();
        _slot = slot;
    }
}
