using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGun : MonoBehaviour
{
    private enum GunType
    {
        Pistol = 0,
        Revolver = 1,
        ShotGun = 2,
        MiniGun = 3,
    }

    public struct GunState
    {
        public float Damege { get; set; }
        public float RateFire { get; set; }
        public float BulletSpread { get; set; }
        public float HeatCapacity { get; set; }

        public int Ammo { get; set; }
    }

    private string[] GunName; 

    [SerializeField]
    private GameObject AmmoType;

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

        string[] GunName = gameObject.name.Split('_');

        int GunNum = int.Parse(GunName[SecondIdx]);

        switch (GunNum)
        {
            case (int)GunType.Pistol:
                SetPistol();
                break;

            case (int)GunType.Revolver:
                SetRevolver();
                break;

            case (int)GunType.ShotGun:
                SetShotGun();
                break;

            case (int)GunType.MiniGun:
                SetMiniGun();
                break;
        }
    }

    protected virtual void SetPistol()
    {

    }

    protected virtual void SetRevolver()
    {

    }

    protected virtual void SetShotGun()
    {

    }

    protected virtual void SetMiniGun()
    {

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
