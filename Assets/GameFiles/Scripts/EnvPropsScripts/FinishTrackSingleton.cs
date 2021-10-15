using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrackSingleton : MonoBehaviour
{
    #region Properties
    public static FinishTrackSingleton Instance = null;

    [Header("Components Reference")]
    [SerializeField] private Transform trackEndPoint = null;
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
    public Transform GetTrackEndPoint { get => trackEndPoint; }
    #endregion
}
