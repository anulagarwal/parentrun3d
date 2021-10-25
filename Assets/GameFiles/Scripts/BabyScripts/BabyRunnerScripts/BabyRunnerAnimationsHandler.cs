using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRunnerAnimationsHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private Animator babyRunnerAnimator = null;
    #endregion

    #region Public Core Functions
    public void SwitchBabyRunnerAnimation(BabyRunnerAnimationsState state)
    {
        switch (state)
        {
            case BabyRunnerAnimationsState.Idle:
                babyRunnerAnimator.SetBool("b_Run", false);
                babyRunnerAnimator.SetBool("b_Climb", false);
                babyRunnerAnimator.SetBool("b_Sit", false);
                babyRunnerAnimator.SetBool("b_Slide", false);
                babyRunnerAnimator.SetBool("b_Knockdown", false);
                break;
            case BabyRunnerAnimationsState.Run:
                babyRunnerAnimator.SetBool("b_Run", true);
                babyRunnerAnimator.SetBool("b_Climb", false);
                babyRunnerAnimator.SetBool("b_Sit", false);
                babyRunnerAnimator.SetBool("b_Slide", false);
                babyRunnerAnimator.SetBool("b_Knockdown", false);
                break;
            case BabyRunnerAnimationsState.Sit:
                babyRunnerAnimator.SetBool("b_Run", false);
                babyRunnerAnimator.SetBool("b_Climb", false);
                babyRunnerAnimator.SetBool("b_Sit", true);
                babyRunnerAnimator.SetBool("b_Slide", false);
                babyRunnerAnimator.SetBool("b_Knockdown", false);
                break;
            case BabyRunnerAnimationsState.Slide:
                babyRunnerAnimator.SetBool("b_Run", false);
                babyRunnerAnimator.SetBool("b_Climb", false);
                babyRunnerAnimator.SetBool("b_Sit", false);
                babyRunnerAnimator.SetBool("b_Slide", true);
                babyRunnerAnimator.SetBool("b_Knockdown", false);
                break;
            case BabyRunnerAnimationsState.Victory:
                babyRunnerAnimator.SetBool("b_Run", false);
                babyRunnerAnimator.SetBool("b_Climb", false);
                babyRunnerAnimator.SetBool("b_Sit", false);
                babyRunnerAnimator.SetBool("b_Slide", false);
                babyRunnerAnimator.SetBool("b_Knockdown", false);
                babyRunnerAnimator.SetTrigger("t_Victory");
                break;
            case BabyRunnerAnimationsState.Climb:
                babyRunnerAnimator.SetBool("b_Run", false);
                babyRunnerAnimator.SetBool("b_Climb", true);
                babyRunnerAnimator.SetBool("b_Sit", false);
                babyRunnerAnimator.SetBool("b_Slide", false);
                babyRunnerAnimator.SetBool("b_Knockdown", false);
                break;
            case BabyRunnerAnimationsState.Knockdown:
                babyRunnerAnimator.SetBool("b_Run", false);
                babyRunnerAnimator.SetBool("b_Climb", true);
                babyRunnerAnimator.SetBool("b_Sit", false);
                babyRunnerAnimator.SetBool("b_Slide", false);
                babyRunnerAnimator.SetBool("b_Knockdown", true);
                break;
        }
    }
    #endregion
}
