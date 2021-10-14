using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTriggerHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float turnAngle = 0f;
    #endregion

    #region Getter And Setter
    public float GetTurnAngle { get => turnAngle; }
    #endregion
}
