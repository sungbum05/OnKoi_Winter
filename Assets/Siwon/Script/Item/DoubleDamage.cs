using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamage : MonoBehaviour
{
    SetGun setGun;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            //setGun.Damege *= 2;
            StartCoroutine(isDoubleDamageWait());
        }
        setGun.Damege /= 2;
    }
    IEnumerator isDoubleDamageWait()
    {
        Debug.Log("DoubleDamage");
        yield return new WaitForSeconds(30f);
    }
    private void Start()
    {
       
    }


}
