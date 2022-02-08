using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nuclear : Item
{

    public GameObject Nuclearoj;
    ItemSpawner itemSpawner;
    SphereCollider NuclearojCollider;

    private Vector3 NuclearScale;
    float Scale = 0.1f;
    public Text Name;
    private Item item;




    [SerializeField]
    private string[] Objname;

    new void Start()
    {
        NuclearojCollider = Nuclearoj.GetComponent<SphereCollider>();
        int firstIdx = 0;

        Objname = this.gameObject.name.Split('_');
        Name.text = Objname[firstIdx];
        NuclearScale = Nuclearoj.transform.localScale;
    }

    new void Update()
    {
        Name.transform.forward = Cam.transform.forward; //y = 0.5 // -13, -29
        base.Update();
        if (Itemuse == true)
        {
            NuclearItem();
            while (true)
            {
                Scale += 0.1f;
                NuclearScale = new Vector3(Scale, Scale, Scale);
                NuclearojCollider.radius = Scale;
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
