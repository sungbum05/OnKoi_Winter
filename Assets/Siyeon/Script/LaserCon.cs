using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCon : Unit
{
    [SerializeField]
    GameObject Player;

    [SerializeField]
    GameObject ShootPos;

    private LineRenderer lr;

    RaycastHit hit;
    public float MaxDistance = 15f;
    public LayerMask LayerMask;

    public Vector3 startp;
    public Vector3 endp;

    public float Range;
    public float speed;
    private float RateTime = 2f;
    private float RateCurTime = 0;

    public bool islerp;
    public bool rot;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startp = new Vector3(ShootPos.transform.localPosition.x, 9.5f ,ShootPos.transform.localPosition.z);

        Player = GameObject.Find("Player");
        lr.SetPosition(0, startp);
        rot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (rot)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Player.transform.position - transform.position), Time.deltaTime * 3);

        lr.SetPosition(1, endp);
        RateCurTime += Time.deltaTime;
        if (rot)
            lr.enabled = false;
        else
            lr.enabled = true;


        if (Input.GetKeyDown(KeyCode.K))
        {
            Laser();
        }

        if (Vector3.Distance(transform.position, Player.transform.position) > Range)
        {

        }
        else if (RateTime <= RateCurTime)
        {
            RateCurTime = 0;
            Laser();
            if(Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance, LayerMask))
            {
                Debug.Log("hit");
                hit.transform.gameObject.GetComponent<PlayerContorller>().OnHit(30);
            }
        }

    }

    void Laser()
    {
        StopAllCoroutines();
        StartCoroutine(EndP());
    }

    IEnumerator EndP()
    {
        endp = Vector3.zero;
        rot = false;
        var end = Vector3.forward * Range;
        print(end);
        var wait = new WaitForSeconds(0.001f);
        while (Vector3.Distance(end, endp) > 0.01f)
        {
            if (islerp)
                endp = Vector3.Lerp(endp, end, Time.deltaTime * speed);
            else
                endp = Vector3.MoveTowards(endp, end, speed);
            yield return wait;
        }
        rot = true;
        yield return null;
    }
}
