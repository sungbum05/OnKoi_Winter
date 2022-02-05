using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    [SerializeField]
    private PlayerContorller unit;
    
    [SerializeField]
    private Pistol pistol;
    [SerializeField]
    private ShotGun shotGun;
    [SerializeField]
    private AssaultRifle assaultRifle;
    [SerializeField]
    private SubmachineGun submachineGun;
    

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
                    }
                    break;
                case StatsType.Gun:
                    switch (stat.statOperator)
                    {
                        case StatOperator.Plus:
                            switch (stat.gunType)
                            {
                                case GunType.AssualtRifle:
                                    switch (stat.gunStatType)
                                    {
                                        case GunStatType.Damage:
                                            assaultRifle.Damege += assaultRifle.Damege * stat.value / 100;//���ݷ� 50���� ����
                                            break;
                                        case GunStatType.Ammo:
                                            assaultRifle.Ammo += assaultRifle.Ammo * (int)stat.value / 100;
                                            break;
                                        case GunStatType.BulletSpeed:
                                            assaultRifle.BulletSpeed += assaultRifle.BulletSpeed * stat.value / 100;
                                            break;
                                        case GunStatType.BulletSpread:
                                            assaultRifle.BulletSpread += assaultRifle.BulletSpread * stat.value;
                                            break;
                                        case GunStatType.RateFire:
                                            assaultRifle.RateFire += assaultRifle.RateFire / 10;
                                            break;
                                        case GunStatType.HeatCapacity:
                                            assaultRifle.HeatCapacity += assaultRifle.HeatCapacity / 5;
                                            break;
                                    }
                                    break;
                                case GunType.Submachinegun:
                                    switch (stat.gunStatType)
                                    {//�������
                                        case GunStatType.Damage:
                                            submachineGun.Damege += submachineGun.Damege / 2;//���ݷ� 50���� ����
                                            break;
                                        case GunStatType.Ammo:
                                            submachineGun.Ammo += submachineGun.Ammo / 5;
                                            break;
                                        case GunStatType.BulletSpeed:
                                            submachineGun.BulletSpeed += submachineGun.BulletSpeed / 5;
                                            break;
                                        case GunStatType.BulletSpread:
                                            submachineGun.BulletSpread += submachineGun.BulletSpread / 5;
                                            break;
                                        case GunStatType.RateFire:
                                            submachineGun.RateFire += submachineGun.RateFire / 10;
                                            break;
                                        case GunStatType.HeatCapacity:
                                            submachineGun.HeatCapacity += submachineGun.HeatCapacity / 5;
                                            break;
                                    }
                                    break;
                                case GunType.Shotgun:
                                    switch (stat.gunStatType)
                                    {
                                        case GunStatType.Damage:
                                            shotGun.Damege += shotGun.Damege / 2;//���ݷ� 50���� ����
                                            break;
                                        case GunStatType.Ammo:
                                            shotGun.Ammo += shotGun.Ammo / 5;
                                            break;
                                        case GunStatType.BulletSpeed:
                                            shotGun.BulletSpeed += shotGun.BulletSpeed / 5;
                                            break;
                                        case GunStatType.BulletSpread:
                                            shotGun.BulletSpread += shotGun.BulletSpread / 5;
                                            break;
                                        case GunStatType.RateFire:
                                            shotGun.RateFire += shotGun.RateFire / 10;
                                            break;
                                        case GunStatType.HeatCapacity:
                                            shotGun.HeatCapacity += shotGun.HeatCapacity / 5;
                                            break;
                                    }
                                    break;
                                case GunType.Pistol:
                                    switch (stat.gunStatType)
                                    {
                                        case GunStatType.Damage:
                                            pistol.Damege += pistol.Damege * stat.value / 100;//���ݷ� 50���� ����
                                            break;
                                        case GunStatType.Ammo:
                                            pistol.Ammo += pistol.Ammo / 5;//źâ 20%����
                                            break;
                                        case GunStatType.BulletSpeed:
                                            pistol.BulletSpeed += pistol.BulletSpeed / 5; //����ü �ӵ� 20%����
                                            break;
                                        case GunStatType.BulletSpread:
                                            pistol.BulletSpread += pistol.BulletSpread / 5;//ź���� 20����
                                            break;
                                        case GunStatType.RateFire:
                                            pistol.RateFire += pistol.RateFire / 10;//�߻� �ӵ� 10% ����
                                            break;
                                        case GunStatType.HeatCapacity:
                                            pistol.HeatCapacity += pistol.HeatCapacity / 5; //���뷮 20% ����
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case StatOperator.Minus:
                            switch (stat.gunType)
                            {
                                case GunType.AssualtRifle:
                                    switch (stat.gunStatType)
                                    {
                                        case GunStatType.Damage:
                                            assaultRifle.Damege -= assaultRifle.Damege * stat.value / 100;//���ݷ� 50���� ����
                                            break;
                                        case GunStatType.Ammo:
                                            assaultRifle.Ammo -= assaultRifle.Ammo * (int)stat.value / 100;
                                            break;
                                        case GunStatType.BulletSpeed:
                                            assaultRifle.BulletSpeed -= assaultRifle.BulletSpeed * stat.value / 100;
                                            break;
                                        case GunStatType.BulletSpread:
                                            assaultRifle.BulletSpread -= assaultRifle.BulletSpread * stat.value;
                                            break;
                                        case GunStatType.RateFire:
                                            assaultRifle.RateFire -= assaultRifle.RateFire / 10;
                                            break;
                                        case GunStatType.HeatCapacity:
                                            assaultRifle.HeatCapacity -= assaultRifle.HeatCapacity / 5;
                                            break;
                                    }
                                    break;
                                case GunType.Submachinegun:
                                    switch (stat.gunStatType)
                                    {//�������
                                        case GunStatType.Damage:
                                            submachineGun.Damege -= submachineGun.Damege / 2;//���ݷ� 50���� ����
                                            break;
                                        case GunStatType.Ammo:
                                            submachineGun.Ammo -= submachineGun.Ammo / 5;
                                            break;
                                        case GunStatType.BulletSpeed:
                                            submachineGun.BulletSpeed -= submachineGun.BulletSpeed / 5;
                                            break;
                                        case GunStatType.BulletSpread:
                                            submachineGun.BulletSpread -= submachineGun.BulletSpread / 5;
                                            break;
                                        case GunStatType.RateFire:
                                            submachineGun.RateFire -= submachineGun.RateFire / 10;
                                            break;
                                        case GunStatType.HeatCapacity:
                                            submachineGun.HeatCapacity -= submachineGun.HeatCapacity / 5;
                                            break;
                                    }
                                    break;
                                case GunType.Shotgun:
                                    switch (stat.gunStatType)
                                    {
                                        case GunStatType.Damage:
                                            shotGun.Damege -= shotGun.Damege / 2;//���ݷ� 50���� ����
                                            break;
                                        case GunStatType.Ammo:
                                            shotGun.Ammo -= shotGun.Ammo / 5;
                                            break;
                                        case GunStatType.BulletSpeed:
                                            shotGun.BulletSpeed -= shotGun.BulletSpeed / 5;
                                            break;
                                        case GunStatType.BulletSpread:
                                            shotGun.BulletSpread -= shotGun.BulletSpread / 5;
                                            break;
                                        case GunStatType.RateFire:
                                            shotGun.RateFire -= shotGun.RateFire / 10;
                                            break;
                                        case GunStatType.HeatCapacity:
                                            shotGun.HeatCapacity -= shotGun.HeatCapacity / 5;
                                            break;
                                    }
                                    break;
                                case GunType.Pistol:
                                    switch (stat.gunStatType)
                                    {
                                        case GunStatType.Damage:
                                            pistol.Damege -= pistol.Damege * stat.value / 100;//���ݷ� 50���� ����
                                            break;
                                        case GunStatType.Ammo:
                                            pistol.Ammo -= pistol.Ammo / 5;//źâ 20%����
                                            break;
                                        case GunStatType.BulletSpeed:
                                            pistol.BulletSpeed -= pistol.BulletSpeed / 5; //����ü �ӵ� 20%����
                                            break;
                                        case GunStatType.BulletSpread:
                                            pistol.BulletSpread -= pistol.BulletSpread / 5;//ź���� 20����
                                            break;
                                        case GunStatType.RateFire:
                                            pistol.RateFire -= pistol.RateFire / 10;//�߻� �ӵ� 10% ����
                                            break;
                                        case GunStatType.HeatCapacity:
                                            pistol.HeatCapacity -= pistol.HeatCapacity / 5; //���뷮 20% ����
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





