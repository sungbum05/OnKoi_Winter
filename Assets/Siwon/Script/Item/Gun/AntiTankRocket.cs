using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntiTankRocket : Item
{
    [SerializeField]
    private Text F;
    void Start()
    {

        
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            F.gameObject.SetActive(true);
        }
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            GameObject.Find("AT_Rocket_5").SetActive(true);
            base.Update();
        }
    }
    protected override void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            F.gameObject.SetActive(false);
        }
    }
}
