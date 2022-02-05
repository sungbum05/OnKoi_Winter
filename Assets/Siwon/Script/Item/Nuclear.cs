using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuclear : Item
{
    [SerializeField]
    private GameObject Nuclearoj;
    private ItemSpawner itemSpawner;

    Vector3 NuclearScale;
    float Scale = 0.1f;
    
    void Start()
    {
        
    }
    new void Update()
    {
        base.Update();
        if(Itemuse == true)
        {
            NuclearItem();
                NuclearScale = Nuclearoj.transform.localScale;
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
        Instantiate(Nuclearoj, itemSpawner.ItemPosition, Quaternion.identity);
    }
}
