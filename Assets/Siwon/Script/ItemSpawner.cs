using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject player;

    public List<GameObject> ItemMenu = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        Vector3 playerPos;
        playerPos = player.transform.position;
    }
     
    // Update is called once per frame
    void Update()
    {
        SpawnItem();
    }
    void SpawnItem()
    {
        Instantiate(Player,)
    }


}
