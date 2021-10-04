using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float turnSpeed = 0f;
    [SerializeField] private float rotSpeed = 0f;

    private Vector3 movementDirection = Vector3.zero;
    private Quaternion newTurnRotation = Quaternion.identity;
    private VariableJoystick movementJS = null;
    private PlayerGroundCheckersHander playerGroundCheckersHander = null;
    #endregion

    #region Delegate
    public delegate void PlayerMovementCore();

    public PlayerMovementCore playerMovementCore = null;
    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        EnablePlayerTranslation(true);
        movementJS = LevelUIManager.Instance.GetMovementJS;
        PlayerSingleton.Instance.GetPlayerAnimationsHandler.SwitchAnimation(PlayerAnimationState.Run);
        playerGroundCheckersHander = PlayerSingleton.Instance.GetPlayerGroundCheckersHander;
    }

    private void Update()
    {
        if (playerMovementCore != null)
        {
            playerMovementCore();
        }
    }
    #endregion

    #region Getter And Setter
    public float TargetTurnAngle { get; set; }
    #endregion

    #region Private Core Functions
    private void PlayerTranslation()
    {
        movementDirection = new Vector3(movementJS.Horizontal, 0, 1).normalized;

        if (playerGroundCheckersHander.RestrictLeftMovement)
        {
            if (movementDirection.x < 0)
            {
                movementDirection.x = 0;
            }
        }

        if (playerGroundCheckersHander.RestrictRightMovement)
        {
            if (movementDirection.x > 0)
            {
                movementDirection.x = 0;
            }
        }

        transform.Translate(movementDirection * Time.deltaTime * moveSpeed, Space.Self);
    }

    private void PlayerPathTurn()
    {
        if (Quaternion.Angle(transform.rotation, newTurnRotation) >= 1f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, newTurnRotation, Time.deltaTime * turnSpeed);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(TargetTurnAngle, Vector3.up);
            EnablePlayerPathTurn(false);
        }
    }
    #endregion

    #region Public Core Functions
    public void EnablePlayerTranslation(bool value)
    {
        if (value)
        {
            playerMovementCore += PlayerTranslation;
        }
        else
        {
            playerMovementCore -= PlayerTranslation;
        }
    }

    public void EnablePlayerPathTurn(bool value, float angle = 0f)
    {
        if (value)
        {
            TargetTurnAngle = angle;
            newTurnRotation = Quaternion.AngleAxis(TargetTurnAngle, Vector3.up);
            playerMovementCore += PlayerPathTurn;
        }
        else
        {
            playerMovementCore -= PlayerPathTurn;
        }
    }
    #endregion
}
