using UnityEngine;

public class CustomerSlot : MonoBehaviour
{
    public Customer _cus = null;

    public void Assign(Customer customer)
    {
        _cus = customer;
        _cus.Assign(this);
    }
    public void Deassign()
    {
        _cus = null;
    }
    
    public bool Assigned()
    {
        return _cus != null;
    }
}