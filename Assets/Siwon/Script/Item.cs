using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    List<float> Gun = new List<float>();
    List<float> Skill = new List<float>();
    //enum ItemType
    //{
    //    Gun,
    //    Skill
    //}
    //public enum GunType
    //{
    //    ����,
    //    ������,
    //    �������,
    //    ��ź��,
    //    ����,
    //    ���ڵ�����,
    //    �̴ϰ�,
    //    ����ī
    //}
    //public enum SkillType
    //{
    //    Shield,
    //    BreakWall,
    //    Nuclear,
    //    Airfire,
    //    Turret
    //}

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player" && Input.GetKeyDown(KeyCode.E))
        {

        }

    }
    //ChangePlayerStat �⺻�������ε� �Ű����� �߰� �Ҷ� �������� �߰� �ϼ� �ƴϸ� ū�ϳ�
    //RPS = RecoverPerSecond:�ʴ�ȸ��
    //CGS ChangeGunStat
    
}
