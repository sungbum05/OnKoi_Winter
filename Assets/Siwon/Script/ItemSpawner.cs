using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> ItemMenu = new List<GameObject>();

    public float Radius = 5;
    public Vector3 ItemPosition;
    void Start()
    {
        SpawnItem();
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        SpawnItem();
    }
    void SpawnItem()
    {
        this.transform.position = new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z);
        ItemPosition = this.transform.position;
        Instantiate(ItemMenu[Random.Range(0, ItemMenu.Count)], ItemPosition * Radius, Quaternion.identity);
        StartCoroutine(Wait());
        
    }
}
