public class CatcherWorkState : CatcherState
{
    public override void Handle(Catcher catcher)
    {
        base.Handle(catcher);
        if (_catcher is Fisher) return;
        _catcher.Catch();
        _catcher.TryChangeState(CatcherStateType.CatcherConveyState);
    }
}