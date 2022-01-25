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

        foreach (var stat in statValues)//statValue���� StatType, StatOperater�� ����
        {
            result += stat.statType switch
            {
                StatType.Hp => "�ִ� ü����",
                StatType.MoveSpeed => "�̵� �ӵ���",
                StatType.Damage => "��������",
                StatType.Shield => "���尡",
                _ => "",
            };
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
