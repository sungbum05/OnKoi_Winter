using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    Unit unit;

    public static StatManager Instance { get; private set; } = null;//스탯을 비워줌
    void Awake()
    {
        Instance = this;//Instance에 자기 자신 대입
    }
    public List<StatInfo> allStatInfos = new List<StatInfo>(); //List에 StatInfo를 저장함
    //스탯추가
    public void ApplyStat(StatInfo statInfo)
    {
        foreach (var stat in statInfo.statValues)
        {
            switch (stat.statType)
            {
                case StatType.MoveSpeed:
                    unit.MoveSpeed += 7;
                    break;
                case StatType.Shield:
                    unit.Shield += 10;
                    break;
                
            }


        }
    }
    public List<StatInfo> RandomStat(int Count)//Count
    {
        List<StatInfo> temp = new List<StatInfo>();
        for (int i = 0; i < Count; i++)
        {
            temp.Add(allStatInfos[Random.Range(0, allStatInfos.Count)]);//스탯을 추가 하는데 리스트 인덱스를 랜덤으로 해서 랜덤으로 뽑는다
        }
        return temp;
    }
}
