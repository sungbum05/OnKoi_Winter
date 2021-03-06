using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerContorller : Unit
{
    [SerializeField]
    private GameObject StatPan;

    [SerializeField]
    private ItemSpawner ItemSpawner;

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
        RotateToMouseDir();
        RefillShield();

        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("asd");

            CheatKey();

            //ItemSpawner.GetComponent<ItemSpawner>().ResultSelect(this);
        }
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    void SetState()
    {
        Hp = 100;
        Shield = 50;


        MaxShield = Shield;
        CurExp = 0;
        MaxExp = 20;

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

        //this.gameObject.transform.localPosition += new Vector3(XMove * Time.deltaTime * MoveSpeed, 0.0f, ZMove * Time.deltaTime * MoveSpeed);

        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(XMove, 0.0f, ZMove) * MoveSpeed;

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

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        Vector3 BackPosition = this.gameObject.transform.position - other.gameObject.transform.position;
    //        Debug.Log(BackPosition);

    //        this.gameObject.transform.localPosition += new Vector3(BackPosition.x * Time.deltaTime * MoveSpeed, 0.0f, BackPosition.z * Time.deltaTime * MoveSpeed);
    //    }
    //}

    //private void OnCollisionStay(Collision other)
    //{
    //    if(other.gameObject.tag == "Enemy")
    //    {
    //        Vector3 BackPosition = this.gameObject.transform.position - other.gameObject.transform.position;
    //        Debug.Log(BackPosition);

    //        this.gameObject.GetComponent<Rigidbody>().velocity += BackPosition;
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

    // ???? ????
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

    //?????? ???? ???? ???? ????
    public override void OnHit(float Damege)
    {
        base.OnHit(Damege);

        RefillTime = 2.0f;
    }

    void CheatKey()
    {
        Shield = 50000;
        MaxShield = 50000;
    }
}
