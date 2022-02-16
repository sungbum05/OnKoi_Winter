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

    void BarigateSet() // 적 기본 셋팅 awake나 start에서 실행
    {
        Hp = 70;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
