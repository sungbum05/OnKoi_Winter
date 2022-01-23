using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("EnemySpawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawn()
    {
        float Scale = Random.Range(0.8f, 2.0f);

        GameObject Enemy = Instantiate(EnemyPrefab[0]);

        Enemy.transform.DOScale(new Vector3(Scale, Scale, Scale), Random.Range(0.6f, 1.0f));

        Enemy.transform.position = new Vector3(this.transform.position.x + (Random.Range(-1, 1) * Random.Range(7.0f, 11.0f)), this.transform.position.y, 
            this.transform.position.z + (Random.Range(-1, 1) * Random.Range(7.0f, 11.0f)));

        yield return new WaitForSeconds(Random.Range(0.8f, 1.3f));
        StartCoroutine("EnemySpawn");
    }
}
