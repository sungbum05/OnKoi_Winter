using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mBoming : Bombing
{
    Unit unit;
    Bombing bombing;
    Vector3 MissilePos;
    public GameObject Explosion;
    

    void OnTriggerEnter(Collider collision)
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Floor"))
        {
            Debug.Log("¾ß¹ß");
            Instantiate(Explosion, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void Start()
    {

        bombing = GetComponent<Bombing>();
        MissilePos = bombing.transform.position + Random.insideUnitSphere * Radius;
        Mpos = new Vector3(MissilePos.x, 1f, MissilePos.z);
    }
    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, Mpos, 30f * Time.deltaTime);
    }
   
}
