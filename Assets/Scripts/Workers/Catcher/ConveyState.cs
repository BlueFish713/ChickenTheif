using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class CatcherConveyState : CatcherState
{
    Chef chef;

    public override void Handle(Catcher catcher)
    {
        base.Handle(catcher);
        _catcher.StartCoroutine(HandleCoroutine());
    }
    
    IEnumerator HandleCoroutine()
    {
        if (_catcher.hasFirstData)
        {
            EventManager.Publish(EventName.FirstRateCallCashier);
            yield return new WaitUntil(() =>
                !_catcher.hasFirstData);
            _catcher.GetComponent<Animator>().Play("Wait");
            _catcher.StartCoroutine(MoveToChef());
        }
        else
        {
            _catcher.StartCoroutine(MoveToChef());
        }
    }

    IEnumerator MoveToChef()
    {
        //동시 타겟팅을 방지하기 위해 약간의 시간 지연
        yield return new WaitForSeconds(Random.Range(-0.2f, 0.2f));
        yield return new WaitUntil(() =>
        {
            chef = WM.GetAvailableChef();
            _catcher.GetComponent<Animator>().Play("Wait");
            return chef != null;
        });
        if (!chef.targeted)
        {
            chef.Targeted(_catcher);
            _catcher.GetComponent<Animator>().Play("Walk");
            Tween t = _catcher.transform.DOMoveX(chef.transform.position.x, MoveBase.GetDuration(_catcher.transform.position, chef.transform.position, _catcher.conveySpeed)).SetEase(_catcher.moveEase).SetAutoKill();
            _catcher.GetComponent<SpriteRenderer>().flipX = MoveBase.GetFlipX(_catcher.transform.position, chef.transform.position);
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
        chef.RecieveUnTrimmedData(in _catcher.untrimmedDatas);
        _catcher.fishLayout.UnLoadAll();
        _catcher.untrimmedDatas.Clear();
        _catcher.TryChangeState(CatcherStateType.CatcherReturnState);
        chef = null;
    }
}