using UnityEngine;
using UnityEngine.UI;

public class ToggleUI : MonoBehaviour
{
    public Button myButton;      // 클릭할 버튼
    public GameObject targetUI;  // 나타낼 UI (Panel, Image 등)

    void Start()
    {
        // 버튼 클릭 시 ShowUI 함수 실행
        myButton.onClick.AddListener(ShowUI);
    }

    void ShowUI()
    {
        // 클릭할 때마다 켜졌다 꺼졌다 토글
        targetUI.SetActive(!targetUI.activeSelf);
    }
}