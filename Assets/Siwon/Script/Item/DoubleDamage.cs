using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamage : MonoBehaviour
{
    public GameObject KindGun;

    private void Awake()
    {
        KindGun = GameObject.Find("Player").transform.FindChild("KindGun").gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < KindGun.transform.childCount; i++)
            {
                this.gameObject.GetComponent<MeshFilter>().mesh = null;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;

                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);

                KindGun.transform.GetChild(i).GetComponent<SetGun>().Damege *= 2;
            }

            StartCoroutine(isDoubleDamageWait());
        }
    }
    IEnumerator isDoubleDamageWait()
    {
        Debug.Log("DoubleDamage");
        yield return new WaitForSeconds(10f);

        for (int i = 0; i < KindGun.transform.childCount; i++)
        {
            KindGun.transform.GetChild(i).GetComponent<SetGun>().Damege /= 2;
        }

        Destroy(this.gameObject);
    }
}
