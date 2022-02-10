using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Explosion : MonoBehaviour
{
    private Renderer ExplosionRender;

    [SerializeField]
    private int ExplosionScale = 10;

    [SerializeField]
    private float ExplosionSpeed = 1.0f;

    [SerializeField]
    private float ExplosionDesTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        ExplosionRender = this.GetComponent<Renderer>();

        StartCoroutine("StartExplosion");
    }

    // Update is called once per frame
    void Update()
    {

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
                Debug.Log(Cur_FresnelEffect);

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
}
