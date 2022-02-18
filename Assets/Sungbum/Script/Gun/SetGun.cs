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
        H_machinegun = 4,
        AT_Rocket = 5,
        Turret = 6,
    }

    public float Damege { get; set; }
    public float RateFire { get; set; }
    public float MaxRateFire { get; set; }
    public float BulletSpread { get; set; }
    public float BulletSpeed { get; set; }

    public float HeatCapacity { get; set; }
    public float CurHeatCapacity { get; set; }
    public float HeatPlus { get; set; }

    [SerializeField]
    protected bool IsMaxCap = false;

    public int Ammo { get; set; }
    public int CurAmmo { get; set; }

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

    public GameObject BasicGun;

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
                BasicGun = this.transform.parent.transform.GetChild(0).gameObject;
                SetPistol();
                break;

            case (int)GunType.ShotGun:
                BasicGun = this.transform.parent.transform.GetChild(0).gameObject;
                SetShotGun();
                break;

            case (int)GunType.SubmachineGun:
                BasicGun = this.transform.parent.transform.GetChild(0).gameObject;
                SetSubmachineGun();
                break;

            case (int)GunType.AssaultRifle:
                BasicGun = this.transform.parent.transform.GetChild(0).gameObject;
                SetAssaultRifle();
                break;

            case (int)GunType.H_machinegun:
                BasicGun = this.transform.parent.transform.GetChild(0).gameObject;
                SetH_machinegun();
                break;

            case (int)GunType.AT_Rocket:
                BasicGun = this.transform.parent.transform.GetChild(0).gameObject;
                SetAT_Rocket();
                break;

            case (int)GunType.Turret:
                SetTurret();
                break;
        }
    }

    protected void EmptyAmmo()
    {
        CurAmmo--;

        if(CurAmmo <= 0)
        {
            ChangeBasicGun();
        }
    }

    protected void ChangeBasicGun()
    {
        CurAmmo = Ammo;

        BasicGun.gameObject.SetActive(true);
        BasicGun.GetComponent<SetGun>().CurHeatCapacity = 0;

        this.CurAmmo = Ammo;
        this.CurHeatCapacity = 0;
        this.gameObject.SetActive(false);
    }

    protected void PlusHeatCapacity()
    {
        CurHeatCapacity += HeatPlus;

        if(HeatCapacity <= CurHeatCapacity)
        {
            CurHeatCapacity = HeatCapacity;
            IsMaxCap = true;
        }
    }

    protected void MinusHeatCapacity()
    {
        if(CurHeatCapacity >= 0)
        {
            CurHeatCapacity -= 20 * Time.deltaTime;
        }

        if(CurHeatCapacity <= 0)
        {
            CurHeatCapacity = 0;
            IsMaxCap = false;
        }
    }

    protected void RateAttackDel()
    {
        if (MaxRateFire >= 0)
        {
            MaxRateFire -= Time.deltaTime;
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
        HeatPlus = 0.5f;

        Ammo = 99999999;
        CurAmmo = Ammo;
    }

    protected virtual void SetShotGun()
    {
        Damege = 7.0f;
        RateFire = 0.6f;
        BulletSpread = 0.35f;
        BulletSpeed = 200.0f;
        HeatCapacity = 50.0f;
        HeatPlus = 3.0f;

        Ammo = 75;
        CurAmmo = Ammo;
    }

    protected virtual void SetSubmachineGun()
    {
        Damege = 8.0f;
        RateFire = 0.05f;
        BulletSpread = 0.2f;
        BulletSpeed = 220.0f;
        HeatCapacity = 50.0f;
        HeatPlus = 0.5f;

        Ammo = 420;
        CurAmmo = Ammo;
    }

    protected virtual void SetAssaultRifle()
    {
        Damege = 20.0f;
        RateFire = 0.16f;
        BulletSpread = 0.1f;
        BulletSpeed = 180.0f;
        HeatCapacity = 100.0f;
        HeatPlus = 1.0f;

        Ammo = 320;
        CurAmmo = Ammo;
    }

    protected virtual void SetH_machinegun()
    {
        Damege = 30.0f;
        RateFire = 0.14f;
        BulletSpread = 0.3f;
        BulletSpeed = 200.0f;
        HeatCapacity = 100.0f;
        HeatPlus = 5.0f;

        Ammo = 400;
        CurAmmo = Ammo;
    }

    protected virtual void SetAT_Rocket()
    {
        Damege = 20.0f;
        RateFire = 0.5f;
        BulletSpread = 0.1f;
        BulletSpeed = 80;
        HeatCapacity = 100.0f;
        HeatPlus = 200.0f;

        Ammo = 5;
        CurAmmo = Ammo;
    }

    protected virtual void SetTurret()
    {
        Damege = 10.0f;
        RateFire = 0.1f;
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
