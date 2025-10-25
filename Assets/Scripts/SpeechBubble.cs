using UnityEngine;
using TMPro;

public class SpeechBubble : MonoBehaviour
{
    public TMP_Text textMesh;
    public SpriteRenderer bubbleRenderer;
    public float showTime = 2f; // 말풍선 유지 시간
    public Vector3 offset = new Vector3(0, 2f, 0); // 캐릭터 머리 위로 띄우기

    private Transform target; // 따라다닐 대상

    public void Setup(Transform target)
    {
        this.target = target;
        transform.position = target.position + offset;
    }

    public void Show(string message)
    {
        textMesh.text = message;
        gameObject.SetActive(true);
        CancelInvoke(nameof(Hide));
        Invoke(nameof(Hide), showTime);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
