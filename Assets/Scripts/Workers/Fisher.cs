using UnityEngine;

public class Fisher : Catcher
{
    //time동안 물고기 잡기
    public void CatchWhileTime(float time)
    {
        for (int i = 0; i < (int)time/catchPeriod; i++)
        {
            Catch();
        }
    }
}
