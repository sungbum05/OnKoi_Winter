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
            switch (stat.statOperator)
            {
                case StatOperator.Plus:
                    switch (stat.statsType)
                    {
                        case StatsType.Player:

                            break;
                    }
                    switch (stat.statType)
                    {
                        case StatType.Hp:
                            unit.Hp += 50;
                            break;
                        case StatType.MoveSpeed:
                            unit.MoveSpeed += 7;
                            break;
                        case StatType.Shield:
                            unit.Shield += 10;
                            break;
                        
                    }
                    break;
                case StatOperator.Minus:
                    switch (stat.statType)
                    {
                        case StatType.Hp:
                            unit.Hp -= 10;
                            break;
                        case StatType.MoveSpeed:
                            unit.MoveSpeed -= 4;
                            break;
                        case StatType.Shield:
                            unit.Shield -= 10;
                            break;
                    }
                    break;
                case StatOperator.Multi:
                    switch (stat.statType)
                    {
                        case StatType.Hp:
                            unit.Hp *= 1.2f;
                            break;
                        case StatType.MoveSpeed:
                            unit.MoveSpeed *= 1.5f;
                            break;
                        case StatType.Shield:
                            unit.Shield *= 1.2f;
                            break;
                    }
                    break;
            }
        }
    }
    public List<StatInfo> RandomStat(int Count)//Count
    {
        List<StatInfo> temp = new List<StatInfo>();
        for (int i = 0; i < Count; i++)
        {
            //������ �߰� �ϴµ� ����Ʈ �ε����� �������� �ؼ� �������� �̴´�
            temp.Add(allStatInfos[Random.Range(0, allStatInfos.Count)]);
        }
        return temp;
    }
}
