using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StatDotWeen : MonoBehaviour
{
   
    [SerializeField] Image Stop;
    [SerializeField] Transform Start_position;
    [SerializeField] Transform End_position;
    [SerializeField] Transform Close_Btn;
    [SerializeField] Transform Close_Start_Btn;
    [SerializeField] Transform Close_End_Btn;

    public GameObject Black_BackGround;


    public void Start()
    {
        Initialize_01();
        Black_BackGround.SetActive(false);
    }
    public void Initialize()
    {
        Black_BackGround.SetActive(true);
        Stop.transform.DOMove(End_position.position, 0.5f).SetEase(Ease.OutBack);
        Close_Btn.transform.DOMove(Close_End_Btn.position, 0.5f).SetEase(Ease.OutBack);
    }

    public void Initialize_01()
    {
        Stop.transform.position = End_position.position;
        Close_Btn.transform.position = Close_End_Btn.position;
    }


    public void DotWeenEase()
    {
        Stop.transform.DOMove(Start_position.position, 0.5f).SetEase(Ease.OutBack);
        Close_Btn.transform.DOMove(Close_Start_Btn.position, 0.5f).SetEase(Ease.OutBack);
    }
}
