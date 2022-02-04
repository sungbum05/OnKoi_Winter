using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable, CreateAssetMenu(fileName = "StatInfo", menuName = "Infos/StatInfo", order = 0)]
public class StatInfo : ScriptableObject
{
    
    public List<StatValue> statValues;

    public override string ToString()
    {
        string result = default;

        foreach (var stat in statValues)//statValue���� StatType, StatOperater�� ����
        {
            switch (stat.statsType)
            {
                case StatsType.Player:
                    result += "�÷��̾��� ";
                    result += stat.statType switch
                    {
                        PlayerStatType.Hp => "�ִ� ü����",
                        PlayerStatType.MoveSpeed => "�̵� �ӵ���(%)",
                        PlayerStatType.Damage => "��������(%)",
                        PlayerStatType.Shield => "���尡",
                        _ => "",
                    };
                    break;
                case StatsType.Gun:
                    switch(stat.gunType)
                    {
                        case GunType.AssualtRifle:
                            result += "���ݼ�����(%)";
                            switch (stat.gunStatType)
                            {
                                case GunStatType.Damage:
                                    result += "��������";
                                    break;
                                case GunStatType.Ammo:
                                    result += "�Ѿ� ������";
                                    break;
                                case GunStatType.BulletSpeed:
                                    result += "�Ѿ˼ӵ���";
                                        break;
                                case GunStatType.BulletSpread:
                                    result += "ź������";
                                    break;
                                case GunStatType.RateFire:
                                    result += "���ݼӵ���";
                                    break;
                                case GunStatType.HeatCapacity:
                                    result += "�� �뷮��";
                                    break;
                            }
                            break;
                        case GunType.Submachinegun:
                            result += "���������(%)";
                            switch (stat.gunStatType)
                            {
                                case GunStatType.Damage:
                                    result += "��������";
                                    break;
                                case GunStatType.Ammo:
                                    result += "�Ѿ� ������";
                                    break;
                                case GunStatType.BulletSpeed:
                                    result += "�Ѿ˼ӵ���";
                                    break;
                                case GunStatType.BulletSpread:
                                    result += "ź������";
                                    break;
                                case GunStatType.RateFire:
                                    result += "���ݼӵ���";
                                    break;
                                case GunStatType.HeatCapacity:
                                    result += "�� �뷮��";
                                    break;
                            }
                            break;
                        case GunType.Shotgun:
                            result += "��ź����(%)";
                            switch (stat.gunStatType)
                            {
                                case GunStatType.Damage:
                                    result += "��������";
                                    break;
                                case GunStatType.Ammo:
                                    result += "�Ѿ� ������";
                                    break;
                                case GunStatType.BulletSpeed:
                                    result += "�Ѿ˼ӵ���";
                                    break;
                                case GunStatType.BulletSpread:
                                    result += "ź������";
                                    break;
                                case GunStatType.RateFire:
                                    result += "���ݼӵ���";
                                    break;
                                case GunStatType.HeatCapacity:
                                    result += "�� �뷮��";
                                    break;
                            }
                            break;
                        case GunType.Pistol:
                            result += "������(%)";
                            switch (stat.gunStatType)
                            {
                                case GunStatType.Damage:
                                    result += "��������";
                                    break;
                                case GunStatType.Ammo:
                                    result += "�Ѿ� ������";
                                    break;
                                case GunStatType.BulletSpeed:
                                    result += "�Ѿ˼ӵ���";
                                    break;
                                case GunStatType.BulletSpread:
                                    result += "ź������";
                                    break;
                                case GunStatType.RateFire:
                                    result += "���ݼӵ���";
                                    break;
                                case GunStatType.HeatCapacity:
                                    result += "�� �뷮��";
                                    break;
                            }
                            break;
                        default:
                            result += "";
                            break;
                    }
                   break;
            }
            result += $" {stat.value}��ŭ";
            result += stat.statOperator switch
            {
                StatOperator.Plus => " �����մϴ�",
                StatOperator.Minus => " �����մϴ�",
                _ => "",
            };
            result += "\n";
        }
        
        return result.Substring(0,result.Length-1);
    }
}
//�÷��̾�� ���̳�
public enum StatsType
{
    None,
    Gun,
    Player
}

public enum GunType
{
    None,
    Pistol,
    Submachinegun,
    Shotgun,
    AssualtRifle
}

public enum PlayerStatType
{
    None,
    Damage,
    MoveSpeed,
    Hp,
    Shield,
}
public enum GunStatType
{
    None,
    Damage,
    RateFire,
    Ammo,
    HeatCapacity,
    BulletSpeed,
    BulletSpread
}
public enum StatOperator
{
    Plus,
    Minus,
}
[Serializable]
public struct StatValue
{
    public GunStatType gunStatType;
    public GunType gunType;
    public StatsType statsType;
    public PlayerStatType statType;
    public StatOperator statOperator; 
    public float value;
}
