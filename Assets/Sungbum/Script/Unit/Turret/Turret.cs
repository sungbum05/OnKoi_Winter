using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : SetGun
{

    public Transform target;
    //�ͷ��� �Ĵٺ��Ե� Ÿ��
    public float range = 15f;
    //�ͷ��� ���� �ν��� �� �ִ� ����
    public string enemyTag = "Enemy";
    //�ͷ��� �ν��� ���� �±�
    public Transform partToRotate;
    //�ͷ��� �߽����� ȸ���� ȸ����
    public float turnSpeed = 10f;
    //�ͷ��� ȸ���Ҷ� �ӵ�

    float LifeTime = 30.0f;
    public Transform[] ShootPosition;

    int ShotPosNext = 0;

    void Start()
    {
        base.SettingGun();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        //UpdateTarget�Լ��� ������ ����, 0.5�� ���� ȣ�� ���� �ݺ�
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
        Gizmos.color = Color.red; //���� ��ŭ ���׾��ֱ�. ���������δٰ�
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void TurretRotate()
    {
        Vector3 dir = target.position - transform.position; //Ÿ�ٰ� �ͷ��� ��ġ�� �� ���� dir�� ����
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);  //ȸ�� �ϴ� �ǵ� ���μ���
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
            Bullet.transform.parent = BulletZip.transform; //������Ʈ ��ġ �̵�
            Bullet.transform.localScale = new Vector3(1, 1, 1); // ������ ����
            Bullet.transform.position = new Vector3(this.ShootPosition[ShotPosNext].position.x, // ������ġ �̵�
            this.ShootPosition[ShotPosNext].position.y, this.ShootPosition[ShotPosNext].position.z);

            Vector3 RandomRay = new Vector3(Random.RandomRange(-BulletSpread, BulletSpread + 0.1f), 0, Random.RandomRange(-BulletSpread, BulletSpread + 0.1f));

            Bullet.GetComponent<Rigidbody>().AddForce((this.ShootPosition[ShotPosNext].forward + RandomRay) * BulletSpeed, ForceMode.Impulse);
            Debug.DrawRay(ShootPosition[ShotPosNext].transform.position, (this.ShootPosition[ShotPosNext].forward + RandomRay) * 30.0f, Color.red, 0.5f);

            Destroy(Bullet, Random.Range(0.15f, 0.24f));//�Ѿ� ����

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

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); //Enemy��� �±׸� ���� �͵��� enemies[]�迭�� ����
        float shortestDistance = Mathf.Infinity; //���� ª�� �Ÿ��� �������� �д�.
        GameObject nearestEnemy = null; //���� ����� ���� null �� �д�

        foreach (GameObject enemy in enemies) //enemy�� enemies�� ����ŭ �ݺ�
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); //�ͷ��� enemy�� �Ÿ�
            if (distanceToEnemy < shortestDistance) //�ͷ��� enemy�� �Ÿ��� ���� ª�� �Ÿ����� ������ 
            {
                shortestDistance = distanceToEnemy; //���� ª�� �Ÿ��� �ͷ���enemy �Ÿ��� �ǰ�
                nearestEnemy = enemy; //���� ����� ���� enemy����
            }

        }
        if (nearestEnemy != null && shortestDistance <= range) //���� ����� ���� ����, ���� ª�� �Ÿ��� �ͷ��� �������� ª����
        {
            target = nearestEnemy.transform; //Ÿ���� �ٽ��ѹ� ���� ����� �����ιٲ�
        }
        else
        {
            target = null; //�ƴϸ� Ÿ���� ���°�
        }
    }

    void EndLife()
    {
        LifeTime -= Time.deltaTime;

        if (LifeTime <= 0)
            Destroy(this.gameObject);
    }
}
