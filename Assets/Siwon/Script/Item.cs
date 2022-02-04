using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public abstract class Item : MonoBehaviour
{
    [SerializeField]
    Text text; 
    public enum ItemType
    {
        Gun,
        Item
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            text.transform.position = this.transform.position;
        }
    }
}
