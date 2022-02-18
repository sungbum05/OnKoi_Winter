using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Item : MonoBehaviour
{
    [SerializeField]
    private GameObject Explosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<MeshFilter>().mesh = null;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            StartCoroutine(ExplosionSpawn());
        }
    }

    IEnumerator ExplosionSpawn()
    {
        Instantiate(Explosion, new Vector3(this.transform.position.x, Explosion.transform.position.y,
            this.transform.position.z), Quaternion.identity);

        yield return null;
        Destroy(this.gameObject);
    }
}
