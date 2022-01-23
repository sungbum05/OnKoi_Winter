using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance { get; private set; } = null;
    void Awake()
    {
        Instance = this;
    }
    public List<StatInfo> allStatInfos = new List<StatInfo>();
    public void ApplyStat(StatInfo statInfo)
    {
        //성범아 적용 ㄱ
    }
    public List<StatInfo> RandomStat(int Count)
    {
        List<StatInfo> temp = new List<StatInfo>();
        for (int i = 0; i < Count; i++)
        {
            temp.Add(allStatInfos[Random.Range(0, allStatInfos.Count)]);

        }
        return temp;
    }
}
