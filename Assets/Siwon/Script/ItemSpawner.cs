using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> ItemMenu = new List<GameObject>();

    public float Radius = 30;
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
        Vector3 Spawn = Random.insideUnitSphere * Radius;
        ItemPosition = new Vector3(Spawn.x, 0.1f, Spawn.z) + transform.position;
        GameObject a = Instantiate(ItemMenu[Random.Range(0, ItemMenu.Count)], ItemPosition, Quaternion.identity);
        StartCoroutine(Wait());
        
    }
}
