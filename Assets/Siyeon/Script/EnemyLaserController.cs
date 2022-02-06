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

    Vector3 laserTargetPosition;
    float laserRotateLerpAmount;

    [SerializeField]
    LineRenderer lineRenderer;
    [SerializeField]
    Transform laserTransform;
    [SerializeField]
    float laserActivateTime;
    [SerializeField]
    float laserCooldownTime;

    [SerializeField]
    float distance = 1000;

    public GameObject Bullet;
    public float Range;


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
        ActivateTLS();
        DeactivateTLS();
    }

    // Update is called once per frame
    void Update()
    {
        RateAttackDel();
        if (lineRenderer.enabled == true)
        {
            RotateTLS();
        }
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

            Vector3 launchPosition = laserTransform.position;
            Vector3 directionVector = (Player.transform.position - launchPosition).normalized;
            lineRenderer.SetPosition(0, launchPosition);
            lineRenderer.SetPosition(1, launchPosition + directionVector * distance);

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
        this.transform.Find("Enemy_Sprite").Rotate(270 * Time.deltaTime, 0.0f, 100 * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(TargetPosition).normalized;

        Target();
        transform.position += TargetPosition * MoveSpeed * Time.deltaTime;
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

    void ActivateTLS()
    {
        lineRenderer.enabled = true;
        laserTargetPosition = laserTransform.position + laserTransform.right * distance;
        lineRenderer.SetPosition(1, laserTargetPosition);
        Invoke("DeactivateTLS", laserActivateTime);
    }

    void DeactivateTLS()
    {
        lineRenderer.enabled = false;
        Invoke("ActivateTLS", laserCooldownTime);
    }


    void RotateTLS()
    {
        if (Player == null) return;

        Vector3 launchPosition = laserTransform.position;

        laserTargetPosition = Vector3.Lerp(laserTargetPosition, Player.transform.position, laserRotateLerpAmount * Time.deltaTime);
        Vector3 directionVector = (laserTargetPosition - launchPosition).normalized;

        lineRenderer.SetPosition(0, launchPosition);
        lineRenderer.SetPosition(1, launchPosition + directionVector * distance);

        RaycastHit hit;
        Physics.Raycast(lineRenderer.GetPosition(0), directionVector, out hit, distance);

        float lineDistance = distance;

        if (hit.collider != null)
        {
            Debug.Log(hit.collider);
            lineDistance = hit.distance;

            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                //hit.collider.GetComponent<TargetObject>()?.OnDamage(damage, gameObject.layer);
                Debug.Log("lklklk");
            }
        }

        lineRenderer.SetPosition(0, launchPosition);
        lineRenderer.SetPosition(1, launchPosition + directionVector * lineDistance);
    }

}
