using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    [SerializeField]
    private PlayerContorller unit;

    private SetGun setGun;

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
                                case PlayerStatType.Hp://Player Hp, Shield�����ϰ� ��� %���� ����
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
                        //���̳ʽ� ,��Ƽ �Ⱦ�
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
                                            setGun.Damege += setGun.Damege * stat.value / 100;//���ݷ� 50���� ����
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
                                    {//�������
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
                                            setGun.Damege += setGun.Damege * stat.value / 100;//���ݷ� 50���� ����
                                            break;
                                        case GunStatType.Ammo:
                                            setGun.Ammo += setGun.Ammo / 5;//źâ 20%����
                                            break;
                                        case GunStatType.BulletSpeed:
                                            setGun.BulletSpeed += setGun.BulletSpeed / 5; //����ü �ӵ� 20%����
                                            break;
                                        case GunStatType.BulletSpread:
                                            setGun.BulletSpread += setGun.BulletSpread / 5;//ź���� 20����
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
                        case StatOperator.Minus:
                            switch (stat.gunType)
                            {
                                case GunType.Chargerifle:
                                    switch (stat.gunStatType)
                                    {
                                        case GunStatType.Damage:
                                            setGun.Damege -= setGun.Damege * stat.value / 100;//���ݷ� 50���� ����
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
                                    {//�������
                                        case GunStatType.Damage:
                                            setGun.Damege -= setGun.Damege / 2;//���ݷ� 50���� ����
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
                                            setGun.Damege -= setGun.Damege / 2;//���ݷ� 50���� ����
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
                                            setGun.Damege -= setGun.Damege * stat.value / 100;//���ݷ� 50���� ����
                                            break;
                                        case GunStatType.Ammo:
                                            setGun.Ammo -= setGun.Ammo / 5;//źâ 20%����
                                            break;
                                        case GunStatType.BulletSpeed:
                                            setGun.BulletSpeed -= setGun.BulletSpeed / 5; //����ü �ӵ� 20%����
                                            break;
                                        case GunStatType.BulletSpread:
                                            setGun.BulletSpread -= setGun.BulletSpread / 5;//ź���� 20����
                                            break;
                                        case GunStatType.RateFire:
                                            setGun.RateFire -= setGun.RateFire / 10;//�߻� �ӵ� 10% ����
                                            break;
                                        case GunStatType.HeatCapacity:
                                            setGun.HeatCapacity -= setGun.HeatCapacity / 5; //���뷮 20% ����
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
            //������ �߰� �ϴµ� ����Ʈ �ε����� �������� �ؼ� �������� �̴´�
            temp.Add(allStatInfos[Random.Range(0, allStatInfos.Count)]);
        }
        return temp;
    }


}





