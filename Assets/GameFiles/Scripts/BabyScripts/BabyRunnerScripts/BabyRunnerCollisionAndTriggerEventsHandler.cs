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
                    BabyRunnerSingleton.Instance.ScaleDownBaby();
                }
                else if (obstacleHandler.GetEnergy > 0)
                {
                    BabyRunnerSingleton.Instance.ScaleUpBaby();
                }
                //PlayerSingleton.Instance.UpdatePlayerEnergy(obstacleHandler.GetEnergy);
                Destroy(other.gameObject);
            }
        }
    }
    #endregion
}
