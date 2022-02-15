using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mBoming : Bombing
{
    Unit unit;
    Bombing bombing;
    Vector3 MissilePos;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            unit.Hp -= 1000;
        }
    }
    private void Start()
    {
        MissilePos = bombing.transform.position + Random.insideUnitSphere * Radius;
        Mpos = new Vector3(MissilePos.x, 1f, MissilePos.z);
    }
    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, Mpos, 10f * Time.deltaTime);
    }
}
