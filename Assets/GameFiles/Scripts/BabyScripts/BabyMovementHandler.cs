using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMovementHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float scaleDownSpeed = 0f;

    private BabyAnimationsHandler babyAnimationsHandler = null;
    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        babyAnimationsHandler = BabySingleton.Instance.GetBabyAnimationsHandler;
        babyAnimationsHandler.SwitchBabyAnimations(BabyState.Walk);
        this.transform.rotation = PlayerSingleton.Instance.transform.rotation;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        transform.localScale -= Vector3.one * Time.deltaTime * scaleDownSpeed;

        if (transform.localScale.x <= 2)
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
