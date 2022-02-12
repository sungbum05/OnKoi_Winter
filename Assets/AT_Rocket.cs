using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_Rocket : SetGun
{
    public Transform ShootPosition;

    // Start is called before the first frame update
    void Start()
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

        if (Input.GetMouseButtonDown(0) && MaxRateFire <= 0.0f)
        {
            //SoundMgr.In.PlaySound("1");
            MaxRateFire = RateFire;

            GameObject Bullet = Instantiate(AmmoType);
            Bullet.transform.parent = BulletZip.transform; //오브젝트 위치 이동
            Bullet.transform.localScale = new Vector3(1, 1, 1); // 스케일 조절
            Bullet.transform.rotation = Quaternion.LookRotation(this.gameObject.transform.parent.parent.forward);
            Bullet.transform.position = new Vector3(this.ShootPosition.position.x, // 생성위치 이동
            this.ShootPosition.position.y, this.ShootPosition.position.z);

            Bullet.GetComponent<Rigidbody>().AddForce((this.ShootPosition.forward) * BulletSpeed, ForceMode.Impulse);
            //Destroy(Bullet, 3.0f);//총알 삭제

        }
    }
}
