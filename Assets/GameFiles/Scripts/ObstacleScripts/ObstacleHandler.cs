using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private int energy = 0;
    [SerializeField] private ObstacleState obstacleState = ObstacleState.Plus;
    #endregion

    #region Getter And Setter
    public int GetEnergy { get => energy; }

    public ObstacleState GetObstacleState { get => obstacleState; }
    #endregion
}
