using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerContorller : Unit
{
    [SerializeField]
    private GameObject StatPan;

    float RefillTime = 2.0f;
    public float MaxShield { get; set; }
    float ChargeShield = 0.2f;

    // Start is called before the first frame update
    private void OnDestroy()
    {
        SceneManager.LoadScene(2);
    }

    private void Awake()
    {
        SetState();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        RotateToMouseDir();
        RefillShield();
    }

    void SetState()
    {
        Hp = 10000;
        Shield = 50;


        MaxShield = Shield;
        CurExp = 0;
        MaxExp = 100;

        MoveSpeed = 7;

        StartCoroutine("RefillShield");
    }

    public void SetLevelState()
    {
        Shield = MaxShield;
    }

    void PlayerMove()
    {
        float XMove = Input.GetAxis("Horizontal");
        float ZMove = Input.GetAxis("Vertical");

        this.gameObject.transform.localPosition += new Vector3(XMove * Time.deltaTime * MoveSpeed, 0.0f, ZMove * Time.deltaTime * MoveSpeed);

        //this.gameObject.transform.Translate(XMove * Time.deltaTime * MoveSpeed, 0, 
        //    ZMove * Time.deltaTime * MoveSpeed);
    }

    void RotateToMouseDir()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (GroupPlane.Raycast(cameraRay, out rayLength))
        {

            Vector3 pointTolook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if(other.gameObject.CompareTag("Ride"))
    //    {
    //        Ride();
    //    }
    //}

    //void Ride()
    //{
    //    if(Input.GetKeyDown(KeyCode.F))
    //    {

    //    }
    //}

    public void LevelUp()
    {
        CurExp++;

        if (MaxExp <= CurExp)
        {
            StatPan.SetActive(true);
            CurExp = 0;
            MaxExp += 10;
        }
    }

    // 실드 관련
    IEnumerator RefillShield()
    {
        while (true)
        {
            yield return null;

            if (Shield < 0)
            {
                Shield = 0;
            }

            if (Shield < MaxShield && RefillTime <= 0.0f)
            {
                yield return new WaitForSeconds(0.05f);
                StartCoroutine("PlusShield");
            }

            else
            {
                Shield = Mathf.Floor(Shield);
                StopCoroutine("PlusShield");
            }

            DelRefillTime();
        }
    }

    private void DelRefillTime()
    {
        if (RefillTime >= 0.0f)
            RefillTime -= Time.deltaTime * 1.0f;
    }

    IEnumerator PlusShield()
    {
        Shield += ChargeShield;
        yield return null;
    }

    //재정의 함수 쉴드 관련 추가
    public override void OnHit(float Damege)
    {
        base.OnHit(Damege);

        RefillTime = 2.0f;
    }
}
