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
        //동시 타겟팅을 방지하기 위해 약간의 시간 지연
        yield return new WaitForSeconds(Random.Range(-0.2f, 0.2f));
        yield return new WaitUntil(() =>
        {
            chef = WM.GetAvailableChef();
            return chef != null;
        });
        if (!chef.targeted)
        {
            chef.Targeted(_catcher);
            Tween t = _catcher.transform.DOMoveX(chef.transform.position.x, _catcher.conveySpeed);
            t.OnComplete(OnReachedChef);
        }
        else
        {
            _catcher.StartCoroutine(MoveToChef());
        }
    }

    public override void Update()
    {
        base.Update();
    }

    void OnReachedChef()
    {
        chef.RecieveUnTrimmedData(_catcher.untrimmedDatas);
        _catcher.fishLayout.UnLoadAll();
        _catcher.untrimmedDatas.Clear();
        _catcher.TryChangeState(CatcherStateType.CatcherReturnState);
        chef = null;
    }
}