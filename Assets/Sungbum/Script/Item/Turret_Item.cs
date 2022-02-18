using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Item : MonoBehaviour
{
    public GameObject Turret;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<MeshFilter>().mesh = null;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            StartCoroutine(TurretSpawn());
        }
    }

    IEnumerator TurretSpawn()
    {
        Instantiate(Turret, new Vector3(this.transform.position.x, Turret.transform.position.y, 
            this.transform.position.z),Quaternion.identity);

        yield return null;
        Destroy(this.gameObject);
    }
}
