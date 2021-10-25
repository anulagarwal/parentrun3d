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
            BabyRunnerSingleton.Instance.GetBabyRunnerMovementHandler.EnableSlideMech(false, null, BabyRunnerSlideState.Default);
        }
    }
    #endregion
}
