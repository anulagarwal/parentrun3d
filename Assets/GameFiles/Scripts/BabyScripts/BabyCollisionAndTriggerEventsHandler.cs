using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyCollisionAndTriggerEventsHandler : MonoBehaviour
{
    #region MonoBehaviour Functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Score")
        {
            if (other.gameObject.TryGetComponent<ScoreTriggerHandler>(out ScoreTriggerHandler scoreTriggerHandler))
            {
                other.GetComponentInChildren<ParticleSystem>().Play();
            }
        }
        print(other.gameObject.tag);
    }
    #endregion
}
