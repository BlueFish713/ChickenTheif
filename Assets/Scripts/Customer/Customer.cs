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

    public string girl = "Girl";

    void Awake()
    {
        speechBubbleInstance = Instantiate(speechBubblePrefab);
        speechBubbleCode = speechBubbleInstance.GetComponent<SpeechBubble>();
        speechBubbleCode.Setup(transform);
        girl = Random.Range(0, 2) == 0 ? "" : "Girl";
    }
    public void Assign(CustomerSlot customerSlot)
    {
        _customerSlot = customerSlot;
        if (_customerSlot != null)
        {
            Walk();
            transform.DOMove(_customerSlot.transform.position, moveSpeed).SetEase(ease).SetAutoKill().OnComplete(Wait);
        }
    }

    public void CallPrice(int price)
    {
        speechBubbleCode.Show(string.Format("{0}원!", price));
    }

    public void Walk()
    {
        GetComponent<Animator>().Play("Walk" + girl);
    }
    public void Wait()
    {
        GetComponent<Animator>().Play("Wait" + girl);
    }
}
