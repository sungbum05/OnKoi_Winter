using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : SetGun
{
    public Transform ShootPosition;

    float PlusBeforeTime = 2.0f;
    float BeforeFireTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        base.SettingGun();
    }

    // Update is called once per frame
    void Update()
    {
        FireGun();

        if (IsMaxCap == true || BeforeFireTime <= 0)
        {
            MinusHeatCapacity();
        }
    }

    void FireGun()
    {
        base.RateAttackDel();
        BeforeFireTime -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            base.ChangeBasicGun();
        }

        if (Input.GetMouseButton(0) && MaxRateFire <= 0.0f && IsMaxCap == false)
        {
            EmptyAmmo();

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

            Vector3 RandomRay = new Vector3(Random.RandomRange(-BulletSpread, BulletSpread + 0.1f), 0, Random.RandomRange(-BulletSpread, BulletSpread + 0.1f));

            Bullet.GetComponent<Rigidbody>().AddForce((this.ShootPosition.forward + RandomRay) * BulletSpeed, ForceMode.Impulse);
            Destroy(Bullet, Random.Range(0.15f, 0.24f));//총알 삭제

            Debug.DrawRay(this.ShootPosition.position, (this.ShootPosition.forward + RandomRay) * 30.0f, Color.red, 0.5f);

            if (Physics.Raycast(this.ShootPosition.position, this.ShootPosition.forward + RandomRay, out hitInfo, 30.0f))
            {
                if (hitInfo.transform.gameObject.tag == "Enemy")
                {
                    hitInfo.transform.gameObject.GetComponent<Unit>().OnHit(Damege);

                    GameObject Particle = Instantiate(GunParticle);
                    Particle.transform.position = hitInfo.transform.position;
                    Destroy(Bullet, Random.Range(0.07f, 0.11f));
                }
            }
        }
    }
}
