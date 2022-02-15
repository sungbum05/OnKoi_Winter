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
        float Scale = Random.Range(1.0f, 2.0f);
        int RanZ = 0, RanX = 0;

        GameObject Enemy = Instantiate(EnemyPrefab[Random.RandomRange(0, EnemyPrefab.Count)]);

        Enemy.transform.localScale = new Vector3(Scale, Scale, Scale);

        Enemy.transform.position = this.transform.position;

        Enemy.transform.DOMove(new Vector3(this.transform.forward.x * 2.0f, 1.5f, this.transform.forward.z * 2.0f), Random.Range(2.5f, 3.1f));

        Enemy.GetComponent<Unit>().Move = true;

        yield return new WaitForSeconds(Random.Range(2.0f, 3.1f));
        StartCoroutine("EnemySpawn");
    }
}
