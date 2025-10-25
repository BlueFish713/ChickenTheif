using System.Collections;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class CatcherConveyState : CatcherState
{
    Chef chef;
    public override void Handle(Catcher catcher)
    {
        base.Handle(catcher);
        _catcher.StartCoroutine(MoveToChef());
    }

    IEnumerator MoveToChef()
    {
        yield return new WaitUntil(() =>
        {
            chef = WM.GetAvailableChef();
            return chef != null;
        });
        Tween t = _catcher.transform.DOMoveX(chef.transform.position.x, _catcher.conveySpeed);
        t.OnComplete(OnReachedChef);
    }

    public override void Update()
    {
        base.Update();
    }

    void OnReachedChef()
    {
        _catcher.TryChangeState(CatcherStateType.CatcherReturnState);
    }
}