using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySingleton : MonoBehaviour
{
    #region Porperties
    public static BabySingleton Instance = null;

    [Header("Attributes")]
    [SerializeField] private float scaleSpeed = 0f;

    [Header("Components Reference")]
    [SerializeField] private BabyMovementHandler babyMovementHandler = null;
    [SerializeField] private BabyAnimationsHandler babyAnimationsHandler = null;
    [SerializeField] private BabyRendererHandler babyRendererHandler = null;

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
    }

    public void ScaleDownBaby()
    {
        this.transform.localScale -= Vector3.one * scaleSpeed;
    }

    public void DerackBaby()
    {
        this.transform.parent = null;
        transform.rotation = PlayerSingleton.Instance.transform.rotation;
        transform.position = PlayerSingleton.Instance.GetGroundPointTransform.position;
    }
    #endregion
}
