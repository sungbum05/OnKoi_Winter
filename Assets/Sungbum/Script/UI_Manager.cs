using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

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
    }

    void GoGameOver()
    {
        if(Player == null)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void AddScore()
    {
        Score += 150;
    }
}
