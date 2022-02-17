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
    
    protected virtual Camera Cam
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
    protected Text F;

    protected virtual void Start()
    {
        F = GetComponent<Text>();
        Itemname.text = this.gameObject.name;
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Itemuse = true;
        }
    }

    protected virtual void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            F.enabled = true;
        }
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            F.enabled = false;
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