using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private ShowerType showerType = ShowerType.Cold;

    [Header("Components Reference")]
    [SerializeField] private ParticleSystem showerPS = null;
    #endregion

    #region Getter And Setter
    #endregion

    #region Public Core Functions
    public void PlayShowerPS()
    {
        showerPS.Play();
    }
    #endregion
}
