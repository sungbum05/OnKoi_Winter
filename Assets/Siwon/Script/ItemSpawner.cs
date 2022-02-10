using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> ItemMenu = new List<GameObject>();

    
    private SpawnItem spawnItem;
    
    



    void Start()
    {
        
        SpawnItem();
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        SpawnItem();
    }
    public void SpawnItem()
    {

        //Debug.Assert(spawnItem.SpawnItem1(spawn) == null);
        //spawnItem.SpawnItem1(spawn);
        
        GameObject a = Instantiate(ItemMenu[Random.Range(0, ItemMenu.Count)], GetComponent<Item>().ItemPos(), Quaternion.identity);
        //item.GetComponent<Item>().GetTranform(ItemPosition);
        StartCoroutine(Wait());

    }
    
}
public class SpawnItem
{
    public float Radius1;
    public Vector3 ItemPosition1;
    public Vector3 ItemSpawnerPositon = GameObject.Find("ItemSpawner").transform.position;
    
    
    public Vector3 SpawnItem1(Vector3 spawn)
    {
        
        ItemPosition1 = new Vector3(spawn.x, 0.1f, spawn.z) + ItemSpawnerPositon;
        return ItemPosition1;
    }
   
  
}
