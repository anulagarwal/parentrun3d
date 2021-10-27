using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private int score = 0;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        GetComponentInChildren<ParticleSystem>().Play();
    }
    #region Getter And Setter
    public int GetScore { get => score; }
    #endregion
}
