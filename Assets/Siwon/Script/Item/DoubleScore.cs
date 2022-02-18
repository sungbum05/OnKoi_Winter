using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleScore :  MonoBehaviour
{
    public bool isDoubleScore = false;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
            isDoubleScore = true;
            StartCoroutine(DoubleScoreWait());
        }
        isDoubleScore = false;
    }
    IEnumerator DoubleScoreWait()
    {
        Debug.Log("DoubleScore");
        yield return new WaitForSeconds(30f);
    }
}
