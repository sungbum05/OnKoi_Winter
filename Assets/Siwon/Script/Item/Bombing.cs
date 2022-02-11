using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombing : Item
{
    public float Radius;

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
            Vector3 MissilePos = Random.insideUnitSphere * Radius;
            Instantiate(mBoom, MissilePos, Quaternion.Euler(0, 0, 0));
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
