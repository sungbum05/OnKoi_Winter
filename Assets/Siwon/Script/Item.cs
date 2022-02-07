using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public abstract class Item : MonoBehaviour
{
    public bool HitPlayer = false;
    public bool Itemuse = false;
    private Camera cam;
    public Camera Cam
    {
        get
        {
            if (cam == null)
            {
                cam = Camera.main;
            }
            return cam;
        }
    }

    [SerializeField]
    protected Text Itemname;
    private Text Key;
    public enum ItemType
    {
        Gun,
        Item
    }
    protected virtual void Start()
    {
        Itemname.text = GetComponent<Item>().name;

    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            HitPlayer = true;
        }
    }

    protected virtual void Update()
    {
        Itemname.transform.forward = Cam.transform.forward;
        if (HitPlayer == true && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(this.gameObject);
            Itemuse = true;
        }
    }
}
