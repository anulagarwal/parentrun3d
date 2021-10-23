using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMovementHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float scaleDownSpeed = 0f;

    [Header("Components Reference")]
    [SerializeField] private PlayerGroundCheckersHander playerGroundCheckersHander = null;

    private BabyAnimationsHandler babyAnimationsHandler = null;
    private VariableJoystick movementJS = null;
    private Vector3 movementDirection = Vector3.zero;
    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        babyAnimationsHandler = BabySingleton.Instance.GetBabyAnimationsHandler;
        babyAnimationsHandler.SwitchBabyAnimations(BabyState.Walk);
        this.transform.rotation = PlayerSingleton.Instance.transform.rotation;
        movementJS = LevelUIManager.Instance.GetMovementJS;
    }

    private void FixedUpdate()
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

        transform.Translate(movementDirection * Time.deltaTime * moveSpeed);
        transform.localScale -= Vector3.one * Time.deltaTime * scaleDownSpeed;

        if (transform.localScale.x <= 3.3f)
        {
            LevelUIManager.Instance.SwitchUIPanel(UIPanelState.GameOver, GameOverState.Victory);
            PlayerSingleton.Instance.GetPlayerMovementHandler.enabled = false;
            PlayerSingleton.Instance.GetPlayerAnimationsHandler.SwitchAnimation(PlayerAnimationState.Idle);
            babyAnimationsHandler.SwitchBabyAnimations(BabyState.Happy);
            this.enabled = false;
        }
    }
    #endregion
}
