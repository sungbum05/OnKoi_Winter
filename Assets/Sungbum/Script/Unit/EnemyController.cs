using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Unit // ������ָ� unit�� �ִ� hp�� movespeed��밡��
{
    Bombing bombing;

    [SerializeField]
    GameObject Player;

    [SerializeField]
    UI_Manager uI_Manager;

    Vector3 TargetPosition;

    private float RateAttack;
    private float RateTime = 0.6f;

    private void OnDestroy()
    {
        Player.gameObject.GetComponent<PlayerContorller>().LevelUp();
        uI_Manager.AddScore(150 + PlusScore)/*+�� �־��ָ� �ɵ�*/;
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        uI_Manager = GameObject.Find("UiManager").GetComponent<UI_Manager>();
        SetItemSpawner();
        EnemySet();
    }

    // Update is called once per frame
    void Update()
    {
        RateAttackDel();

        if (Move == true)
        {
            EnemyMove();
        }
    }

    void EnemySet() // �� �⺻ ���� awake�� start���� ����
    {
        Hp = 35;
        RateAttack = RateTime;
        MoveSpeed = 6.0f;
    }

    void Target()
    {
        TargetPosition = Player.transform.position - this.transform.position;
        TargetPosition.Normalize();
    }

    void EnemyMove()
    {
        if (Player != null)
        {
            this.transform.FindChild("Enemy_Sprite").Rotate(360 * Time.deltaTime, 0.0f, 100 * Time.deltaTime);

            transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(TargetPosition), 2.5f * Time.deltaTime);
            Target();
        }

        transform.position += TargetPosition * MoveSpeed * Time.deltaTime;
        //Target();
        //transform.position += TargetPosition * MoveSpeed * Time.deltaTime;
        //this.GetComponent<Rigidbody>().velocity = TargetPosition * Time.deltaTime * MoveSpeed;
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Player") && RateAttack <= 0)
        {
            RateAttack = RateTime;
            other.gameObject.GetComponent<PlayerContorller>().OnHit(10); // �÷��̾� ����
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