using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Explosion : MonoBehaviour
{
    private Renderer ExplosionRender;

    public int ExplosionScale = 10;

    [SerializeField]
    private float ExplosionSpeed = 1.0f;

    [SerializeField]
    private float ExplosionDesTime = 1.5f;

    [SerializeField]
    private string[] EnemyType;

    // Start is called before the first frame update
    void Start()
    {
        ExplosionRender = this.GetComponent<Renderer>();

        StartCoroutine("StartExplosion");
    }

    IEnumerator StartExplosion()
    {
        transform.DOScale(new Vector3(ExplosionScale, ExplosionScale, ExplosionScale), ExplosionSpeed);

        while(true)
        {
            float Cur_FresnelEffect = ExplosionRender.material.GetFloat("_FresnelEffect");

            yield return null;


            if(this.gameObject.transform.localScale.x >= ExplosionScale - 0.5f)
            {
                ExplosionRender.material.SetFloat("_FresnelEffect", Cur_FresnelEffect += (Time.deltaTime * ExplosionDesTime));

                if(Cur_FresnelEffect > 0.0f)
                {
                    this.GetComponent<SphereCollider>().enabled = false;
                }

                if (Cur_FresnelEffect > 2.0f)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private int GetEnemyType(GameObject gameObject)
    {
        int SecondIdx = 1;

        EnemyType = gameObject.transform.gameObject.name.Split('_');

        return int.Parse(EnemyType[SecondIdx]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "Enemy" && other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerContorller>().OnHit(50);
        }

        else if (this.gameObject.tag == "Player" && other.gameObject.tag == "Enemy")
        {
            other.transform.gameObject.GetComponent<Unit>().OnHit(9999);
        }
    }
}
