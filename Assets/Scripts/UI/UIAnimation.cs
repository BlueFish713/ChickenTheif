using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;
using System;

public class UIAnimation : MonoBehaviour
{
    [BoxGroup("Values")]
    [SerializeField] Vector3 appearVal = new Vector3(1, 1, 0);
    [BoxGroup("Values")]
    [SerializeField] Vector3 disappearVal = new Vector3(0, 0, 0);

    [BoxGroup("Tweening")]
    [SerializeField] float duration;
    [BoxGroup("Tweening")]
    [SerializeField] Ease appearEase;
    [BoxGroup("Tweening")]
    [SerializeField] Ease disappearEase;

    public Action onFinishedAppear = () => { };
    public Action onFinishedDisappear = () => { };

    [Button("Appear")]
    public void Appear()
    {
        float dur = duration;

        if (gameObject.TryGetComponent<Transform>(out Transform _transform))
            _transform.DOScale(appearVal, dur).SetEase(appearEase).SetAutoKill().SetUpdate(UpdateType.Normal, true);

        else if (gameObject.TryGetComponent<RectTransform>(out RectTransform _rectTransform))
            _rectTransform.DOScale(appearVal, dur).SetEase(appearEase).SetAutoKill().SetUpdate(UpdateType.Normal, true);

        onFinishedAppear.Invoke();
    }

    [Button("Disappear")]
    public void Disappear()
    {
        float dur = duration;

        if (gameObject.TryGetComponent<Transform>(out Transform _transform))
            _transform.DOScale(disappearVal, dur).SetEase(disappearEase).SetAutoKill().SetUpdate(UpdateType.Normal, true);

        else if (gameObject.TryGetComponent<RectTransform>(out RectTransform _rectTransform))
            _rectTransform.DOScale(disappearVal, dur).SetEase(disappearEase).SetAutoKill().SetUpdate(UpdateType.Normal, true);
            
        onFinishedDisappear.Invoke();
    }

    public void InstantDisappear()
    {
        float dur = 0;
        if (gameObject.TryGetComponent<Transform>(out Transform _transform))
            _transform.DOScale(disappearVal, dur).SetEase(disappearEase).SetAutoKill().SetUpdate(UpdateType.Normal, true);

        else if (gameObject.TryGetComponent<RectTransform>(out RectTransform _rectTransform))
            _rectTransform.DOScale(disappearVal, dur).SetEase(disappearEase).SetAutoKill().SetUpdate(UpdateType.Normal, true);
            
        onFinishedDisappear.Invoke();
    }
}
