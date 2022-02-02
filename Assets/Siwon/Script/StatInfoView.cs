using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatInfoView : MonoBehaviour
{
 
    StatInfo statInfo;
    public Text Stat;
    public Button button;
    public PlayerContorller Player;

    void Start()
    {
        button.onClick.AddListener(
            () => 
            { 
                StatManager.Instance.ApplyStat(statInfo);
                Player.SetLevelState();
                this.gameObject.transform.parent.gameObject.SetActive(false);

                Debug.Log("����");
            }
            );
        
    }
    public void SetStatinfo(StatInfo statInfo)
    {
        this.statInfo = statInfo;//statinfo�� statinfo����
        Stat.text = this.statInfo.ToString();//�װ��� ���ڿ��� ��ȯ�ؼ� �ý�Ʈ�� ������
        //����� ���Ȱ� ����tostring�� ���� ������ ������ �ٲ�� ���ڵ� �ٲ�


    }

}
