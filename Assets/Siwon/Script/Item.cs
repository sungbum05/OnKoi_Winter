using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class Item : MonoBehaviour
{
    public bool HitPlayer = false;
    public bool Itemuse = false;
    private Camera cam;
    public Vector3 ItemPosition;
    
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

    protected virtual void Start()
    {
        Itemname.text = this.gameObject.name;
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Itemuse = true;
        }
    }

    protected virtual void Update()
    {
        if (HitPlayer == true)
        {
            Destroy(this.gameObject);
            Itemuse = false;
        }
    }
}