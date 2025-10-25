using System.Collections.Generic;
using UnityEngine;

public class Chef : Worker
{
    //손질된 수산물 List
    [SerializeField] private List<TrimmedData> trimmedDatas;

    //어떤 Catcher가 이 Chef를 향해 가고 있음을 표시
    public bool targeted = false;

    //손질하고 있음
    public bool working = false;

    //손질하는데 걸리는 시간
    public float workTime;

    //Catcher에 의해 호출됨(일단 어떤 Cathcer에 의해 타겟팅 됐는지 알기 위해 Catcher catcher 매개변수 추가함)
    public void Targeted(Catcher catcher)
    {
        targeted = true;
    }

    //Catcher에 의해 호출됨. 손질되지 않은 수산물을 받음
    public void RecieveUnTrimmedData(List<UntrimmedData> untrimmedDatas)
    {
        targeted = false;
        StartCoroutine(Work(untrimmedDatas));
    }

    //손질하기
    System.Collections.IEnumerator Work(List<UntrimmedData> untrimmedDatas)
    {
        working = true;
        yield return new WaitForSeconds(workTime);
        working = false;
        trimmedDatas = new List<TrimmedData>();
        foreach (var t in untrimmedDatas)
        {
            trimmedDatas.Add(Trim(t));
        }
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
