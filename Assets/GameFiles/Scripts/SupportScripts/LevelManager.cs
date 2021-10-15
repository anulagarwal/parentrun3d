using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    #region Properties
    public static LevelManager Instance = null;

    [Header("Components Reference")]
    [SerializeField] private GameObject confettiObj = null;
    [SerializeField] private CinemachineVirtualCameraBase cmcv_1 = null;
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
        SwitchCMCV(CMCV.PlayerCMCV);
    }
    #endregion

    #region Public Core Functions
    public void Victory()
    {
        confettiObj.SetActive(true);
    }

    public void SwitchCMCV(CMCV activeCMCV)
    {
        if (activeCMCV == CMCV.PlayerCMCV)
        {
            cmcv_1.Follow = PlayerSingleton.Instance.transform;
            cmcv_1.LookAt = PlayerSingleton.Instance.transform;
        }
        else if (activeCMCV == CMCV.BabyCMCV)
        {
            cmcv_1.Follow = BabySingleton.Instance.transform;
            cmcv_1.LookAt = BabySingleton.Instance.transform;
        }
    }
    #endregion
}
