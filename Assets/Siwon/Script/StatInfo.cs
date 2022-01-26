using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable, CreateAssetMenu(fileName = "StatInfo", menuName = "Infos/StatInfo", order = 0)]
public class StatInfo 
{
    
    public List<StatValue> statValues;

    public override string ToString()
    {
        string result = default;

        foreach (var stat in statValues)//statValue에는 StatType, StatOperater가 있음
        {
            switch (stat.statsType)
            {
                case StatsType.Player:
                    result += "플레이어의";
                    result += stat.statType switch
                    {
                        StatType.Hp => "최대 체력이",
                        StatType.MoveSpeed => "이동 속도가",
                        StatType.Damage => "데미지가",
                        StatType.Shield => "쉴드가",
                        _ => "",
                    };
                    break;
                case StatsType.Gun:
                    result += stat.gunType switch
                    {
                        GunType.Chargerifle => "돌격소총의",
                        GunType.Machinedagger => "기관단총의",
                        GunType.Shotgun => "산탄총의",
                        _ => "",
                    };

                   break;
            }
            
            result += $" {stat.value}만큼";
            result += stat.statOperator switch
            {
                StatOperator.Plus => " 증가합니다",
                StatOperator.Minus => " 감소합니다",
                StatOperator.Multi => " 배가됩니다",
                _ => "",
            };
            result += "\n";
        }

        return result;
    }
}
//플레이어냐 총이냐
public enum StatsType
{
    Gun,
    Player
}
public enum GunType
{
    Machinedagger,
    Shotgun,
    Chargerifle
}

public enum StatType
{
    Damage,
    MoveSpeed,
    Hp,
    Shield,
}
public enum GunStatType
{
    AtteckSpeed,
    Capacity,
    Heat
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
    public GunType gunType;
    public StatsType statsType;
    public StatType statType;
    public StatOperator statOperator; 
    public float value;
}
