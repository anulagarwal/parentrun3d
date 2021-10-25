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
                babyRunnerAnimator.SetBool("b_Sit", false);
                babyRunnerAnimator.SetBool("b_Slide", false);
                break;
            case BabyRunnerAnimationsState.Run:
                babyRunnerAnimator.SetBool("b_Run", true);
                babyRunnerAnimator.SetBool("b_Sit", false);
                babyRunnerAnimator.SetBool("b_Slide", false);
                break;
            case BabyRunnerAnimationsState.Sit:
                babyRunnerAnimator.SetBool("b_Run", false);
                babyRunnerAnimator.SetBool("b_Sit", true);
                babyRunnerAnimator.SetBool("b_Slide", false);
                break;
            case BabyRunnerAnimationsState.Slide:
                babyRunnerAnimator.SetBool("b_Run", false);
                babyRunnerAnimator.SetBool("b_Sit", false);
                babyRunnerAnimator.SetBool("b_Slide", true);
                break;
            case BabyRunnerAnimationsState.Victory:

                babyRunnerAnimator.SetBool("b_Run", false);
                babyRunnerAnimator.SetBool("b_Sit", false);
                babyRunnerAnimator.SetBool("b_Slide", false);
                babyRunnerAnimator.SetTrigger("t_Victory");
                break;
        }
    }
    #endregion
}
