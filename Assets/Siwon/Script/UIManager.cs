using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance { get; private set; } = null;
    void Awake()
    {
        Instance = this;
    }
    public List<StatInfoView> statInfoViews = new List<StatInfoView>();
   
    public void ShowChoiceUI()
    {
        var stats = StatManager.Instance.RandomStat(statInfoViews.Count);
        for (int i = 0; i < statInfoViews.Count; i++)
        {
            statInfoViews[i].SetStatinfo(stats[i]);//i�� ���� ������ statInfoViews�� ����Ʈ���� ����,stats�� ����Ʈ�� �׷��� �ε��� ���� ���� �� �ִ�
        }
    }
}
