using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySingleton : MonoBehaviour
{
    #region Porperties
    public static BabySingleton Instance = null;

    [Header("Attributes")]
    [SerializeField] private float scaleSpeed = 0f;
    [SerializeField] private float maxScale;
    [SerializeField] private float minScale;



    [Header("Components Reference")]
    [SerializeField] private BabyMovementHandler babyMovementHandler = null;
    [SerializeField] private BabyAnimationsHandler babyAnimationsHandler = null;
    [SerializeField] private BabyRendererHandler babyRendererHandler = null;
    [SerializeField] private Animator animator = null;

    [Header("Animators")]
    [SerializeField] private RuntimeAnimatorController sleepingRuntimeAnimator = null;
    [SerializeField] private RuntimeAnimatorController defaultRuntimeAnimator = null;
    #endregion

    #region MonoBehaviour Functions
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void Start()
    {
        babyMovementHandler.enabled = false;
    }
    #endregion

    #region Getter And Setter
    public BabyMovementHandler GetBabyMovementHandler { get => babyMovementHandler; }
    
    public BabyAnimationsHandler GetBabyAnimationsHandler { get => babyAnimationsHandler; }
    public BabyRendererHandler GetBabyRendererHandler { get => babyRendererHandler; }

    #endregion

    #region Public Core Functions
    public void ScaleUpBaby()
    {
        this.transform.localScale += Vector3.one * scaleSpeed;
        if(this.transform.localScale.x > maxScale)
        {
            this.transform.localScale = new Vector3(maxScale, maxScale, maxScale);
        }
       
    }


    public void ScaleDownBaby()
    {
        this.transform.localScale -= Vector3.one * scaleSpeed;
        if (this.transform.localScale.x < minScale)
        {
            this.transform.localScale = new Vector3(minScale, minScale, minScale);
        }
    }

    public void DerackBaby()
    {
        this.transform.parent = null;
        transform.rotation = PlayerSingleton.Instance.transform.rotation;
        transform.position = PlayerSingleton.Instance.GetGroundPointTransform.position;
    }

    public void SwitchRuntimeAnimatorController(BabyAnimators anim)
    {
        switch (anim)
        {
            case BabyAnimators.Default:
                animator.runtimeAnimatorController = defaultRuntimeAnimator;
                break;
            case BabyAnimators.Sleeping:
                animator.runtimeAnimatorController = sleepingRuntimeAnimator;
                break;
        }
    }
    #endregion
}
