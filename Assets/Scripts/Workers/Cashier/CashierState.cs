public abstract class CashierState
{
    protected Cashier _cashier;
    protected WorkerManager WM;
    public virtual void Handle(Cashier cashier)
    {
        WM = SingletonManager.Get<WorkerManager>();
        _cashier = cashier;
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