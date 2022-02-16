using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    private GameObject ExplosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        ExplosionEffect.GetComponent<Explosion>().ExplosionScale = 15;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject ExplosionClone = Instantiate(ExplosionEffect);

            ExplosionEffect.GetComponent<Explosion>().ExplosionScale = 15;

            Debug.Log("Explo");
            ExplosionClone.transform.position = new Vector3(other.gameObject.transform.position.x,
                0.5f, other.gameObject.transform.position.z);

            Destroy(this.gameObject);
        }
    }
}
