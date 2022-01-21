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
        Debug.Log("Pistol");
        
        GunState PistolGun = new GunState();

        PistolGun.Damege = 20.0f;
        PistolGun.RateFire = 0.5f;
        PistolGun.BulletSpread = 3.0f;
        PistolGun.HeatCapacity = 50.0f;

        PistolGun.Ammo = 15;
    }

    void FireGun()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate(AmmoType);
            Bullet.transform.parent = BulletZip.transform;
            Bullet.transform.localScale = new Vector3(1, 1, 1);
            Bullet.transform.localPosition = new Vector3(Bullet.transform.position.x,
                this.transform.localPosition.y, Bullet.transform.position.z);
        }
    }
}
