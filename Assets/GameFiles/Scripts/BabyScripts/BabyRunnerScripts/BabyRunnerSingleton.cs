using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRunnerSingleton : MonoBehaviour
{
    #region Properties
    public static BabyRunnerSingleton Instance = null;

    [Header("Components Reference")]
    [SerializeField] private BabyRunnerMovementHandler babyRunnerMovementHandler = null;
    [SerializeField] private BabyRunnerAnimationsHandler babyRunnerAnimationsHandler = null;
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
    public BabyRunnerMovementHandler GetBabyRunnerMovementHandler { get => babyRunnerMovementHandler; }
   
    public BabyRunnerAnimationsHandler GetBabyRunnerAnimationsHandler { get => babyRunnerAnimationsHandler; }
    #endregion
}
