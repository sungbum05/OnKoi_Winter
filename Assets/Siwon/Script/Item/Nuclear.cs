using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuclear : Item
{
    [SerializeField]
    private GameObject Nuclearoj;
    private ItemSpawner itemSpawner;

    private Vector3 NuclearScale;
    float Scale = 0.1f;
    
    void Start()
    {
        NuclearScale = Nuclearoj.transform.localScale;
        
    }
    
    void Update()
    {
        base.Update();
        if(Itemuse == true)
        {
            NuclearItem();
                
            while (true)
            {
                if(Scale == 5)
                {
                    NuclearScale = new Vector3(+Scale, +Scale, +Scale);

                }
            }
        }
        Itemuse = false;
    }
    void NuclearItem()
    {
        GameObject a = Instantiate(Nuclearoj, itemSpawner.ItemPosition, Quaternion.identity);
    }
}
