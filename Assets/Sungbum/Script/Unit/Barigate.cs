using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barigate : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        BarigateSet();
    }

    void BarigateSet() // �� �⺻ ���� awake�� start���� ����
    {
        Hp = 70;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
