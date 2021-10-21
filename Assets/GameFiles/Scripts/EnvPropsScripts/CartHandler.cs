using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float jerkSpeed = 0f;
    [SerializeField] private float jerkLimitY = 0f;
    #endregion

    #region Delegates
    public delegate void CoreMech();

    public CoreMech coreMech;
    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        coreMech = null;
    }

    private void Update()
    {
        if (coreMech != null)
        {
            coreMech();
        }
    }
    #endregion

    #region Public Core Functions
    
    #endregion

    #region Private Core Functions
    #endregion
}
