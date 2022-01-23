using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : SetGun
{
    public Transform ShootPosition;

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
        RateFire = 0.07f;
        BulletSpread = 3.0f;
        BulletSpeed = 120.0f;
        HeatCapacity = 50.0f;

        Ammo = 15;
    }

    void FireGun()
    {
        base.RateAttackDel();

        if (Input.GetMouseButton(0) && RateFire <= 0.0f)
        {
            SoundMgr.In.PlaySound("1");
            RateFire = 0.5f;
            RaycastHit hitInfo;

            GameObject Bullet = Instantiate(AmmoType);
            Bullet.transform.parent = BulletZip.transform;
            Bullet.transform.localScale = new Vector3(1, 1, 1);
            Bullet.transform.position = new Vector3(this.transform.position.x,
            this.transform.position.y, this.transform.position.z);
            Bullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * BulletSpeed, ForceMode.Impulse);

            if (Physics.Raycast(this.transform.position, this.transform.parent.transform.forward, out hitInfo, 30.0f))
            {
                Debug.DrawRay(this.transform.position, this.transform.parent.transform.forward * 30.0f, Color.red);
                hitInfo.transform.gameObject.GetComponent<EnemyController>().OnHit(Damege);

                GameObject Particle = Instantiate(GunParticle);
                Particle.transform.position = hitInfo.transform.position;
                
                Debug.Log(hitInfo.transform.name);
            }
        }
    }
}
