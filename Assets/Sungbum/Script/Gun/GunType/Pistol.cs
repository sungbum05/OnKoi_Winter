using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : SetGun
{
    private void Awake()
    {
        base.SettingGun();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FireGun();
    }

    protected override void SetPistol()
    {
        Damege = 20.0f;
        RateFire = 0.5f;
        BulletSpread = 3.0f;
        BulletSpeed = 120.0f;
        HeatCapacity = 50.0f;

        Ammo = 15;
    }

    void FireGun()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate(AmmoType);
            Bullet.transform.parent = BulletZip.transform;
            Bullet.transform.localScale = new Vector3(1, 1, 1);
            Bullet.transform.position = new Vector3(this.transform.position.x,
                this.transform.position.y, this.transform.position.z);
            Bullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * BulletSpeed, ForceMode.Impulse);
        }
    }
}
