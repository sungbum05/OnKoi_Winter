using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntiTankRocket : Item
{  

    void Start()
    {
       
    }
    protected override void OnTriggerEnter(Collider other)
    {
       
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            GameObject.Find("AT_Rocket_5").SetActive(true);
            base.Update();
        }
    }
    private void Update()
    {
        
    }
    protected override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
        
    }
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }
}
