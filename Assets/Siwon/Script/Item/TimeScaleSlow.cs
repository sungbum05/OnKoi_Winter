using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleSlow : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log(Time.timeScale);
            this.gameObject.GetComponent<MeshFilter>().mesh = null;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            StartCoroutine(TimeScaleWait());
        }
    }

    IEnumerator TimeScaleWait()
    {
        while(Time.timeScale >= 0.6f)
        {
            yield return null;

            Time.timeScale -= 0.7f * Time.deltaTime;
        }

        Time.timeScale = 0.6f;

        yield return new WaitForSeconds(5f);

        while (Time.timeScale <= 1.0f)
        {
            yield return null;

            Time.timeScale += 0.7f * Time.deltaTime;
        }
        Time.timeScale = 1f;

        Destroy(this.gameObject);
    }
}
