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
            BabySingleton.Instance.SwitchRuntimeAnimatorController(BabyAnimators.Default);
            BabySingleton.Instance.GetBabyAnimationsHandler.ClearVFX();
            BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.Clap);
            //BabySingleton.Instance.SwitchRuntimeAnimatorController(BabyAnimators.Default);
            LevelManager.Instance.Victory();
            LevelUIManager.Instance.SwitchUIPanel(UIPanelState.GameOver, GameOverState.Victory);

            BabySingleton.Instance.DerackBaby();
            PlayerSingleton.Instance.EnablePlayerHingeJoint(false);
            PlayerSingleton.Instance.EnableCanvas(false);
         //   Invoke("MoveToEndPoint", 2f);
        }
        else if (other.gameObject.tag == "Obstacle")
        {
            if (other.gameObject.TryGetComponent<ObstacleHandler>(out ObstacleHandler obstacleHandler))
            {
                if (obstacleHandler.GetEnergy < 0)
                {
                    if (PlayerSingleton.Instance.gameType == GameType.Hunger)
                    {
                        BabySingleton.Instance.ScaleDownBaby();
                        BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.Crying);
                    }

                    if(PlayerSingleton.Instance.gameType == GameType.Health)
                    {
                        
                    }

                }
                else if (obstacleHandler.GetEnergy > 0)
                {
                    if (PlayerSingleton.Instance.gameType == GameType.Hunger)
                    {
                        BabySingleton.Instance.ScaleUpBaby();
                        BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.Happy);
                    }

                    if (PlayerSingleton.Instance.gameType == GameType.Health)
                    {
                        //Change Anim
                    }

                }
                PlayerSingleton.Instance.UpdatePlayerEnergy(obstacleHandler.GetEnergy);
                Destroy(other.gameObject);
            }
        }
        else if(other.gameObject.tag == "Audio")
        {

            if (other.gameObject.TryGetComponent<AudioHandler>(out AudioHandler obstacleHandler))
            {
                if (obstacleHandler.GetEnergy < 0)
                {
                    if (PlayerSingleton.Instance.gameType == GameType.Hunger)
                        BabySingleton.Instance.ScaleDownBaby();

                    PlayerSingleton.Instance.UpdatePlayerEnergy(obstacleHandler.GetEnergy);
                }
               
            }

        }
        else if (other.gameObject.tag == "Gate")
        {
            if (PlayerSingleton.Instance.gameType == GameType.Sleep)
            {

                if (other.gameObject.TryGetComponent<GateHandler>(out GateHandler gateHandler))
                {
                    gateHandler.EnableVFX();                                 
                    PlayerSingleton.Instance.SetBar(gateHandler.GetEnergyBarNumber);
                }
            }


            else 
            {
                if (other.gameObject.TryGetComponent<GateHandler>(out GateHandler gateHandler))
                {
                   // gateHandler.EnableVFX();
                    PlayerSingleton.Instance.UpdatePlayerEnergy(gateHandler.GetEnergy);
                    BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(gateHandler.GetBabyState);
                }
            }
        }
        else if (other.gameObject.tag == "Path")
        {
            PlayerSingleton.Instance.GetPlayerMovementHandler.SwitchSpeed(PlayerSpeedType.SlowDown);
        }
        else if (other.gameObject.tag == "Shower")
        {
            if (other.gameObject.TryGetComponent<ShowerHandler>(out ShowerHandler showerHandler))
            {
                showerHandler.PlayShowerPS();
                showerHandler.GetShowerPS.transform.parent.SetParent(this.transform);
                showerHandler.GetShowerPS.transform.parent.localPosition = new Vector3(0, 1, -1.4f);

                Destroy(showerHandler.GetShowerPS.transform.gameObject, 5f);
            }
        }

        if (other.gameObject.tag == "Breaker")
        {
            if (other.gameObject.TryGetComponent<ObstacleHandler>(out ObstacleHandler obstacleHandler))
            {
                PlayerSingleton.Instance.UpdatePlayerEnergy(obstacleHandler.GetEnergy);
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
         
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Path")
        {
            PlayerSingleton.Instance.GetPlayerMovementHandler.SwitchSpeed(PlayerSpeedType.Normal);
        }
    }
    #endregion

    #region Invoke Functions
    private void MoveToEndPoint()
    {
        PlayerSingleton.Instance.GetPlayerMovementHandler.enabled = true;
        PlayerSingleton.Instance.GetPlayerMovementHandler.EnablePlayerMoveTowardsMechanic(true);
    }
    #endregion
}
