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
    List<StatInfoView> statInfoViews = new List<StatInfoView>();
    public void ShowChoiceUI()
    {
        var stats = StatManager.Instance.RandomStat(statInfoViews.Count);//리스트 카운트 하는건데
        for (int i = 0; i < statInfoViews.Count; i++)
        {
            statInfoViews[i].SetStatinfo(stats[i]);//i가 들어가는 이유는 statInfoViews가 리스트리기 때문,stats도 리스트다 그래서 인덱스 값을 넣을 수 있다
        }
    }
}
