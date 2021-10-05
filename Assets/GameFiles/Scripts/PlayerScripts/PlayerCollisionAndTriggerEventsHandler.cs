using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionAndTriggerEventsHandler : MonoBehaviour
{
    #region MonoBehaviour Functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Turn")
        {
            PlayerSingleton.Instance.GetPlayerMovementHandler.EnablePlayerPathTurn(true, 90);
        }
        else if (other.gameObject.tag == "Finish")
        {
            PlayerSingleton.Instance.GetPlayerMovementHandler.enabled = false;
            PlayerSingleton.Instance.GetPlayerAnimationsHandler.SwitchAnimation(PlayerAnimationState.Victory);
            LevelManager.Instance.Victory();
            LevelUIManager.Instance.SwitchUIPanel(UIPanelState.GameOver, GameOverState.Victory);
        }
        else if (other.gameObject.tag == "Obstacle")
        {
            if (other.gameObject.TryGetComponent<ObstacleHandler>(out ObstacleHandler obstacleHandler))
            {
                PlayerSingleton.Instance.UpdatePlayerEnergy(obstacleHandler.GetEnergy);
                Destroy(other.gameObject);
            }
        }
    }
    #endregion
}
