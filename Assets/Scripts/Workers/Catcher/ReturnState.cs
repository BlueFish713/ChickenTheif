using System.Collections;
using UnityEngine;
using DG.Tweening;

public class CatcherReturnState : CatcherState
{
    public override void Handle(Catcher catcher)
    {
        base.Handle(catcher);
        Debug.Log("CatcherReturnState handel");
        _catcher.StartCoroutine(MoveToSlot());
    }


    bool Wait()
    {
        if (_catcher is Diver) return true;
        else
        {
            return !WM.boat.onOcean;
        }
    }

    IEnumerator MoveToSlot()
    {
        Debug.Log("CatcherReturnState MoveToSlot");
        yield return new WaitUntil(Wait);
        Debug.Log("CatcherReturnState WaitUntil Out");
        Tween t = _catcher.transform.DOMoveX(_catcher._slot.transform.position.x, _catcher.conveySpeed).SetEase(_catcher.moveEase).SetAutoKill();
        t.OnComplete(OnReturnedToSlot);
    }

    public override void Update()
    {
        base.Update();
            _catcher.GetComponent<Animator>().Play("Walk");
        //대충 건내주기
        //_catcher.TryChangeState(CatcherStateType.CatcherReturnState);
    }

    void OnReturnedToSlot()
    {
        _catcher.TryChangeState(CatcherStateType.CatcherWorkState);
        if (_catcher is Fisher fisher)
            WM.boat.Load(fisher);
    }
}