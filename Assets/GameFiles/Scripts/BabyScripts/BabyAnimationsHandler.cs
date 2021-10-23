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
    [SerializeField] private GameObject noseBubbleVFX;
    [SerializeField] private GameObject zzzVFX;
    [SerializeField] private GameObject cryEmotionVFX;



    [SerializeField] private BabyState startState = BabyState.Idle;


    private List<GameObject> vfx = new List<GameObject>();

    private Vector3 noseBubbleSize;

    #endregion

    #region MonoBehaviour Functions

    private void Start()
    {
        vfx.Add(pukeVfx);
        vfx.Add(cryVFX);
        vfx.Add(zzzVFX);
        vfx.Add(cryEmotionVFX);
        vfx.Add(noseBubbleVFX);
        ClearVFX();
        noseBubbleSize = noseBubbleVFX.transform.localScale;
        SwitchBabyAnimations(startState);
      //  vfx.Add(steamVFX) ;


    }
    #endregion
    
    #region Public Core Functions

    public void IncreaseNoseBubble(float val)
    {

    }
    public void SwitchBabyAnimations(BabyState state)
    {
        switch (state)
        {
            case BabyState.Idle:
                animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", true);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", false);
                animator.SetBool("b_Sleep", false);
                animator.SetBool("b_LieCry", false);
                animator.SetBool("b_WakeUp", false);
                animator.SetBool("b_LightSleep", false);
                animator.SetBool("b_DeepSleep", false);
                break;
            case BabyState.Crying:
                animator.SetBool("b_Cry", true);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", false);
                animator.SetBool("b_Sleep", false);
                animator.SetBool("b_LieCry", false);
                animator.SetBool("b_WakeUp", false);
                animator.SetBool("b_LightSleep", false);
                animator.SetBool("b_DeepSleep", false);
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
                animator.SetBool("b_Sleep", false);
                animator.SetBool("b_LieCry", false);
                animator.SetBool("b_WakeUp", false);
                animator.SetBool("b_LightSleep", false);
                animator.SetBool("b_DeepSleep", false);
                break;
            case BabyState.Happy:
                animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", true);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", false);
                animator.SetBool("b_Sleep", false);
                animator.SetBool("b_LieCry", false);
                animator.SetBool("b_WakeUp", false);
                animator.SetBool("b_LightSleep", false);
                animator.SetBool("b_DeepSleep", false);
                ClearVFX();

                break;
            case BabyState.Laughing:
                animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", true);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", false);
                animator.SetBool("b_Sleep", false);
                animator.SetBool("b_LieCry", false);
                animator.SetBool("b_WakeUp", false);
                animator.SetBool("b_LightSleep", false);
                animator.SetBool("b_DeepSleep", false);
                ClearVFX();
                break;
            case BabyState.Clap:
                animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", true);
                animator.SetBool("b_Walk", false);
                animator.SetBool("b_Sleep", false);
                animator.SetBool("b_LieCry", false);
                animator.SetBool("b_WakeUp", false);
                animator.SetBool("b_LightSleep", false);
                animator.SetBool("b_DeepSleep", false);
                break;
            case BabyState.Walk:
                animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", true);
                animator.SetBool("b_Sleep", false);
                animator.SetBool("b_LieCry", false);
                animator.SetBool("b_WakeUp", false);
                animator.SetBool("b_LightSleep", false);
                animator.SetBool("b_DeepSleep", false);
                break;

                
            case BabyState.Puking:
                animator.SetBool("b_Cry", true);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", false);
                animator.SetBool("b_Sleep", false);
                animator.SetBool("b_LieCry", false);
                animator.SetBool("b_WakeUp", false);
                animator.SetBool("b_LightSleep", false);
                animator.SetBool("b_DeepSleep", false);
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
                animator.SetBool("b_Sleep", false);
                animator.SetBool("b_LieCry", false);
                animator.SetBool("b_WakeUp", false);
                animator.SetBool("b_LightSleep", false);
                animator.SetBool("b_DeepSleep", false);
                ClearVFX();
                //steamVFX.SetActive(true);
                BabySingleton.Instance.GetBabyRendererHandler.SwitchColor(BabyFaceColor.Red);
                break;



            case BabyState.Awake:
                /*  animator.SetBool("b_Cry", false);
                  animator.SetBool("b_Angry", false);
                  animator.SetBool("b_Happy", false);
                  animator.SetBool("b_Laugh", false);
                  animator.SetBool("b_Clap", false);
                  animator.SetBool("b_Walk", false);
                  animator.SetBool("b_Sleep", false);
                  animator.SetBool("b_LieCry", true);
                  animator.SetBool("b_WakeUp", false);
                  animator.SetBool("b_LightSleep", false);
                  animator.SetBool("b_DeepSleep", false);*/
                animator.Play("LieCry");
                ClearVFX();
                cryVFX.SetActive(true);
                cryEmotionVFX.SetActive(true);
                break;

            case BabyState.WakingUp:
                /*  animator.SetBool("b_Cry", false);
                  animator.SetBool("b_Angry", false);
                  animator.SetBool("b_Happy", false);
                  animator.SetBool("b_Laugh", false);
                  animator.SetBool("b_Clap", false);
                  animator.SetBool("b_Walk", false);
                  animator.SetBool("b_Sleep", false);
                  animator.SetBool("b_LieCry", false);
                  animator.SetBool("b_WakeUp", true);
                  animator.SetBool("b_LightSleep", false);
                  animator.SetBool("b_DeepSleep", false);*/
                animator.Play("WakingUp");
                ClearVFX();
                cryVFX.SetActive(true);
             break;

           
            case BabyState.Sleep:
              /*  animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", false);
                animator.SetBool("b_Sleep", true);
                animator.SetBool("b_LieCry", false);
                animator.SetBool("b_WakeUp", false);
                animator.SetBool("b_LightSleep", false);
                animator.SetBool("b_DeepSleep", false);*/
                animator.Play("Sleep");
                ClearVFX();
                noseBubbleVFX.SetActive(true);
                noseBubbleVFX.transform.localScale = noseBubbleSize;
                break;

            case BabyState.LightSleep:
              /*  animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", false);
                animator.SetBool("b_Sleep", false);
                animator.SetBool("b_LieCry", false);
                animator.SetBool("b_WakeUp", false);
                animator.SetBool("b_LightSleep", true);
                animator.SetBool("b_DeepSleep", false);*/
                animator.Play("LightSleep");
                ClearVFX();
                zzzVFX.SetActive(true);
                noseBubbleVFX.SetActive(true);
                noseBubbleVFX.transform.localScale = noseBubbleSize * 1.5f;
                break;


            case BabyState.DeepSleep:
                animator.Play("Sleeping");
               /* animator.SetBool("b_Cry", false);
                animator.SetBool("b_Angry", false);
                animator.SetBool("b_Happy", false);
                animator.SetBool("b_Laugh", false);
                animator.SetBool("b_Clap", false);
                animator.SetBool("b_Walk", false);
                animator.SetBool("b_Sleep", false);
                animator.SetBool("b_LieCry", false);
                animator.SetBool("b_WakeUp", false);
                animator.SetBool("b_LightSleep", false);
                animator.SetBool("b_DeepSleep", true);*/
                ClearVFX();
                zzzVFX.SetActive(true);
                noseBubbleVFX.SetActive(true);
                noseBubbleVFX.transform.localScale = noseBubbleSize * 2f;

                break;


        }
    }

   public void ClearVFX()
    {
        foreach(GameObject g in vfx)
        {
            g.SetActive(false);
        }
    }
    #endregion
}
