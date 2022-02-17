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

   

    protected virtual void Start()
    {
      
        
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Itemuse = true;
            
        }
    }

    
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
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