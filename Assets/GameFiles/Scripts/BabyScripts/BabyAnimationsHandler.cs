using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyAnimationsHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private Animator animator = null;
    [SerializeField] private GameObject pukeVfx;
    [SerializeField] private GameObject cryVFX;
    [SerializeField] private GameObject steamVFX;

    private List<GameObject> vfx = new List<GameObject>();


    #endregion

    #region MonoBehaviour Functions

    private void Start()
    {
        vfx.Add(pukeVfx);
        vfx.Add(cryVFX);
      //  vfx.Add(steamVFX) ;


    }
    #endregion

    #region Public Core Functions
    public void SwitchBabyAnimations(BabyState state)
    {
        switch (state)
        {
            case BabyState.Idle:
                animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", false);
                break;
            case BabyState.Crying:
                animator.SetBool("b_Cry", true);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", false);
                ClearVFX();
                cryVFX.SetActive(true);
                // steamVFX.SetActive(false);
                break;
            case BabyState.Angry:
                animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", true);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", false);
                break;
            case BabyState.Happy:
                animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", true);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", false);
                ClearVFX();

                break;
            case BabyState.Laughing:
                animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", true);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", false);
                ClearVFX();
                break;
            case BabyState.Clap:
                animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", true);
                animator.SetBool("b_Walk", false);
                break;
            case BabyState.Walk:
                animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", true);
                break;

                
            case BabyState.Puking:
                animator.SetBool("b_Cry", true);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", false);
                ClearVFX();
                pukeVfx.SetActive(true);
                break;

            case BabyState.HotFace:
                animator.SetBool("b_Cry", true);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", false);
                ClearVFX();
                //steamVFX.SetActive(true);
                BabySingleton.Instance.GetBabyRendererHandler.SwitchColor(BabyFaceColor.Red);
                break;
        }
    }

    void ClearVFX()
    {
        foreach(GameObject g in vfx)
        {
            g.SetActive(false);
        }
    }
    #endregion
}
