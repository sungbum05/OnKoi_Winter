using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntiTankRocket : Item
{
    [SerializeField]
    private Text F;
    [SerializeField]
    GameObject KindGun;
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            HitPlayer = true;
            F.gameObject.SetActive(true);
        }
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
           
        }
    }
    protected override void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            F.gameObject.SetActive(false);
        }
    }
    protected override void Update()
    {
        if(HitPlayer == true && Input.GetKeyDown(KeyCode.F)) 
        {
            KindGun.transform.FindChild("ATRocket_5").gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}