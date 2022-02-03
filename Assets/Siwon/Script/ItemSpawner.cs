using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Item
{
    [SerializeField]
    public List<GameObject> ItemMenu = new List<GameObject>();

    public float Radius = 5;

    void Start()
    {
        SpawnItem();
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f);
        SpawnItem();
    }
    void SpawnItem()
    {
        this.transform.position = new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z);
        Instantiate(ItemMenu[Random.Range(0, ItemMenu.Count)], this.transform.position * Radius, Quaternion.identity);
        StartCoroutine(Wait());
        
    }
}
