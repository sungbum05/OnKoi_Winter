using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance { get; private set; } = null;//������ �����
    void Awake()
    {
        Instance = this;//Instance�� �ڱ� �ڽ� ����
    }
    public List<StatInfo> allStatInfos = new List<StatInfo>(); //List�� StatInfo�� ������
    //�����߰�
    public void ApplyStat(StatInfo statInfo)
    {
        statInfo.
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
