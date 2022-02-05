using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public abstract class Item : MonoBehaviour
{
    public bool HitPlayer = false;
    public bool Itemuse = false;
    Camera Cam;
    [SerializeField]
    Text text;
    public enum ItemType
    {
        Gun,
        Item
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HitPlayer = true;
        }
    }
    void Start()
    {
        
        Cam = Camera.main;
    }
    protected virtual void Update()
    {
        text.transform.rotation = Cam.transform.rotation;
        if (HitPlayer == true && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(this.gameObject);
            Itemuse = true;
        }
    }
}
