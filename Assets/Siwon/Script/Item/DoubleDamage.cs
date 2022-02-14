using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamage : MonoBehaviour
{
    SetGun setGun;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            Destroy(this.gameObject);
            setGun.Damege *= 2;
            StartCoroutine(isDoubleDamageWait());
        }
        setGun.Damege /= 2;
    }
    IEnumerator isDoubleDamageWait()
    {
        yield return new WaitForSeconds(30f);
    }


}
