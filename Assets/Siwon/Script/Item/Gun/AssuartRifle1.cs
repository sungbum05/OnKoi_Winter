using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssuartRifle1 : Item
{
    [SerializeField]
    private Text F;
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            F.gameObject.SetActive(true);
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
        if (HitPlayer == true && Input.GetKeyDown(KeyCode.F))
        {
            gameObject.transform.FindChild("assaultrifle_3").gameObject.SetActive(true);
            Destroy(this.gameObject);

        }
    }
}
