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
    }
    public ItemList RandomItem()
    {
        int weight = 0;
        int selectNum = 0;
        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));

        for (int i = 0; i < 1; i++)
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
    }


}
