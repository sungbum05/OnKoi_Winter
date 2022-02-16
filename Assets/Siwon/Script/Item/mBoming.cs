using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mBoming : Bombing
{
    Unit unit;
    Bombing bombing;
    Vector3 MissilePos;
    //[SerializeField]
    //GameObject bombing1;
    

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        bombing = GetComponent<Bombing>();
        //bombing1 = GameObject.Find("Bombing");
       // MissilePos = bombing1.transform.position + Random.insideUnitSphere * Radius;//=Null Yabal
        MissilePos = bombing.transform.position + Random.insideUnitSphere * Radius;
        Mpos = new Vector3(MissilePos.x, 1f, MissilePos.z);
    }
    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, Mpos, 10f * Time.deltaTime);
    }
   
}
