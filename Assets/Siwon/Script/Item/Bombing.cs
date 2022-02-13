using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombing : Item
{
    public float Radius;
    Vector3 Mpos;

    public GameObject mBoom;
    //protected override void OnTriggerEnter(Collider other)
    //{
    //    base.OnTriggerEnter(other);
    //    Missile();
    //}

    public void Missile()
    {
        for (int i = 0; i < 8; i++)
        {
            Vector3 MissilePos = this.transform.position + Random.insideUnitSphere * Radius;
            //Mpos = (MissilePos.x, 1f, MissilePos.z);
            Instantiate(mBoom, Mpos, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
            StartCoroutine(MissileDel());
        }
    }
    
    void Start()
    {
        Missile();
    }
    IEnumerator MissileDel()
    {
        yield return new WaitForSeconds(0.15f);
    }
}
