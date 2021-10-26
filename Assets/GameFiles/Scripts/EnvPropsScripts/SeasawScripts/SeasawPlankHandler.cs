using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasawPlankHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float rotSpeed = 0f;
    [SerializeField] private float rotAngle = 0f;
    [SerializeField] private Vector3 rotAxis = Vector3.zero;

    [Header("Components Reference")]
    [SerializeField] private Transform seatTransform = null;
    [SerializeField] private List<Transform> jumpPoints = new List<Transform>();

    private Quaternion targetRotation = Quaternion.identity;
    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        targetRotation = Quaternion.AngleAxis(rotAngle, rotAxis);
    }

    private void Update()
    {
        if (Quaternion.Angle(transform.rotation, targetRotation) > 1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
        }
        else
        {
            BabyRunnerSingleton.Instance.GetBabyRunnerMovementHandler.SeasawJumpMech();
            this.enabled = false;
        }
    }
    #endregion

    #region Getter And Setter
    public Transform GetSeatTransform { get => seatTransform; }

    public List<Transform> GetJumpPoints { get => jumpPoints; }
    #endregion
}
