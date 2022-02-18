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
        int RanZ = 0, RanX = 0;

        GameObject Enemy = Instantiate(EnemyPrefab[Random.RandomRange(0, 3)]);

        Enemy.transform.position = new Vector3(transform.parent.position.x + ((RanX = Random.Range(0, 2) == 0 ? -1 : 1) * Random.Range(10.0f, 16.0f)), Enemy.transform.position.y, 
            this.transform.parent.position.z + ((RanZ = Random.Range(0, 2) == 0 ? -1 : 1) * Random.Range(10.0f, 16.0f)));

        yield return new WaitForSeconds(Random.Range(7.0f, 10.0f));
        StartCoroutine("EnemySpawn");
    }
}
