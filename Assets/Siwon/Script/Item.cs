using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public abstract class Item : MonoBehaviour
{
    public bool HitPlayer = false;
    public bool Itemuse = false;
    private Camera cam;
    public Vector3 ItemPosition;
    public float Radius = 30;
    public Camera Cam
    {
        get
        {
            if (cam == null)
            {
                cam = Camera.main;
            }
            return cam;
        }
    }

    [SerializeField]
    protected Text Itemname;
    private Text Key;
    Vector3 endPos;
    public enum ItemType
    {
        Gun,
        Item
    }
    public Vector3 ItemPos()
    {
        Vector3 spawn = Random.insideUnitSphere * Radius;
        ItemPosition = new Vector3(spawn.x, 0.1f, spawn.z) + transform.position;
        return ItemPosition;
    }
    public void GetTranform(Vector3 pos)
    {
        endPos = pos;
        StartCoroutine(Temp(1f));
    }

    IEnumerator Temp(float speed)
    {
        while (Vector3.Distance(transform.position, endPos) < 0.1f)
        {

            yield return null;
        }
        transform.position = endPos;

    }

    protected virtual void Start()
    {
        Itemname.text = GetComponent<Item>().name;

    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            HitPlayer = true;
        }
    }

    protected virtual void Update()
    {
        
        if (HitPlayer == true && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(this.gameObject);
            Itemuse = true;
        }
    }
}
