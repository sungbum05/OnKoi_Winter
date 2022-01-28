using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunChuSang : MonoBehaviour
{
    struct GunStat
    {
        float ShootSpeed;
        float Damage;
        float Heat;
        float BulletSize;
    }
    protected virtual void Shoot()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {

        }
    }
}
