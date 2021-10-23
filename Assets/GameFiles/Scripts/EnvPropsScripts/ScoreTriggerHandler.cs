using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private int score = 0;
    #endregion

    #region Getter And Setter
    public int GetScore { get => score; }
    #endregion
}
