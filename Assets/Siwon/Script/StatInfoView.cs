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
        this.statInfo = statInfo;//statinfo에 statinfo대입
        Stat.text = this.statInfo.ToString();//그것을 문자열로 변환해서 택스트로 보여줌
        //결과는 스탯과 스탯tostring이 같기 떄문에 스탯이 바뀌면 글자도 바뀜

    }

}
