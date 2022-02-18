using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmachineGun1 : Item
{
    [SerializeField]
    private Text F;
    [SerializeField]
    GameObject KindGun;

    private void Awake()
    {
        KindGun = GameObject.Find("Player").transform.FindChild("KindGun").gameObject;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HitPlayer = true;
            F.gameObject.SetActive(true);
        }
    }
    protected override void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            HitPlayer = false;
            F.gameObject.SetActive(false);
        }
    }
    protected override void Update()
    {
        if (HitPlayer == true && Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < KindGun.transform.childCount; i++)
            {
                KindGun.transform.GetChild(i).gameObject.SetActive(false);
                KindGun.transform.GetChild(i).GetComponent<SetGun>().CurHeatCapacity = 0;
                KindGun.transform.GetChild(i).GetComponent<SetGun>().CurAmmo = KindGun.transform.GetChild(i).GetComponent<SetGun>().Ammo;
            }

            KindGun.transform.FindChild("submachinegun_2").gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
