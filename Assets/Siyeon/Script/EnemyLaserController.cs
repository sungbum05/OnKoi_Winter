using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserController : Unit
{
    [SerializeField]
    GameObject Player;

    [SerializeField]
    UI_Manager uI_Manager;

    Vector3 TargetPosition;

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
        RateCurTime += Time.deltaTime;

        if (Vector3.Distance(transform.position, Player.transform.position) > Range)
        {
            EnemyMove();
        }
        else if (RateTime <= RateCurTime)
        {
            RateCurTime = 0;
            /*GameObject Bullet = Instantiate(this.Bullet);
            //오브젝트 위치 이동
            Bullet.transform.localScale = Vector3.one; // 스케일 조절
            Bullet.transform.position = transform.position;
            Bullet.GetComponent<Rigidbody>().AddForce((Player.transform.position - transform.position) * BulletSpeed, ForceMode.Impulse); // 총알 발사*/

        }        
    }

    void EnemySet() // 적 기본 셋팅 awake나 start에서 실행
    {
        Hp = 25;
        RateAttack = RateTime;
        MoveSpeed = 1.0f;
    }

    void Target()
    {
        TargetPosition = Player.transform.position - this.transform.position;
        TargetPosition.Normalize();
    }

    void EnemyMove()
    {
        transform.rotation = Quaternion.LookRotation(TargetPosition).normalized;

        Target();
        transform.position += TargetPosition * MoveSpeed * Time.deltaTime;
        this.GetComponent<Rigidbody>().velocity = TargetPosition * Time.deltaTime * MoveSpeed;
    }
}
