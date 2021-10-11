using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyAnimationsHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private Animator animator = null;
    #endregion

    #region MonoBehaviour Functions
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
                break;
            case BabyState.Crying:
                animator.SetBool("b_Cry", true);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                break;
            case BabyState.Angry:
                animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", true);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                break;
            case BabyState.Happy:
                animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", true);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                break;
            case BabyState.Laughing:
                animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", true);
                animator.SetBool("b_Clap", false);
                break;
            case BabyState.Clap:
                animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", true);
                break;
        }
    }
    #endregion
}
