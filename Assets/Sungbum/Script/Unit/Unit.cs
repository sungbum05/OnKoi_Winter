using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float MoveSpeed { get; set; }

    public float Hp { get; set; }
    public float Shield { get; set; }

    public float CurExp { get; set; }
    public float MaxExp { get; set; }

    public int PlusScore = 0;

    public bool Move = false;

    [SerializeField]
    protected ItemSpawner ItemSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void SetItemSpawner()
    {
        ItemSpawner = GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>();
    }

    public virtual void OnHit(float Damege)
    {
        if(Shield > 0)
        {
            Shield -= Damege;
        }

        else if(Shield <= 0)
        {
            Hp -= Damege;
        }

        if(Hp <= 0)
        {
            Destroy(this.gameObject);
            ItemSpawner.ResultSelect(this.gameObject.transform);
        }
    }
}
