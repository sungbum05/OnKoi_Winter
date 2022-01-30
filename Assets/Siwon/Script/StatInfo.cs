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

        foreach (var stat in statValues)//statValue에는 StatType, StatOperater가 있음
        {
            switch (stat.statsType)
            {
                case StatsType.Player:
                    result += "플레이어의 ";
                    result += stat.statType switch
                    {
                        PlayerStatType.Hp => "최대 체력이",
                        PlayerStatType.MoveSpeed => "이동 속도가",
                        PlayerStatType.Damage => "데미지가",
                        PlayerStatType.Shield => "쉴드가",
                        _ => "",
                    };
                    break;
                case StatsType.Gun:
                    result += stat.gunType switch
                    {
                        GunType.Chargerifle => "돌격소총의",
                        GunType.Machinedagger => "기관단총의",
                        GunType.Shotgun => "산탄총의",
                        GunType.Pistol => "권총의",
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
        
        return result.Substring(0,result.Length-1);
    }
}
//플레이어냐 총이냐
public enum StatsType
{
    None,
    Gun,
    Player
}
//Machinedagger:기관단총
//Chargerifle:돌격소총
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
