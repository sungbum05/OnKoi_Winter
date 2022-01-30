using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Item
{
    public GameObject player;
    [SerializeField]
    public List<GameObject> ItemMenu = new List<GameObject>();
    Vector3 playerPos;
    public float Radius = 5;
    // Start is called before the first frame update
    void Start()
    {

        playerPos = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        SpawnItem();
    }
    void SpawnItem()
    {
        Instantiate(ItemMenu[Random.Range(0, ItemMenu.Count)], Random.insideUnitSphere * Radius, Quaternion.identity);
        Invoke("SpawnItem", 10f);
    }
}
