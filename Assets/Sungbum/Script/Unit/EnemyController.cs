using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        this.transform.Rotate(30 * Time.deltaTime, 0.0f, 10 * Time.deltaTime);
    }
}
