using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

    [Serializable, CreateAssetMenu(fileName = "Item", menuName = "Infos/Item", order = 0)]
public class Item
{
    //Machinedagger:±â°ü´ÜÃÑ
    //Chargerifle:µ¹°Ý¼ÒÃÑ
    public enum Gun
    {
        Machinedagger,
        Shotgun,
        Chargerifle
    }
    public enum Skill
    {

    }

    struct GunType
    {
        public Gun gun;
        public Skill skill;
        public float ItemValue;
    }

   
}
