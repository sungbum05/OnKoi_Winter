using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : SetGun
{
    public Transform ShootPosition;
    private int ShotGunCnt = 0;

    float PlusBeforeTime = 2.0f;
    float BeforeFireTime = 2.0f;

    private void Awake()
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

            StartCoroutine("CreatedBullet");
            //RaycastHit hitInfo;

            //GameObject Bullet = Instantiate(AmmoType);
            //Bullet.transform.parent = BulletZip.transform; //오브젝트 위치 이동
            //Bullet.transform.localScale = new Vector3(1, 1, 1); // 스케일 조절
            //Bullet.transform.position = new Vector3(this.ShootPosition.position.x, // 생성위치 이동
            //this.ShootPosition.position.y, this.ShootPosition.position.z);

            //Vector3 RandomRay = new Vector3(Random.RandomRange(-BulletSpread, BulletSpread + 0.1f), 0, 0);

            //Bullet.GetComponent<Rigidbody>().AddForce((this.ShootPosition.forward + RandomRay) * BulletSpeed , ForceMode.Impulse);
            //Debug.DrawRay(this.transform.position, (this.ShootPosition.forward + RandomRay) * 30.0f, Color.red, 0.5f);

            //Destroy(Bullet, Random.Range(0.15f, 0.24f));//총알 삭제

            //if (Physics.Raycast(this.transform.position, this.ShootPosition.forward + RandomRay, out hitInfo, 30.0f))
            //{
            //    Debug.DrawRay(this.transform.position, (this.ShootPosition.forward + RandomRay) * 30.0f, Color.red, 0.5f);

            //    hitInfo.transform.gameObject.GetComponent<EnemyController>().OnHit(Damege);

            //    GameObject Particle = Instantiate(GunParticle);
            //    Particle.transform.position = hitInfo.transform.position;
            //    Destroy(Bullet, Random.Range(0.07f, 0.11f));

            //    Debug.Log(hitInfo.transform.name);
            //}
        }
    }

    IEnumerator CreatedBullet()
    {
        ShotGunCnt++;

        RaycastHit hitInfo;

        GameObject Bullet = Instantiate(AmmoType);
        Bullet.transform.parent = BulletZip.transform; //오브젝트 위치 이동
        Bullet.transform.localScale = new Vector3(1, 1, 1); // 스케일 조절
        Bullet.transform.position = new Vector3(this.ShootPosition.position.x, // 생성위치 이동
        this.ShootPosition.position.y, this.ShootPosition.position.z);

        Vector3 RandomRay = new Vector3(Random.RandomRange(-BulletSpread, BulletSpread + 0.1f), 0, Random.RandomRange(-BulletSpread, BulletSpread + 0.1f));

        Bullet.GetComponent<Rigidbody>().AddForce((this.ShootPosition.forward + RandomRay) * BulletSpeed, ForceMode.Impulse);

        Debug.DrawRay(this.ShootPosition.position, (this.ShootPosition.forward + RandomRay) * 30.0f, Color.red, 0.5f);

        Destroy(Bullet, Random.Range(0.15f, 0.20f));//총알 삭제

        if (Physics.Raycast(this.ShootPosition.position - new Vector3(0, 1.0f, 0), this.ShootPosition.forward + RandomRay, out hitInfo, 30.0f))
        {
            if(hitInfo.transform.gameObject.tag == "Enemy")
            {
                Debug.DrawRay(this.ShootPosition.position, (this.ShootPosition.forward + RandomRay) * 30.0f, Color.red, 0.5f);

                hitInfo.transform.gameObject.GetComponent<Unit>().OnHit(Damege);

                GameObject Particle = Instantiate(GunParticle);
                Particle.transform.position = hitInfo.transform.position;
                Destroy(Bullet, Random.Range(0.07f, 0.11f));
            }
        }

        if (ShotGunCnt >= 10)
        {
            ShotGunCnt = 0;
            StopCoroutine("CreatedBullet");
        }

        else
        {
            Debug.Log("hi");
            yield return new WaitForSeconds(Random.RandomRange(0.00002f, 0.00005f));
            StartCoroutine("CreatedBullet");
        }
    }
}
