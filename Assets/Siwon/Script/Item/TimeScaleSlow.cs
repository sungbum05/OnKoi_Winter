using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleSlow : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            Time.timeScale = 0.3f;
            StartCoroutine(TimeScaleWait());
        }
        Time.timeScale = 1f;
    }
    IEnumerator TimeScaleWait()
    {
        yield return new WaitForSeconds(20f);
    }
}
