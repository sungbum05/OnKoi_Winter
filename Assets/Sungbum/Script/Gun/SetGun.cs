using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGun : MonoBehaviour
{
    private enum GunType
    {
        Pistol = 0,
        ShotGun = 1,
        SubmachineGun = 2,
        AssaultRifle = 3,
        Turret = 4,
    }

    public float Damege { get; set; }
    public float RateFire { get; set; }
    public float BulletSpread { get; set; }
    public float BulletSpeed { get; set; }
    public float HeatCapacity { get; set; }

    public int Ammo { get; set; }

    [SerializeField]
    private string[] GunName;

    [SerializeField]
    protected string[] EnemyType;

    [SerializeField]
    private int GunNum;

    [SerializeField]
    protected GameObject GunParticle;

    public GameObject AmmoType;
    public GameObject BulletZip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void SettingGun()
    {
        int SecondIdx = 1;

        GunName = gameObject.name.Split('_');

        GunNum = int.Parse(GunName[SecondIdx]);

        switch (GunNum)
        {
            case (int)GunType.Pistol:
                SetPistol();
                break;

            case (int)GunType.ShotGun:
                SetShotGun();
                break;

            case (int)GunType.SubmachineGun:
                SetSubmachineGun();
                break;

            case (int)GunType.AssaultRifle:
                SetAssaultRifle();
                break;

            case (int)GunType.Turret:
                SetTurret();
                break;
        }
    }

    protected void RateAttackDel()
    {
        if (RateFire >= 0)
        {
            RateFire -= Time.deltaTime;
        }
    }

    protected int GetEnemyType(RaycastHit HitInfo)
    {
        int SecondIdx = 1;

        EnemyType = HitInfo.transform.gameObject.name.Split('_');

        return int.Parse(EnemyType[SecondIdx]);
    }

    protected virtual void SetPistol()
    {
        Damege = 12.0f;
        RateFire = 0.5f;
        BulletSpeed = 200.0f;
        HeatCapacity = 50.0f;

        Ammo = 99999;
    }

    protected virtual void SetShotGun()
    {
        Damege = 7.0f;
        RateFire = 0.9f;
        BulletSpread = 0.35f;
        BulletSpeed = 200.0f;
        HeatCapacity = 50.0f;

        Ammo = 12;
    }

    protected virtual void SetSubmachineGun()
    {
        Damege = 8.0f;
        RateFire = 0.02f;
        BulletSpread = 0.2f;
        BulletSpeed = 220.0f;
        HeatCapacity = 50.0f;

        Ammo = 15;
    }

    protected virtual void SetAssaultRifle()
    {
        Damege = 20.0f;
        RateFire = 0.5f;
        BulletSpread = 0.1f;
        BulletSpeed = 180.0f;
        HeatCapacity = 100.0f;

        Ammo = 15;
    }

    protected virtual void SetTurret()
    {
        Damege = 10.0f;
        RateFire = 0.25f;
        BulletSpread = 0.1f;
        BulletSpeed = 210.0f;
    }

    // ±ÇÃÑ
    // ¸®º¼¹ö
    // ±â°ü´ÜÃÑ
    // »êÅºÃÑ
    // ¼ÒÃÑ
    // ¹ÝÀÚµ¿ ¼ÒÃÑ
    // ¹Ì´Ï°Ç
    // ¹ÙÁÖÄ«
}
