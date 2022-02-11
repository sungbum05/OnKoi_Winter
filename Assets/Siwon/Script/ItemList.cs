using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemGrade {S,A,B,C,D}
public enum ItemType { None,Gun,Skill}

[System.Serializable]
public class ItemList
{
    public string itemName;
    public GameObject itemObject;
    public ItemGrade itemGrade;
    public ItemType itemType;
    public int weight;

    public ItemList(ItemList itemlist)
    {
        this.itemName = itemlist.itemName;
        this.itemObject = itemlist.itemObject;
        this.itemGrade = itemlist.itemGrade;
        this.itemType = itemlist.itemType;
        this.weight = itemlist.weight;
    }
}
