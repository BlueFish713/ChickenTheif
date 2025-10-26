using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkerUI : MonoBehaviour
{
    public WorkerType workerType;
    [SerializedDictionary]
    public SerializedDictionary<WorkerType, Sprite> workerSprites = new SerializedDictionary<WorkerType, Sprite>();
    public SerializedDictionary<WorkerType, string> workerTexts = new SerializedDictionary<WorkerType, string>();
    public UIAnimation WorkerPanel;

    public Image workerPanelImage;
    public TMP_Text workerPanelText;
    public TMP_Text workerCountText;

    void Awake()
    {
        UpdateText();
    }

    public void CashierButtonClick()
    {
        WorkerPanel.InstantDisappear();
        workerType = WorkerType.Cashier;
        WorkerPanel.Appear();
        workerPanelImage.sprite = workerSprites[workerType];
        workerPanelText.text = workerTexts[workerType];
        UpdateText();
    }

    public void ChefButtonClick()
    {
        WorkerPanel.InstantDisappear();
        workerType = WorkerType.Chef;
        WorkerPanel.Appear();
        workerPanelImage.sprite = workerSprites[workerType];
        workerPanelText.text = workerTexts[workerType];
        UpdateText();
    }

    public void FisherButtonClick()
    {
        WorkerPanel.InstantDisappear();
        workerType = WorkerType.Fisher;
        WorkerPanel.Appear();
        workerPanelImage.sprite = workerSprites[workerType];
        workerPanelText.text = workerTexts[workerType];
        UpdateText();
    }

    public void DiverButtonClick()
    {
        WorkerPanel.InstantDisappear();
        workerType = WorkerType.Diver;
        WorkerPanel.Appear();
        workerPanelImage.sprite = workerSprites[workerType];
        workerPanelText.text = workerTexts[workerType];
        UpdateText();
    }

    public void Create()
    {
        SingletonManager.Get<WorkerManager>().CreateWorker(workerType);
        UpdateText();
    }

    void UpdateText()
    {
        workerCountText.text = workerType switch
        {
            WorkerType.Cashier => $"고용하기({SingletonManager.Get<WorkerManager>().cashiers.Count}/3)",
            WorkerType.Chef => $"고용하기({SingletonManager.Get<WorkerManager>().chefs.Count}/3)",
            WorkerType.Fisher => $"고용하기({SingletonManager.Get<WorkerManager>().fishers.Count}/3)",
            WorkerType.Diver => $"고용하기({SingletonManager.Get<WorkerManager>().divers.Count}/3)",
            _ => workerCountText.text
        };
    }
}
