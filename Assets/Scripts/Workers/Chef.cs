using System.Collections.Generic;
using UnityEngine;

public class Chef : Worker
{
    //손질된 수산물 List
    public List<TrimmedData> trimmedDatas = new List<TrimmedData>();

    //어떤 Catcher가 이 Chef를 향해 가고 있음을 표시
    public bool targeted = false;

    //손질하고 있음
    public bool working = false;

    //손질하는데 걸리는 시간
    public float workTime;

    void Start()
    {
        
        EventManager.Subscribe(EventName.Upgrade, () =>
        {
            workTime -= 0.5f;
        });
    }

    //Catcher에 의해 호출됨(일단 어떤 Cathcer에 의해 타겟팅 됐는지 알기 위해 Catcher catcher 매개변수 추가함)
    public void Targeted(Catcher catcher)
    {
        targeted = true;
    }

    //Catcher에 의해 호출됨. 손질되지 않은 수산물을 받음
    public void RecieveUnTrimmedData(in List<UntrimmedData> untrimmedDatas)
    {
        targeted = false;
        var untrimmedDatasCopy = new List<UntrimmedData>();
        foreach (var ut in untrimmedDatas)
        {
            untrimmedDatasCopy.Add(ut);
        }
        StartCoroutine(Work(untrimmedDatasCopy));
    }

    //손질하기
    System.Collections.IEnumerator Work(List<UntrimmedData> untrimmedDatas)
    {
        working = true;
        GetComponent<Animator>().SetTrigger("A");
        yield return new WaitForSeconds(workTime);
        working = false;
        //trimmedDatas.Clear();
        foreach (var t in untrimmedDatas)
        {
            trimmedDatas.Add(Trim(t));
        }
        EventManager.Publish(EventName.CallCashier);
    }
    
    //손질되지 않은 수산물을 손질된 수산물로 바꿈
    TrimmedData Trim(UntrimmedData untrimmedData)
    {
        TrimmedData data = new TrimmedData();
        data.fish = untrimmedData.fish;
        data.rate = untrimmedData.rate;
        return data;
    }
}
