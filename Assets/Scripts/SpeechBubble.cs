using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class SpeechBubble : MonoBehaviour
{
    public TMP_Text textMesh;
    public SpriteRenderer bubbleRenderer;
    public float showTime = 2f; // 말풍선 유지 시간
    public Vector3 offset = new Vector3(0, 2.5f, 0); // 캐릭터 머리 위로 띄우기
    private Transform target; // 따라다닐 대상
    public List<Sprite> bubble;
    List<float> metric = new List<float> {1.3f,3f,5f,7f,9f,11f,12.5f,99f};

    public void Setup(Transform target)
    {
        this.target = target;
        transform.position = target.position + offset;
        gameObject.SetActive(false);
    }

    public void Show(string message)
    {
        textMesh.text = message;
        textMesh.ForceMeshUpdate();

        for (int i = 0; i < 8; i++)
        {
            float width = textMesh.preferredWidth;
            if (width < metric[i])
            {
                bubbleRenderer.sprite = bubble[i];
                break;
            }
        }

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
