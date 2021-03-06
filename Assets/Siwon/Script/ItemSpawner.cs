using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSpawner : MonoBehaviour
{

    public List<ItemList> ItemMenu = new List<ItemList>();
    public int total = 0;
    public List<ItemList> result = new List<ItemList>();
    public void ResultSelect(Transform ItemOffset)
    {
        result.Add(RandomItem());
        if (result[0].itemObject != null)
        {
            Instantiate(result[0].itemObject, new Vector3(ItemOffset.transform.position.x, 0.0f, ItemOffset.transform.position.z), Quaternion.identity);
            result.Clear();
        }
    }
    public ItemList RandomItem()
    {
        int weight = 0;
        int selectNum = 0;
        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));

        for (int i = 0; i < 12; i++)
        {
            Debug.Log(selectNum);
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ResultSelect(this.transform);
        }
    }
}