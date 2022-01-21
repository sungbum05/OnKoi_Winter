using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
   
    enum ItemType
    {
        Gun,
        Skill
    }
    public enum GunType
    {
        ����,
        ������,
        �������,
        ��ź��,
        ����,
        ���ڵ�����,
        �̴ϰ�,
        ����ī
    }
    public enum SkillType
    {
        Shield,
        BreakWall,
        Nuclear,
        Airfire,
        Turret
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player" && Input.GetKeyDown(KeyCode.E))
        {

        }

    }
    //ChangePlayerStat �⺻�������ε� �Ű����� �߰� �Ҷ� �������� �߰� �ϼ� �ƴϸ� ū�ϳ�
    //RPS = RecoverPerSecond:�ʴ�ȸ��
    //CGS ChangeGunStat
    public virtual void CPS(float MoveSpeed = 5, float RPS = 0, int shield = 100, int MAXhealth = 100,bool Vampirism = false)
    {
        
    }
    public virtual void CGS(float ShootSpeed = 5, float Damage = 10, float Heat = 1, int AMMO = 21000000, float BulletSpeed = 5)
    {

    }
}
