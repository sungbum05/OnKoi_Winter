using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nuclear : Item
{
 
    public  GameObject Nuclearoj;
    ItemSpawner itemSpawner;

   
    private Vector3 NuclearScale;
    float Scale = 0.1f;
    private Text Name;
    private Item item;
    private string name;

    new void Start()
    {
        Name = GetComponent<Text>();
        name = this.gameObject.name;
        Name.text = name;
        NuclearScale = Nuclearoj.transform.localScale;
    }

    new void Update()
    {
        base.Update();
        if (Itemuse == true)
        {
            NuclearItem();

            while(true)
            {
                NuclearScale = new Vector3(+Scale, +Scale, +Scale);
                if (Scale == 5)
                {
                    break;
                }
            }
        }
        Itemuse = false;
    }
    void NuclearItem()
    {
        Debug.Assert(Nuclearoj != null);
        Debug.Assert(itemSpawner != null);

        Instantiate(Nuclearoj, this.transform.position, Quaternion.identity);
    }
}
