using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHandler : MonoBehaviour
{
    #region Properties
    [SerializeField] BabyState babyState;
    [SerializeField] private int energy = 0;
    [SerializeField] private GameObject vfx;

    #endregion


    public void EnableVFX()
    {
        if(vfx!=null)
        vfx.SetActive(true);
    }

    #region Getter And Setter
    public BabyState GetBabyState { get => babyState; }
    public int GetEnergy { get => energy; }
    #endregion

}
