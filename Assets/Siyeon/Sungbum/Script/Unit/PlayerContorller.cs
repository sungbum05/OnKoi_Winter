using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerContorller : Unit
{
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
    }

    void SetState()
    {
        Hp = 150;
        Shield = 100;

        CurExp = 0;
        MaxExp = 100;

        MoveSpeed = 7;
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

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Ride"))
        {
            Ride();
        }
    }

    void Ride()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {

        }
    }

    public void LevelUp()
    {
        CurExp++;

        if (MaxExp <= CurExp)
        {
            CurExp = 0;
            MaxExp += 50;
        }
    }
}
