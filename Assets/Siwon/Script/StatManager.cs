using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    Unit unit;

    public static StatManager Instance { get; private set; } = null;//������ �����
    void Awake()
    {
        Instance = this;//Instance�� �ڱ� �ڽ� ����
    }
    public List<StatInfo> allStatInfos = new List<StatInfo>(); //List�� StatInfo�� ������
    //�����߰�
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
            temp.Add(allStatInfos[Random.Range(0, allStatInfos.Count)]);//������ �߰� �ϴµ� ����Ʈ �ε����� �������� �ؼ� �������� �̴´�
        }
        return temp;
    }
}
