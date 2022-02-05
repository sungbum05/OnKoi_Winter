using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : SetGun
{

    public Transform target;
    //터렛이 쳐다보게될 타겟
    public float range = 15f;
    //터렛이 적을 인식할 수 있는 범위
    public string enemyTag = "Enemy";
    //터렛이 인식할 적의 태그
    public Transform partToRotate;
    //터렛이 중심으로 회전할 회전축
    public float turnSpeed = 10f;
    //터렛의 회전할때 속도

    float LifeTime = 30.0f;
    public Transform[] ShootPosition;

    int ShotPosNext = 0;

    void Start()
    {
        base.SettingGun();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        //UpdateTarget함수를 딜레이 없이, 0.5초 마다 호출 무한 반복
    }

    // Update is called once per frame
    void Update()
    {
        EndLife();

        if (target == null)
        {
            partToRotate.transform.Rotate(0, 90 * Time.deltaTime, 0);
        }

        else
        {
            TurretRotate();
            TurretFire();
        }

        Debug.Log(ShotPosNext);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; //범위 만큼 선그어주기. 빨간색으로다가
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void TurretRotate()
    {
        Vector3 dir = target.position - transform.position; //타겟과 터렛의 위치를 뺀 값을 dir로 갖고
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);  //회전 하는 건데 따로설명
    }

    void TurretFire()
    {
        base.RateAttackDel();

        if (RateFire <= 0.0f)
        {
            //SoundMgr.In.PlaySound("1");
            RateFire = 0.1f;

            RaycastHit hitInfo;

            GameObject Bullet = Instantiate(AmmoType);
            Bullet.transform.parent = BulletZip.transform; //오브젝트 위치 이동
            Bullet.transform.localScale = new Vector3(1, 1, 1); // 스케일 조절
            Bullet.transform.position = new Vector3(this.ShootPosition[ShotPosNext].position.x, // 생성위치 이동
            this.ShootPosition[ShotPosNext].position.y, this.ShootPosition[ShotPosNext].position.z);

            Vector3 RandomRay = new Vector3(Random.RandomRange(-BulletSpread, BulletSpread + 0.1f), 0, Random.RandomRange(-BulletSpread, BulletSpread + 0.1f));

            Bullet.GetComponent<Rigidbody>().AddForce((this.ShootPosition[ShotPosNext].forward + RandomRay) * BulletSpeed, ForceMode.Impulse);
            Debug.DrawRay(ShootPosition[ShotPosNext].transform.position, (this.ShootPosition[ShotPosNext].forward + RandomRay) * 30.0f, Color.red, 0.5f);

            Destroy(Bullet, Random.Range(0.15f, 0.24f));//총알 삭제

            if (Physics.Raycast(ShootPosition[ShotPosNext].transform.position, this.ShootPosition[ShotPosNext].forward + RandomRay, out hitInfo, 30.0f))
            {
                if (hitInfo.transform.gameObject.tag == "Enemy")
                {
                    switch (GetEnemyType(hitInfo))
                    {
                        case 1:
                            hitInfo.transform.gameObject.GetComponent<EnemyController>().OnHit(Damege);
                            break;

                        case 2:
                            hitInfo.transform.gameObject.GetComponent<Enemy2Controller>().OnHit(Damege);
                            break;

                            //case 3:
                            //    hitInfo.transform.gameObject.GetComponent<Enemy2Controller>().OnHit(Damege);
                            //    break;
                    }

                    GameObject Particle = Instantiate(GunParticle);
                    Particle.transform.position = hitInfo.transform.position;
                    Destroy(Bullet, Random.Range(0.07f, 0.11f));
                }
            }

            if (ShotPosNext >= 1)
            {
                ShotPosNext = 0;
                return;
            }

            else
                ShotPosNext ++;
        }
    }

    void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); //Enemy라는 태그를 갖은 것들을 enemies[]배열에 저장
        float shortestDistance = Mathf.Infinity; //가장 짧은 거리를 무한으로 둔다.
        GameObject nearestEnemy = null; //가장 가까운 적을 null 로 둔다

        foreach (GameObject enemy in enemies) //enemy가 enemies의 수만큼 반복
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); //터렛과 enemy의 거리
            if (distanceToEnemy < shortestDistance) //터렛과 enemy의 거리가 가장 짧은 거리보다 작으면 
            {
                shortestDistance = distanceToEnemy; //가장 짧은 거리는 터렛과enemy 거리가 되고
                nearestEnemy = enemy; //가장 가까운 적은 enemy가됨
            }

        }
        if (nearestEnemy != null && shortestDistance <= range) //만약 가까운 적이 없고, 가장 짧은 거리가 터렛의 범위보다 짧으면
        {
            target = nearestEnemy.transform; //타겟은 다시한번 가장 가까운 놈으로바뀜
        }
        else
        {
            target = null; //아니면 타겟은 없는겨
        }
    }

    void EndLife()
    {
        LifeTime -= Time.deltaTime;

        if (LifeTime <= 0)
            Destroy(this.gameObject);
    }
}
