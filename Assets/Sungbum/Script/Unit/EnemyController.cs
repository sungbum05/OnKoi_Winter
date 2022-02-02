using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Unit // 상속해주면 unit에 있는 hp나 movespeed사용가능
{
    [SerializeField]
    GameObject Player;

    [SerializeField]
    UI_Manager uI_Manager;

    Vector3 TargetPosition;

    private float RateAttack;
    private float RateTime = 0.5f;

    private void OnDestroy()
    {
        Player.gameObject.GetComponent<PlayerContorller>().LevelUp();
        uI_Manager.AddScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        uI_Manager = GameObject.Find("UiManager").GetComponent<UI_Manager>();
        EnemySet();
    }

    // Update is called once per frame
    void Update()
    {
        RateAttackDel();
        EnemyMove();
    }

    void EnemySet() // 적 기본 셋팅 awake나 start에서 실행
    {
        Hp = 35;
        RateAttack = RateTime;
        MoveSpeed = 1.5f;
    }

    void Target()
    {
        TargetPosition = Player.transform.position - this.transform.position;
        TargetPosition.Normalize();
    }

    void EnemyMove()
    {
        this.transform.Find("Enemy_Sprite").Rotate(270 * Time.deltaTime, 0.0f, 100 * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(TargetPosition).normalized;

        Target();
        transform.position += TargetPosition * MoveSpeed * Time.deltaTime;
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Player") && RateAttack <= 0)
        {
            RateAttack = RateTime;
            other.gameObject.GetComponent<PlayerContorller>().OnHit(10); // 플레이어 공격 
        }
    }

    void RateAttackDel()
    {
        if(RateAttack >= 0)
        {
            RateAttack -= Time.deltaTime;
        }
    }
}
