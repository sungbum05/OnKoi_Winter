using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    [SerializeField]
    private PlayerContorller unit;

    private SetGun setGun;

    public static StatManager Instance { get; private set; } = null;//스탯을 비워줌
    void Awake()
    {
        Instance = this;//Instance에 자기 자신 대입
    }
    public List<StatInfo> allStatInfos = new List<StatInfo>(); //List에 StatInfo를 저장함
    //스탯추가
    public void ApplyStat(StatInfo statInfo)
    {
        foreach (var stat in statInfo.statValues)
        {
            switch (stat.statsType)
            {
                case StatsType.Player:
                    switch (stat.statOperator)
                    {
                        case StatOperator.Plus:
                            switch (stat.statType)
                            {
                                case PlayerStatType.Hp://Player Hp, Shield제외하고 모두 %으로 증가
                                    unit.Hp += stat.value;
                                    break;
                                case PlayerStatType.MoveSpeed:
                                    unit.MoveSpeed += unit.MoveSpeed * stat.value / 100;
                                    break;
                                case PlayerStatType.Shield:
                                    unit.MaxShield += stat.value;
                                    break;
                            }
                            break;
                        //마이너스 ,멀티 안씀
                        case StatOperator.Minus:
                            switch (stat.statType)
                            {
                                case PlayerStatType.Hp:
                                    unit.Hp -= 10;
                                    break;
                                case PlayerStatType.MoveSpeed:
                                    unit.MoveSpeed -= 4;
                                    break;
                                case PlayerStatType.Shield:
                                    unit.MaxShield -= 10;
                                    break;
                            }
                            break;
                        case StatOperator.Multi:
                            switch (stat.statType)
                            {
                                case PlayerStatType.Hp:
                                    unit.Hp *= 1.2f;
                                    break;
                                case PlayerStatType.MoveSpeed:
                                    unit.MoveSpeed *= 1.5f;
                                    break;
                                case PlayerStatType.Shield:
                                    unit.MaxShield *= 1.2f;
                                    break;
                            }
                            break;
                    }
                    break;
                case StatsType.Gun:
                    switch (stat.statOperator)
                    {
                        case StatOperator.Plus:
                            switch (stat.gunType)
                            {
                                case GunType.Chargerifle:
                                    switch (stat.gunStatType)
                                    {
                                        case GunStatType.Damage:
                                            setGun.Damege += setGun.Damege * stat.value / 100;//공격력 50프로 증가
                                            break;
                                        case GunStatType.Ammo:
                                            setGun.Ammo += setGun.Ammo * (int)stat.value / 100;
                                            break;
                                        case GunStatType.BulletSpeed:
                                            setGun.BulletSpeed += setGun.BulletSpeed * stat.value / 100;
                                            break;
                                        case GunStatType.BulletSpread:
                                            setGun.BulletSpread += setGun.BulletSpread * stat.value;
                                            break;
                                        case GunStatType.RateFire:
                                            setGun.RateFire += setGun.RateFire / 10;
                                            break;
                                        case GunStatType.HeatCapacity:
                                            setGun.HeatCapacity += setGun.HeatCapacity / 5;
                                            break;
                                    }
                                    break;
                                case GunType.Machinedagger:
                                    switch (stat.gunStatType)
                                    {//기관단총
                                        case GunStatType.Damage:
                                            setGun.Damege += setGun.Damege / 2;//공격력 50프로 증가
                                            break;
                                        case GunStatType.Ammo:
                                            setGun.Ammo += setGun.Ammo / 5;
                                            break;
                                        case GunStatType.BulletSpeed:
                                            setGun.BulletSpeed += setGun.BulletSpeed / 5;
                                            break;
                                        case GunStatType.BulletSpread:
                                            setGun.BulletSpread += setGun.BulletSpread / 5;
                                            break;
                                        case GunStatType.RateFire:
                                            setGun.RateFire += setGun.RateFire / 10;
                                            break;
                                        case GunStatType.HeatCapacity:
                                            setGun.HeatCapacity += setGun.HeatCapacity / 5;
                                            break;
                                    }
                                    break;
                                case GunType.Shotgun:
                                    switch (stat.gunStatType)
                                    {
                                        case GunStatType.Damage:
                                            setGun.Damege += setGun.Damege / 2;//공격력 50프로 증가
                                            break;
                                        case GunStatType.Ammo:
                                            setGun.Ammo += setGun.Ammo / 5;
                                            break;
                                        case GunStatType.BulletSpeed:
                                            setGun.BulletSpeed += setGun.BulletSpeed / 5;
                                            break;
                                        case GunStatType.BulletSpread:
                                            setGun.BulletSpread += setGun.BulletSpread / 5;
                                            break;
                                        case GunStatType.RateFire:
                                            setGun.RateFire += setGun.RateFire / 10;
                                            break;
                                        case GunStatType.HeatCapacity:
                                            setGun.HeatCapacity += setGun.HeatCapacity / 5;
                                            break;
                                    }
                                    break;
                                case GunType.Pistol:
                                    switch (stat.gunStatType)
                                    {
                                        case GunStatType.Damage:
                                            setGun.Damege += setGun.Damege * stat.value / 100;//공격력 50프로 증가
                                            break;
                                        case GunStatType.Ammo:
                                            setGun.Ammo += setGun.Ammo / 5;//탄창 20%증가
                                            break;
                                        case GunStatType.BulletSpeed:
                                            setGun.BulletSpeed += setGun.BulletSpeed / 5; //투사체 속도 20%증가
                                            break;
                                        case GunStatType.BulletSpread:
                                            setGun.BulletSpread += setGun.BulletSpread / 5;//탄퍼짐 20증가
                                            break;
                                        case GunStatType.RateFire:
                                            setGun.RateFire += setGun.RateFire / 10;//발사 속도 10% 증가
                                            break;
                                        case GunStatType.HeatCapacity:
                                            setGun.HeatCapacity += setGun.HeatCapacity / 5; //열용량 20% 증가
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case StatOperator.Minus:
                            switch (stat.gunType)
                            {
                                case GunType.Chargerifle:
                                    switch (stat.gunStatType)
                                    {
                                        case GunStatType.Damage:
                                            setGun.Damege -= setGun.Damege * stat.value / 100;//공격력 50프로 증가
                                            break;
                                        case GunStatType.Ammo:
                                            setGun.Ammo -= setGun.Ammo * (int)stat.value / 100;
                                            break;
                                        case GunStatType.BulletSpeed:
                                            setGun.BulletSpeed -= setGun.BulletSpeed * stat.value / 100;
                                            break;
                                        case GunStatType.BulletSpread:
                                            setGun.BulletSpread -= setGun.BulletSpread * stat.value;
                                            break;
                                        case GunStatType.RateFire:
                                            setGun.RateFire -= setGun.RateFire / 10;
                                            break;
                                        case GunStatType.HeatCapacity:
                                            setGun.HeatCapacity -= setGun.HeatCapacity / 5;
                                            break;
                                    }
                                    break;
                                case GunType.Machinedagger:
                                    switch (stat.gunStatType)
                                    {//기관단총
                                        case GunStatType.Damage:
                                            setGun.Damege -= setGun.Damege / 2;//공격력 50프로 증가
                                            break;
                                        case GunStatType.Ammo:
                                            setGun.Ammo -= setGun.Ammo / 5;
                                            break;
                                        case GunStatType.BulletSpeed:
                                            setGun.BulletSpeed -= setGun.BulletSpeed / 5;
                                            break;
                                        case GunStatType.BulletSpread:
                                            setGun.BulletSpread -= setGun.BulletSpread / 5;
                                            break;
                                        case GunStatType.RateFire:
                                            setGun.RateFire -= setGun.RateFire / 10;
                                            break;
                                        case GunStatType.HeatCapacity:
                                            setGun.HeatCapacity -= setGun.HeatCapacity / 5;
                                            break;
                                    }
                                    break;
                                case GunType.Shotgun:
                                    switch (stat.gunStatType)
                                    {
                                        case GunStatType.Damage:
                                            setGun.Damege -= setGun.Damege / 2;//공격력 50프로 증가
                                            break;
                                        case GunStatType.Ammo:
                                            setGun.Ammo -= setGun.Ammo / 5;
                                            break;
                                        case GunStatType.BulletSpeed:
                                            setGun.BulletSpeed -= setGun.BulletSpeed / 5;
                                            break;
                                        case GunStatType.BulletSpread:
                                            setGun.BulletSpread -= setGun.BulletSpread / 5;
                                            break;
                                        case GunStatType.RateFire:
                                            setGun.RateFire -= setGun.RateFire / 10;
                                            break;
                                        case GunStatType.HeatCapacity:
                                            setGun.HeatCapacity -= setGun.HeatCapacity / 5;
                                            break;
                                    }
                                    break;
                                case GunType.Pistol:
                                    switch (stat.gunStatType)
                                    {
                                        case GunStatType.Damage:
                                            setGun.Damege -= setGun.Damege * stat.value / 100;//공격력 50프로 증가
                                            break;
                                        case GunStatType.Ammo:
                                            setGun.Ammo -= setGun.Ammo / 5;//탄창 20%증가
                                            break;
                                        case GunStatType.BulletSpeed:
                                            setGun.BulletSpeed -= setGun.BulletSpeed / 5; //투사체 속도 20%증가
                                            break;
                                        case GunStatType.BulletSpread:
                                            setGun.BulletSpread -= setGun.BulletSpread / 5;//탄퍼짐 20감소
                                            break;
                                        case GunStatType.RateFire:
                                            setGun.RateFire -= setGun.RateFire / 10;//발사 속도 10% 증가
                                            break;
                                        case GunStatType.HeatCapacity:
                                            setGun.HeatCapacity -= setGun.HeatCapacity / 5; //열용량 20% 증가
                                            break;
                                    }
                                    break;





                            }
                            break;

                    }
                    break;

            }
        }
    }
    public List<StatInfo> RandomStat(int Count)//Count
    {
        List<StatInfo> temp = new List<StatInfo>();
        for (int i = 0; i < Count; i++)
        {
            //스탯을 추가 하는데 리스트 인덱스를 랜덤으로 해서 랜덤으로 뽑는다
            temp.Add(allStatInfos[Random.Range(0, allStatInfos.Count)]);
        }
        return temp;
    }


}





