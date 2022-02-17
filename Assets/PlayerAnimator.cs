using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] 
    Animator PlayerAnim;

    [SerializeField]
    PlayerContorller PlayerCon;

    [SerializeField]
    private List<GameObject> KindsGun = new List<GameObject>();

    [SerializeField]
    List<AnimatorOverrideController> PlayerGunAnim;

    //[SerializeField]
    //private List<Animator> Animators = new List<Animator>();

    [SerializeField]
    GameObject KindGun;
    [SerializeField]
    GameObject CurGun;

    int GunCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetGunKinds();
        PlayerAnim = this.GetComponent<Animator>();

        PlayerAnim.runtimeAnimatorController = PlayerGunAnim[2];
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveChk();
        GetCurGunInfo();
    }

    void PlayerMoveChk()
    {
        float XMove = Input.GetAxis("Horizontal");
        float ZMove = Input.GetAxis("Vertical");

        if(ZMove != 0 || XMove != 0)
        {
            PlayerAnim.SetBool("Run", true);
            PlayerAnim.SetBool("Idle", false);
        }

        else
        {
            PlayerAnim.SetBool("Run", false);
            PlayerAnim.SetBool("Idle", true);
        }
    }

    void SetGunKinds()
    {
        for (int i = 0; i < KindGun.transform.childCount; i++)
        {
            KindsGun.Add(KindGun.transform.GetChild(i).gameObject);
        }
    }

    public void GetCurGunInfo()
    {
        foreach (GameObject GunObj in KindsGun)
        {
            GunCount++;

            if (GunObj.active)
            {
                CurGun = GunObj;

                PlayerAnim.runtimeAnimatorController = PlayerGunAnim[GunCount - 1];
            }
        }

        GunCount = 0;
    }
}
