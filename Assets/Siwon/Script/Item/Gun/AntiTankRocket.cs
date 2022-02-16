using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntiTankRocket : Item
{
    Text text;
    

    void Start()
    {
        text = GetComponent<Text>();
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            text.enabled = true;
        }
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.F)) 
        {
            GameObject.Find("AT_Rocket_5").SetActive(true);
        }
    }
    private void Update()
    {
        base.Update();
    }
}
