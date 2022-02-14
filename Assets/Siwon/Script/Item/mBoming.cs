using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mBoming : MonoBehaviour
{
    Unit unit;
    Collider thisCollider;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            unit.Hp -= 1000;
        }
    }
    private void Start()
    {
        
        thisCollider = GetComponent<Collider>();
        gameObject.SetActive(true);
        OnTriggerEnter(thisCollider);
        gameObject.SetActive(false);
    }
   
}
