using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRunnerSingleton : MonoBehaviour
{
    #region Properties
    public static BabyRunnerSingleton Instance = null;

    [Header("Attributes")]
    [SerializeField] private float scaleSpeed = 0f;
    [SerializeField] private float maxScale;
    [SerializeField] private float minScale;

    [Header("Components Reference")]
    [SerializeField] private BabyRunnerMovementHandler babyRunnerMovementHandler = null;
    [SerializeField] private BabyRunnerAnimationsHandler babyRunnerAnimationsHandler = null;
    [SerializeField] private GameObject positiveVfx = null;
    [SerializeField] private GameObject negativeVfx = null;
    #endregion

    #region MonoBehaviour Functions
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
    #endregion

    public void ScaleUpBaby()
    {
        this.transform.localScale += Vector3.one * scaleSpeed;
        if (this.transform.localScale.x > maxScale)
        {
            this.transform.localScale = new Vector3(maxScale, maxScale, maxScale);
        }


    }
    public void SpawnPositiveVFX(Vector3 pos)
    {
        Destroy(Instantiate(positiveVfx, new Vector3(pos.x, 1.5f, pos.z), Quaternion.identity), 2f);
    }

    public void SpawnNegativeVFX(Vector3 pos)
    {
        Destroy(Instantiate(negativeVfx, new Vector3(pos.x, 1.5f, pos.z), Quaternion.identity), 2f);
    }

    public void ScaleDownBaby()
    {
        this.transform.localScale -= Vector3.one * scaleSpeed;
        if (this.transform.localScale.x < minScale)
        {
            this.transform.localScale = new Vector3(minScale, minScale, minScale);
        }
    }
    #region Getter And Setter
    public BabyRunnerMovementHandler GetBabyRunnerMovementHandler { get => babyRunnerMovementHandler; }
   
    public BabyRunnerAnimationsHandler GetBabyRunnerAnimationsHandler { get => babyRunnerAnimationsHandler; }
    #endregion
}
