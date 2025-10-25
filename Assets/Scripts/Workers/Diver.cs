using UnityEngine;

public class Diver : Catcher
{
    
    public override void Assign(Slot slot)
    {
        base.Assign(slot);
        TryChangeState(CatcherStateType.CatcherReturnState);
    }
}
