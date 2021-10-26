using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheckersHander : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float range = 0f;
    [SerializeField] private LayerMask layerMask = 0;

    [Header("Components Reference")]
    [SerializeField] private Transform groundCheckerRight = null;
    [SerializeField] private Transform groundCheckerLeft = null;
    #endregion

    #region MonoBehaviour Functions
    private void Update()
    {
        if (!Physics.Raycast(groundCheckerRight.position,-groundCheckerRight.up, range, layerMask))
        {
            RestrictRightMovement = true;
            RestrictLeftMovement = false;
        }
        else
        {
            RestrictRightMovement = false;
        }

        if (!Physics.Raycast(groundCheckerLeft.position, -groundCheckerLeft.up, range, layerMask))
        {
            RestrictRightMovement = false;
            RestrictLeftMovement = true;
        }
        else
        {
            RestrictLeftMovement = false;
        }
    }
    #endregion

    #region Getter And Setter
    public bool RestrictRightMovement { get; set; }

    public bool RestrictLeftMovement { get; set; }
    #endregion
}
