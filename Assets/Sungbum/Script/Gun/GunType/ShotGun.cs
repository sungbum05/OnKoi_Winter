using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : SetGun
{
    public Transform ShootPosition;
    private int ShotGunCnt = 0;

    private void Awake()
    {
        base.SettingGun();
    }

    // Update is called once per frame
    void Update()
    {
        FireGun();
    }

    void FireGun()
    {
        base.RateAttackDel();

        if (Input.GetMouseButton(0) && RateFire <= 0.0f)
        {
            //SoundMgr.In.PlaySound("1");
            RateFire = 0.6f;

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

        Debug.DrawRay(this.transform.position, (this.ShootPosition.forward + RandomRay) * 30.0f, Color.red, 0.5f);

        Destroy(Bullet, Random.Range(0.15f, 0.20f));//총알 삭제

        if (Physics.Raycast(this.transform.position, this.ShootPosition.forward + RandomRay, out hitInfo, 30.0f))
        {
            Debug.DrawRay(this.transform.position, (this.ShootPosition.forward + RandomRay) * 30.0f, Color.red, 0.5f);

            switch (GetEnemyType(hitInfo))
            {
                case 0:
                    break;

                case 1:
                    hitInfo.transform.gameObject.GetComponent<EnemyController>().OnHit(Damege);
                    break;

                case 2:
                    hitInfo.transform.gameObject.GetComponent<Enemy2Controller>().OnHit(Damege);
                    break;

                //case 3:
                //    hitInfo.transform.gameObject.GetComponent<Enemy2Controller>().OnHit(Damege);
                //    break;

                default:
                    break;
            }

            GameObject Particle = Instantiate(GunParticle);
            Particle.transform.position = hitInfo.transform.position;
            Destroy(Bullet, Random.Range(0.07f, 0.11f));

            Debug.Log(hitInfo.transform.name);
        }

        if (ShotGunCnt >= 10)
        {
            ShotGunCnt = 0;
            StopCoroutine("CreatedBullet");
        }

        else
        {
            yield return new WaitForSeconds(Random.RandomRange(0.000002f, 0.000005f));
            StartCoroutine("CreatedBullet");
        }
    }
}
