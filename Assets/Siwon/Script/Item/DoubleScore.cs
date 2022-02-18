using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleScore :  MonoBehaviour
{
    public GameObject AddScore;

    private void Awake()
    {
        AddScore = GameObject.Find("UiManager");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            this.gameObject.GetComponent<MeshFilter>().mesh = null;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);

            AddScore.GetComponent<UI_Manager>().isDoubleScore = true;
            StartCoroutine(DoubleScoreWait());
        }
    }
    IEnumerator DoubleScoreWait()
    {
        Debug.Log("DoubleScore");
        yield return new WaitForSeconds(10f);

        AddScore.GetComponent<UI_Manager>().isDoubleScore = false;
        Destroy(this.gameObject);
    }
}
