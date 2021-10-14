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
            PlayerSingleton.Instance.GetPlayerMovementHandler.EnablePlayerPathTurn(true, other.gameObject.GetComponent<TurnTriggerHandler>().GetTurnAngle);
        }
        else if (other.gameObject.tag == "Finish")
        {
            PlayerSingleton.Instance.GetPlayerMovementHandler.enabled = false;
            PlayerSingleton.Instance.GetPlayerAnimationsHandler.SwitchAnimation(PlayerAnimationState.Victory);
            BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.Clap);
            LevelManager.Instance.Victory();
            LevelUIManager.Instance.SwitchUIPanel(UIPanelState.GameOver, GameOverState.Victory);
        }
        else if (other.gameObject.tag == "Obstacle")
        {
            if (other.gameObject.TryGetComponent<ObstacleHandler>(out ObstacleHandler obstacleHandler))
            {
                if (obstacleHandler.GetEnergy < 0)
                {
                    BabySingleton.Instance.ScaleDownBaby();
                    BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.Crying);
                }
                else if (obstacleHandler.GetEnergy > 0)
                {
                    BabySingleton.Instance.ScaleUpBaby();
                    BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.Happy);
                }
                PlayerSingleton.Instance.UpdatePlayerEnergy(obstacleHandler.GetEnergy);
                Destroy(other.gameObject);
            }
        }

        else if (other.gameObject.tag == "Gate")
        {
            if (other.gameObject.TryGetComponent<GateHandler>(out GateHandler gateHandler))
            {
                BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(gateHandler.GetBabyState);
                PlayerSingleton.Instance.UpdatePlayerEnergy(gateHandler.GetEnergy);

            }
        }
    }
    #endregion
}
