using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombing : Item
{
    public float Radius;
    protected Vector3 Mpos;
    Vector3 Strike;
    public bool BoomCheck;
    public GameObject mBoom;
    Transform transform;
    
   
    void Start()
    {
        transform = GetComponent<Transform>();
        Vector3 StrikePos = transform.position;
        Missile();
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            Missile();
        }
    }

    public void Missile()
    {
            StartCoroutine(MissileDel());
    }
    
    
    IEnumerator MissileDel()
    {
        for (int i = 0; i < 8; i++)
        {
            Strike = new Vector3(this.transform.position.x, this.transform.position.y + 10f, this.transform.position.z);
            Instantiate(mBoom, Strike, Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(0.15f);
        }
        yield return null;
    }
}
