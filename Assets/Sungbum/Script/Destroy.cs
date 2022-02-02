using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObj", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyObj()
    {
        Destroy(this.gameObject);
    }
}
