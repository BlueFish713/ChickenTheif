using DG.Tweening;
using UnityEngine;

public class Customer : MonoBehaviour
{
    CustomerSlot _customerSlot;
    public float moveSpeed;
    public Ease ease;
    public GameObject speechBubblePrefab;
    GameObject speechBubbleInstance;
    SpeechBubble speechBubbleCode;

    void Awake()
    {
        speechBubbleInstance = Instantiate(speechBubblePrefab);
        speechBubbleCode = speechBubbleInstance.GetComponent<SpeechBubble>();
        speechBubbleCode.Setup(transform);
    }
    public void Assign(CustomerSlot customerSlot)
    {
        _customerSlot = customerSlot;   
        if (_customerSlot != null)
            transform.DOMove(_customerSlot.transform.position, moveSpeed).SetEase(ease).SetAutoKill();
    }

    public void CallPrice(int price)
    {
        speechBubbleCode.Show(string.Format("{0}원!", price));
    }
}
