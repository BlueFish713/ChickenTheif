public abstract class CatcherState
{
    Catcher _catcher;
    public virtual void Handle(Catcher catcher)
    {
        _catcher = catcher;
    }

    public virtual void Update()
    {

    }

    public virtual void FixedUpdate()
    {

    }
    
    public virtual void Exit()
    {
        
    }
}