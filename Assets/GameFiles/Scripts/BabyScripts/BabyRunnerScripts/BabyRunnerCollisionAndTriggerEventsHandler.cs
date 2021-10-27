using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRunnerCollisionAndTriggerEventsHandler : MonoBehaviour
{
    #region MonoBehaviour Functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SlideStair")
        {
            BabyRunnerSingleton.Instance.GetBabyRunnerMovementHandler.EnableSlideMech(true, other.gameObject.GetComponent<SlidePointHandler>().GetNextPointTransform, BabyRunnerSlideState.Climb);
        }
        else if(other.gameObject.tag == "SlideTop")
        {
            BabyRunnerSingleton.Instance.GetBabyRunnerMovementHandler.EnableSlideMech(true, other.gameObject.GetComponent<SlidePointHandler>().GetNextPointTransform, BabyRunnerSlideState.Slide);
        }
        else if (other.gameObject.tag == "SlideEndPoint")
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            BabyRunnerSingleton.Instance.GetBabyRunnerMovementHandler.EnableSlideMech(false, null, BabyRunnerSlideState.Default);
        }

        if (other.gameObject.tag == "Turn")
        {
            BabyRunnerSingleton.Instance.GetBabyRunnerMovementHandler.EnablePlayerPathTurn(true, other.gameObject.GetComponent<TurnTriggerHandler>().GetTurnAngle);
        }

        if (other.gameObject.tag == "Obstacle")
        {
            if (other.gameObject.TryGetComponent<ObstacleHandler>(out ObstacleHandler obstacleHandler))
            {
                if (obstacleHandler.GetEnergy < 0)
                {
                    BabyRunnerSingleton.Instance.SpawnNegativeVFX(other.transform.position);
                    BabyRunnerSingleton.Instance.ScaleDownBaby();

                    //  BabyRunnerSingleton.Instance.TargetScale -= .5f;
                    // BabyRunnerSingleton.Instance.EnableScaleDown(true);
                }
                else if (obstacleHandler.GetEnergy > 0)
                {
                    BabyRunnerSingleton.Instance.SpawnPositiveVFX(other.transform.position);
                    BabyRunnerSingleton.Instance.ScaleUpBaby();
                    //BabyRunnerSingleton.Instance.TargetScale += .5f;
                    //BabyRunnerSingleton.Instance.EnableScaleUp(true);
                }

                //PlayerSingleton.Instance.UpdatePlayerEnergy(obstacleHandler.GetEnergy);
                Destroy(other.gameObject);
            }
        }

        if(other.gameObject.tag == "Knockback")
        {
            Destroy(other.gameObject);
            BabyRunnerSingleton.Instance.GetBabyRunnerMovementHandler.KnockdownBaby(true);
        }

        if (other.gameObject.tag == "Seasaw")
        {
            if (other.gameObject.TryGetComponent<SeasawPlankHandler>(out SeasawPlankHandler seasawPlankHandler))
            {
                seasawPlankHandler.enabled = true;
                BabyRunnerSingleton.Instance.GetBabyRunnerMovementHandler.EnableSeasawRide(true);
                transform.position = seasawPlankHandler.GetSeatTransform.position;
                transform.parent = seasawPlankHandler.GetSeatTransform;
                BabyRunnerSingleton.Instance.GetBabyRunnerMovementHandler.SeasawJumpPoints = seasawPlankHandler.GetJumpPoints;
            }
        }

        if(other.gameObject.tag == "Finish")
        {
            BabyRunnerSingleton.Instance.TargetScale = 3;
            BabyRunnerSingleton.Instance.EnableScaleDown(true);
            //BabyRunnerSingleton.Instance.GetBabyRunnerAnimationsHandler.SwitchBabyRunnerAnimation(BabyRunnerAnimationsState.Victory);
            //LevelManager.Instance.Victory();
            LevelUIManager.Instance.SwitchUIPanel(UIPanelState.GameOver, GameOverState.Victory);
        }
    }
    #endregion
}
