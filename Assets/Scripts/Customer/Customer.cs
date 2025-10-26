using DG.Tweening;
using UnityEngine;

public class Customer : MonoBehaviour
{
    CustomerSlot _customerSlot;
    public float moveSpeed;
    public Ease ease;
    public void Assign(CustomerSlot customerSlot)
    {
        _customerSlot = customerSlot;   
        if (_customerSlot != null)
            transform.DOMove(_customerSlot.transform.position, moveSpeed).SetEase(ease).SetAutoKill();
    }

    public void CallPrice(int price)
    {
        // 말풍선 띄우기
        Debug.Log(price);
    }
}
