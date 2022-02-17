using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Controller : Unit
{
    Bombing bombing;

    [SerializeField]
    GameObject Player;

    [SerializeField]
    GameObject EnemyExplosion;

    [SerializeField]
    GameObject Smoke;

    [SerializeField]
    UI_Manager uI_Manager;

    Vector3 TargetPosition;

    private float RateAttack;
    private float RateTime = 0.5f;

    bool Move = false;

    private void OnDestroy()
    {
        Player.gameObject.GetComponent<PlayerContorller>().LevelUp();
        uI_Manager.AddScore(150 + PlusScore)/*+값 넣어주면 될듯*/;

        Instantiate(EnemyExplosion, new Vector3(this.transform.position.x,
            this.transform.position.y, this.transform.position.z), Quaternion.identity);

        bombing.Missile();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartAnim");

        Player = GameObject.Find("Player");
        uI_Manager = GameObject.Find("UiManager").GetComponent<UI_Manager>();
        EnemySet();
    }

    // Update is called once per frame
    void Update()
    {
        if(Move == true)
        {
            EnemyMove();
        }
    }

    void EnemySet() // 적 기본 셋팅 awake나 start에서 실행
    {
        Hp = 100;
        RateAttack = RateTime;
        MoveSpeed = 4.0f;

        Smoke.SetActive(false);
    }

    void Target()
    {
        TargetPosition = Player.transform.position - this.transform.position;
        TargetPosition.Normalize();
    }

    void EnemyMove()
    {
        //this.transform.Find("Enemy_Sprite").Rotate(270 * Time.deltaTime, 0.0f, 100 * Time.deltaTime);
        if(Player != null)
        {
            //transform.rotation = Quaternion.LookRotation(TargetPosition);

            transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(TargetPosition), 2.5f * Time.deltaTime);
            Target();
        }

        transform.position += TargetPosition * MoveSpeed * Time.deltaTime;
        //this.GetComponent<Rigidbody>().velocity = TargetPosition * Time.deltaTime * MoveSpeed;
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine("StartBoom");
        }
    }

    IEnumerator StartBoom()
    {
        Player = null;
        MoveSpeed = 0;
        Hp = 99999;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        Smoke.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);

        Instantiate(EnemyExplosion, new Vector3(this.transform.position.x, 
            this.transform.position.y, this.transform.position.z), Quaternion.identity);

        Destroy(this.gameObject);
    }

    IEnumerator StartAnim()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        while(true)
        {
            yield return null;

            if(this.gameObject.transform.position.y <= 0.6f)
            {
                this.gameObject.transform.localPosition += new Vector3(0, 2f * Time.deltaTime, 0);

                if (this.gameObject.transform.position.y >= -1.0f && this.gameObject.transform.rotation.x <= 0)
                {
                    this.gameObject.transform.Rotate(55 * Time.deltaTime, 0, 0);
                }
            }

            else
            {
                break;
            }
        }

        yield return new WaitForSeconds(0.7f);

        this.gameObject.GetComponent<BoxCollider>().enabled = true;
        Move = true;
        StopCoroutine("StartAnim");

    }
}
