using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private int energy = 0;
    #endregion

    #region Getter And Setter
    public int GetEnergy { get => energy; }

    #endregion
}
