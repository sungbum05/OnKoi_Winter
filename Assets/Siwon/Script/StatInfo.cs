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
            result += stat.statType switch
            {
                StatType.Hp => "최대 체력이",
                StatType.MoveSpeed => "이동 속도가",
                StatType.Damage => "데미지가",
                StatType.Shield => "쉴드가",
                _ => "",
            };
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
public enum StatType
{
    Damage,
    MoveSpeed,
    Hp,
    Shield
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
    public StatType statType;
    public StatOperator statOperator;
    public float value;


}
