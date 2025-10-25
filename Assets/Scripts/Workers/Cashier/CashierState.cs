public abstract class CashierState
{
    Cashier _cashier;
    public virtual void Handle(Cashier cashier)
    {
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