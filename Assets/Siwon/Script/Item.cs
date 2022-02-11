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
    
    
   
   
    //public void GetTranform(Vector3 pos)
    //{
    //    endPos = pos;
    //    StartCoroutine(Temp(1f));
    //}

    //IEnumerator Temp(float speed)
    //{
    //    while (Vector3.Distance(transform.position, endPos) < 0.1f)
    //    {

    //        yield return null;
    //    }
    //    transform.position = endPos;

    //}

    protected virtual void Start()
    {
        Itemname.text = GetComponent<Item>().name;

    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }
    }

    protected virtual void Update()
    {

        if (HitPlayer == true && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(this.gameObject);
            Itemuse = true;
        }
    }
}
