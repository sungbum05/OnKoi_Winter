using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyPotarl : Unit
{
    [SerializeField]
    List<GameObject> EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        EnemySet();

        StartCoroutine("StartAnim");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemySet() // 적 기본 셋팅 awake나 start에서 실행
    {
        Hp = 40;
    }

    IEnumerator StartAnim()
    {
        this.GetComponent<BoxCollider>().enabled = false;

        while(true)
        {
            yield return null;

            if(this.transform.position.y <= 3.0f)
            {
                this.gameObject.transform.Translate(0, 5 * Time.deltaTime, 0);
            }

            else
            {
                break;
            }
        }

        yield return new WaitForSeconds(0.7f);

        this.GetComponent<BoxCollider>().enabled = true;
        StartCoroutine("EnemySpawn");
    }

    IEnumerator EnemySpawn()
    {
        float Scale = Random.Range(2.5f, 3.1f);
        int RanZ = 0, RanX = 0;

        GameObject Enemy = Instantiate(EnemyPrefab[Random.RandomRange(0, 2)]);

        Enemy.transform.localScale = new Vector3(Scale, Scale, Scale);

        Enemy.transform.position = new Vector3(this.transform.position.x, Enemy.transform.position.y, this.transform.position.z);

        yield return new WaitForSeconds(1.5f);
        Enemy.GetComponent<Unit>().Move = true;

        yield return new WaitForSeconds(Random.Range(2.0f, 3.1f));
        StartCoroutine("EnemySpawn");
    }
}
