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
    [SerializeField] private BabyAnimationsHandler babyAnimationsHandler = null;
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
    #endregion

    #region Getter And Setter
    public BabyAnimationsHandler GetBabyAnimationsHandler { get => babyAnimationsHandler; }
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
    #endregion
}
