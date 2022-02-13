using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    [SerializeField]
    GameObject KindGun;

    [SerializeField]
    GameObject CurGun;

    [SerializeField]
    private List<GameObject> KindsGun = new List<GameObject>();

    float Score { get; set; }

    [Header("Score & Level")]
    public Text ScoreTxt;
    public Text LevelTxt;
    public Slider ExpBar;

    [Header("Hp & Shield")]
    public Text Hp;
    public Text Shield;
    public Slider HpBar;
    public Slider ShieldBar;

    [Header("HeatCap & Ammo")]
    public Text Ammo;
    public Slider HeatCapBar;
    public Slider AmmoBar;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        StartSet();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSet();
        GoGameOver();
    }

    void StartSet()
    {
        Shield.text = $"Shield: {Player.GetComponent<PlayerContorller>().Shield}";
        ShieldBar.maxValue = Player.GetComponent<PlayerContorller>().Shield;
        ShieldBar.value = Player.GetComponent<PlayerContorller>().Shield;

        Hp.text = $"Hp: {Player.GetComponent<PlayerContorller>().Hp}";
        HpBar.maxValue = Player.GetComponent<PlayerContorller>().Hp;
        HpBar.value = Player.GetComponent<PlayerContorller>().Hp;

        Score = 0;
        ScoreTxt.text = $"Score: {Score}";

        ExpBar.maxValue = Player.GetComponent<PlayerContorller>().MaxExp;
        ExpBar.value = Player.GetComponent<PlayerContorller>().CurExp;

        SetGunKinds();
    }

    void UpdateSet()
    {
        Shield.text = $"Shield: {Player.GetComponent<PlayerContorller>().Shield}";
        ShieldBar.value = Player.GetComponent<PlayerContorller>().Shield;
        ShieldBar.maxValue = Player.GetComponent<PlayerContorller>().MaxShield;

        Hp.text = $"Hp: {Player.GetComponent<PlayerContorller>().Hp}";
        HpBar.value = Player.GetComponent<PlayerContorller>().Hp;

        ScoreTxt.text = $"Score: {Score}";

        ExpBar.maxValue = Player.GetComponent<PlayerContorller>().MaxExp;
        ExpBar.value = Player.GetComponent<PlayerContorller>().CurExp;

        GetCurGunInfo();
    }

    void GoGameOver()
    {
        if(Player == null)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void SetGunKinds()
    {
        for (int i = 0; i < KindGun.transform.GetChildCount(); i++)
        {
            KindsGun.Add(KindGun.transform.GetChild(i).gameObject);
        }
    }

    public void GetCurGunInfo()
    {
        foreach(GameObject GunObj in KindsGun)
        {
            if(GunObj.active)
            {
                CurGun = GunObj;

                AmmoBar.maxValue = GunObj.GetComponent<SetGun>().Ammo;
                AmmoBar.value = GunObj.GetComponent<SetGun>().CurAmmo;

                HeatCapBar.maxValue = GunObj.GetComponent<SetGun>().HeatCapacity;
                HeatCapBar.value = GunObj.GetComponent<SetGun>().CurHeatCapacity;

                if (GunObj.name == GunObj.GetComponent<SetGun>().BasicGun.name)
                {
                    Ammo.text = $"¡Ä";
                }

                else
                {
                    Ammo.text = $"{AmmoBar.value}/{AmmoBar.maxValue}";
                }
            }
        }
    }

    public void AddScore()
    {
        Score += 150;
    }
}
