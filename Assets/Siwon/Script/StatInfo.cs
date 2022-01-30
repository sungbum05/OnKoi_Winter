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
                        PlayerStatType.MoveSpeed => "�̵� �ӵ���",
                        PlayerStatType.Damage => "��������",
                        PlayerStatType.Shield => "���尡",
                        _ => "",
                    };
                    break;
                case StatsType.Gun:
                    result += stat.gunType switch
                    {
                        GunType.Chargerifle => "���ݼ�����",
                        GunType.Machinedagger => "���������",
                        GunType.Shotgun => "��ź����",
                        GunType.Pistol => "������",
                        _ => "",
                    };

                   break;
            }
            
            result += $" {stat.value}��ŭ";
            result += stat.statOperator switch
            {
                StatOperator.Plus => " �����մϴ�",
                StatOperator.Minus => " �����մϴ�",
                StatOperator.Multi => " �谡�˴ϴ�",
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
//Machinedagger:�������
//Chargerifle:���ݼ���
public enum GunType
{
    None,
    Pistol,
    Machinedagger,
    Shotgun,
    Chargerifle
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
    Multi
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
