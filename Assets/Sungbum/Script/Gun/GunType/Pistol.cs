using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : SetGun
{
    public Transform ShootPosition;

    float PlusBeforeTime = 2.0f;
    float BeforeFireTime = 2.0f;

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
        Debug.Log(Damege);

        FireGun();

        if (IsMaxCap == true || BeforeFireTime <= 0)
        {
            MinusHeatCapacity();
        }
    }

    //protected override void SetPistol()
    //{
    //    Damege = 20.0f;
    //    RateFire = 0.07f;
    //    BulletSpread = 3.0f;
    //    BulletSpeed = 110.0f;
    //    HeatCapacity = 50.0f;

    //    Ammo = 15;
    //}

    void FireGun()
    {
        base.RateAttackDel();
        BeforeFireTime -= Time.deltaTime;

        if (Input.GetMouseButton(0) && MaxRateFire <= 0.0f && IsMaxCap == false)
        {
            PlusHeatCapacity();
            BeforeFireTime = PlusBeforeTime;

            //SoundMgr.In.PlaySound("1");
            MaxRateFire = RateFire;

            RaycastHit hitInfo;

            GameObject Bullet = Instantiate(AmmoType);
            Bullet.transform.parent = BulletZip.transform; //오브젝트 위치 이동
            Bullet.transform.localScale = new Vector3(1, 1, 1); // 스케일 조절
            Bullet.transform.position = new Vector3(this.ShootPosition.position.x, // 생성위치 이동
            this.ShootPosition.position.y, this.ShootPosition.position.z);
            Bullet.GetComponent<Rigidbody>().AddForce(this.ShootPosition.forward * BulletSpeed, ForceMode.Impulse); // 총알 발사

            Destroy(Bullet, Random.Range(0.15f, 0.20f));//총알 삭제

            if (Physics.Raycast(this.ShootPosition.position, this.transform.parent.transform.forward, out hitInfo, 30.0f))
            {
                if (hitInfo.transform.gameObject.tag == "Enemy")
                {
                    Debug.DrawRay(this.ShootPosition.position, (this.ShootPosition.forward) * 30.0f, Color.red, 0.5f);

                    hitInfo.transform.gameObject.GetComponent<Unit>().OnHit(Damege);
                  
                    GameObject Particle = Instantiate(GunParticle);
                    Particle.transform.position = hitInfo.transform.position;
                    Destroy(Bullet, Random.Range(0.07f, 0.11f));
                }
            }
        }
    }
}
