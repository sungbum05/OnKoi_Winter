using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ItemSpawner : MonoBehaviour
{
    
    public List<ItemList> ItemMenu = new List<ItemList>();
    public int total = 0;
    public List<ItemList> result = new List<ItemList>();

    public void ResultSelect()
    {
        result.Add(RandomItem());
        StartCoroutine(SpawnIt());
    }
    public ItemList RandomItem()
    {
        int weight = 0;
        int selectNum = 0;
        selectNum = Mathf.RoundToInt(total * Random.Range(0f, 100f));

        for (int i = 0; i < 12; i++)
        {
            weight += ItemMenu[i].weight;
            if (selectNum <= weight)
            {
                ItemList temp = new ItemList(ItemMenu[i]);
                return temp;
            }
        }
        return null;
    }
    void Start()
    {
        for (int i = 0; i < ItemMenu.Count; i++)
        {
            total += ItemMenu[i].weight;
        }
        StartCoroutine(SpawnIt());
    }
    IEnumerator SpawnIt()
    {
        yield return new WaitForSeconds(1f);
        RandomItem();
    }
}
