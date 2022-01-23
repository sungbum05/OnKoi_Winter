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
    List<string> ButtonSet = new List<string>(15) {"임성범", "공격력" };
    
    
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
        ButtonSet.Add("임성범");
        ButtonSet.Add("공격력 +50%");
        ButtonSet.Add("최대체력 +50");
        ButtonSet.Add("플레이어 이동속도+10%");
        Stats.Add(123.0f);
    }
    


}
