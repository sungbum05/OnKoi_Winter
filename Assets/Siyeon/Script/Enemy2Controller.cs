using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : Unit
{
    [SerializeField]
    GameObject Player;

    [SerializeField]
    UI_Manager uI_Manager;

    Vector3 TargetPosition;
    ItemSpawner itemSpawner;

    private float RateAttack;
    private float RateTime = 0.8f;
    private float RateCurTime = 0;
    private float BulletSpeed = 3;

    public GameObject Bullet;
    public float Range;


    private void OnDestroy()
    {
        Player.gameObject.GetComponent<PlayerContorller>().LevelUp();
        uI_Manager.AddScore(150 + PlusScore)/*+값 넣어주면 될듯*/;
        itemSpawner.ResultSelect();
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

        RateCurTime += Time.deltaTime;

        if(Vector3.Distance(transform.position,Player.transform.position) > Range)
        {
            EnemyMove();
        }
        else if(RateTime <= RateCurTime)
        {
            RateCurTime = 0;
            GameObject Bullet = Instantiate(this.Bullet);
            //오브젝트 위치 이동
            Bullet.transform.localScale = Vector3.one; // 스케일 조절
            Bullet.transform.position = transform.position;
            Bullet.GetComponent<Rigidbody>().AddForce((Player.transform.position -transform.position ) * BulletSpeed, ForceMode.Impulse); // 총알 발사
        }
    }

    void EnemySet() // 적 기본 셋팅 awake나 start에서 실행
    {
        Hp = 25;
        RateAttack = RateTime;
        MoveSpeed = 0.6f;
    }

    void Target()
    {
        TargetPosition = Player.transform.position - this.transform.position;
        //TargetPosition.Normalize();
    }

    void EnemyMove()
    {
        this.transform.Find("Enemy_Sprite").Rotate(270 * Time.deltaTime, 0.0f, 100 * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(TargetPosition).normalized;

        Target();
        transform.position += TargetPosition * MoveSpeed * Time.deltaTime;
        this.GetComponent<Rigidbody>().velocity = TargetPosition * Time.deltaTime * MoveSpeed;
    }

    private void OnCollisionStay(Collision other)
    {
        //만약 원거리 적이 플레이어가 근처에 왔을때 때리지 않는다면 삭제

        if (other.gameObject.CompareTag("Player") && RateAttack <= 0)
        {
            RateAttack = RateTime;
            other.gameObject.GetComponent<PlayerContorller>().OnHit(10); // 플레이어 공격 
        }
    }

    void RateAttackDel()
    {
        if (RateAttack >= 0)
        {
            RateAttack -= Time.deltaTime;
        }
    }
}
