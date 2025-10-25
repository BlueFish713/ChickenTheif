public abstract class CatcherState
{
    protected Catcher _catcher;
    protected WorkerManager WM;
    public virtual void Handle(Catcher catcher)
    {
        WM = SingletonManager.Get<WorkerManager>();
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