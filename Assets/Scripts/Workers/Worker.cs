using UnityEngine;

public class Worker : MonoBehaviour
{
    protected Slot _slot;
    public void Assign(Slot slot)
    {
        _slot = slot;
    }
}
