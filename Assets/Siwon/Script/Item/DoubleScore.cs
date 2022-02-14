using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleScore : MonoBehaviour
{
    public bool isDoubleScore = false;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            Destroy(this.gameObject);
            isDoubleScore = true;
            StartCoroutine(DoubleScoreWait());
        }
        isDoubleScore = false;
    }
    IEnumerator DoubleScoreWait()
    {
        yield return new WaitForSeconds(30f);
    }
}
