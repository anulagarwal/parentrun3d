using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePointHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private Transform nextPointTransform = null;
    #endregion

    #region Getter And Setter
    public Transform GetNextPointTransform { get => nextPointTransform; }
    #endregion
}
