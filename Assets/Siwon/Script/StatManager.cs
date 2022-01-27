using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    Unit unit;
    SetGun setGun;

    public static StatManager Instance { get; private set; } = null;//������ �����
    void Awake()
    {
        Instance = this;//Instance�� �ڱ� �ڽ� ����
    }
    public List<StatInfo> allStatInfos = new List<StatInfo>(); //List�� StatInfo�� ������
    //�����߰�
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
                                case StatType.Hp:
                                    unit.Hp += 50;
                                    break;
                                case StatType.MoveSpeed:
                                    unit.MoveSpeed += 7;
                                    break;
                                case StatType.Shield:
                                    unit.Shield += 10;
                                    break;
                            }
                            break;
                            
                        case StatOperator.Minus:
                            switch (stat.statType)
                            {
                                case StatType.Hp:
                                    unit.Hp -= 10;
                                    break;
                                case StatType.MoveSpeed:
                                    unit.MoveSpeed -= 4;
                                    break;
                                case StatType.Shield:
                                    unit.Shield -= 10;
                                    break;
                            }
                            break;
                        case StatOperator.Multi:
                            switch (stat.statType)
                            {
                                case StatType.Hp:
                                    unit.Hp *= 1.2f;
                                    break;
                                case StatType.MoveSpeed:
                                    unit.MoveSpeed *= 1.5f;
                                    break;
                                case StatType.Shield:
                                    unit.Shield *= 1.2f;
                                    break;
                            }
                            break;
                    }
                    break;
                case StatsType.Gun:
                    switch (stat.gunType)
                    {
                        case GunType.Chargerifle:
                            switch (stat.gunStatType)
                            {
                                case GunStatType.Damage:
                                    setGun.Damege += setGun.Damege / 2;//���ݷ� 50���� ����
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
                        case GunType.Machinedagger:
                            switch (stat.gunStatType)
                            {
                                case GunStatType.Damage:
                                    setGun.Damege += setGun.Damege / 2;//���ݷ� 50���� ����
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
                                    setGun.Damege += setGun.Damege / 2;//���ݷ� 50���� ����
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
                                    setGun.Damege += setGun.Damege / 2;//���ݷ� 50���� ����
                                    break;
                                case GunStatType.Ammo:
                                    setGun.Ammo += setGun.Ammo / 5;//źâ 20%����
                                    break;
                                case GunStatType.BulletSpeed:
                                    setGun.BulletSpeed += setGun.BulletSpeed / 5; //����ü �ӵ� 20%����
                                    break;
                                case GunStatType.BulletSpread:
                                    setGun.BulletSpread -= setGun.BulletSpread / 5;//ź���� 20����
                                    break;
                                case GunStatType.RateFire:
                                    setGun.RateFire += setGun.RateFire / 10;//�߻� �ӵ� 10% ����
                                    break;
                                case GunStatType.HeatCapacity:
                                    setGun.HeatCapacity += setGun.HeatCapacity / 5; //���뷮 20% ����
                                    break;
                            }
                            break;
                    }
                    break;
            }
            break;
        }
    }
    public List<StatInfo> RandomStat(int Count)//Count
    {
        List<StatInfo> temp = new List<StatInfo>();
        for (int i = 0; i < Count; i++)
        {
            //������ �߰� �ϴµ� ����Ʈ �ε����� �������� �ؼ� �������� �̴´�
            temp.Add(allStatInfos[Random.Range(0, allStatInfos.Count)]);
        }
        return temp;
    }
    
}


