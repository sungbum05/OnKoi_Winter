using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatInfoView : MonoBehaviour
{
    StatInfo statInfo;
    public Text Stat;
    public Button button;
    void Start()
    {
        button.onClick.AddListener(() => { });
    }
    public void SetStatinfo(StatInfo statInfo)
    {
        this.statInfo = statInfo;
        Stat.text = this.statInfo.ToString();

    }

}
