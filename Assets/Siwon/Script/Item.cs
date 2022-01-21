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
        권총,
        리볼버,
        기관단총,
        산탄총,
        소총,
        반자동소총,
        미니건,
        바주카
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
    //ChangePlayerStat 기본값인자인데 매개변수 추가 할때 마지막에 추가 하셈 아니면 큰일남
    //RPS = RecoverPerSecond:초당회복
    //CGS ChangeGunStat
    public virtual void CPS(float MoveSpeed = 5, float RPS = 0, int shield = 100, int MAXhealth = 100,bool Vampirism = false)
    {
        
    }
    public virtual void CGS(float ShootSpeed = 5, float Damage = 10, float Heat = 1, int AMMO = 21000000, float BulletSpeed = 5)
    {

    }
}
