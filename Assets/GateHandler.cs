using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHandler : MonoBehaviour
{
    #region Properties
    [SerializeField] BabyState babyState;
    [SerializeField] private int energy = 0;
    #endregion

    #region Getter And Setter
    public BabyState GetBabyState { get => babyState; }
    public int GetEnergy { get => energy; }
    #endregion

}
