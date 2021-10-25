using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRunnerMovementHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 0;
    [SerializeField] private float turnSpeed = 0f;

    [Header("Components Reference")]
    [SerializeField] private BabyRunnerAnimationsHandler babyRunnerAnimationsHandler = null;
    [SerializeField] private PlayerGroundCheckersHander babyGroundCheckersHander = null;

    private Vector3 movementDirection = Vector3.zero;
    private Quaternion newTurnRotation = Quaternion.identity;
    private VariableJoystick movementJS = null;
    #endregion

    #region Delegate
    public delegate void BabyRunnerMovementCore();

    public BabyRunnerMovementCore babyRunnerMovementCore = null;
    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        EnablePlayerTranslation(true);
        movementJS = LevelUIManager.Instance.GetMovementJS;
    }

    private void Update()
    {
        if (babyRunnerMovementCore != null)
        {
            babyRunnerMovementCore();
        }
    }
    #endregion

    #region Getter And Setter
    public float TargetTurnAngle { get; set; }
    #endregion

    #region Private Core Functions
    private void PlayerTranslation()
    {
        if (movementJS)
        {
            movementDirection = new Vector3(movementJS.Horizontal, 0, 1).normalized;
            if (babyGroundCheckersHander.RestrictLeftMovement)
            {

                if (movementDirection.x < 0)
                {
                    movementDirection.x = 0;

                }
            }

            if (babyGroundCheckersHander.RestrictRightMovement)
            {
                if (movementDirection.x > 0)
                {
                    print(movementJS.Horizontal);

                    movementDirection.x = 0;
                }
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
            BabyRunnerSingleton.Instance.GetBabyRunnerAnimationsHandler.SwitchBabyRunnerAnimation(BabyRunnerAnimationsState.Run);
            babyRunnerMovementCore += PlayerTranslation;
        }
        else
        {
            BabyRunnerSingleton.Instance.GetBabyRunnerAnimationsHandler.SwitchBabyRunnerAnimation(BabyRunnerAnimationsState.Idle);
            babyRunnerMovementCore -= PlayerTranslation;
        }
    }

    public void EnablePlayerPathTurn(bool value, float angle = 0f)
    {
        if (value)
        {
            TargetTurnAngle = angle;
            newTurnRotation = Quaternion.AngleAxis(TargetTurnAngle, Vector3.up);
            babyRunnerMovementCore += PlayerPathTurn;
        }
        else
        {
            babyRunnerMovementCore -= PlayerPathTurn;
        }
    }
    #endregion
}
