using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Linq;

public class LevelUp : MonoBehaviour
{
    public GameObject Player;
    public Canvas StatCh;
    Text MAXHP;
    List<float> Stats = new List<float>(15);
    List<string> ButtonSet = new List<string>(15) {"�Ӽ���", "���ݷ�" };
    
    
    void Start()
    {
        Setbutton();
        
    }
    void Update()
    {
        Debug.Log(ButtonSet[0]);
    }
    struct PStat
    {
        float Damage;
        float MoveSpeed;
        int Hp;


    }
    int RandomStat = Random.Range(0, 15);
    public void StatChang()
    {
        StatCh.transform.Translate(new Vector3(0f,-1f,0f));
    }
    void Setbutton()
    {
        ButtonSet.Add("�Ӽ���");
        ButtonSet.Add("���ݷ� +50%");
        ButtonSet.Add("�ִ�ü�� +50");
        ButtonSet.Add("�÷��̾� �̵��ӵ�+10%");
        Stats.Add(123.0f);
    }
    


}
