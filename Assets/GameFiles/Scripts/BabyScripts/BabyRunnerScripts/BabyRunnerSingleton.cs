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

    #region Delegates
    public delegate void ScaleMech();

    public ScaleMech scaleMech;
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

    private void Start()
    {
        TargetScale = transform.localScale.x;
    }

    private void Update()
    {
        if (scaleMech != null)
        {
            scaleMech();
        }
    }
    #endregion

    #region Private Core Functions
    private void ScaleUpBaby()
    {
        if (transform.localScale.x < TargetScale)
        {
            this.transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
            if (this.transform.localScale.x > maxScale)
            {
                this.transform.localScale = new Vector3(maxScale, maxScale, maxScale);
            }

            if (TargetScale > maxScale)
            {
                TargetScale = maxScale;
                EnableScaleUp(false);
            }
        }
        else
        {
            EnableScaleUp(false);
        }
    }

    private void ScaleDownBaby()
    {
        if (transform.localScale.x > TargetScale)
        {
            this.transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
            if (this.transform.localScale.x < minScale)
            {
                this.transform.localScale = new Vector3(minScale, minScale, minScale);
            }

            if (TargetScale < minScale)
            {
                TargetScale = minScale;
                EnableScaleDown(false);
            }
        }
        else
        {
            EnableScaleDown(false);
        }
    }
    #endregion

    public void EnableScaleUp(bool value)
    {
        if (value)
        {
            scaleMech += ScaleUpBaby;
        }
        else
        {
            scaleMech -= ScaleUpBaby;
        }
    }

    public void EnableScaleDown(bool value)
    {
        if (value)
        {
            scaleMech += ScaleDownBaby;
        }
        else
        {
            scaleMech -= ScaleDownBaby;
            babyRunnerMovementHandler.enabled = false;
            babyRunnerAnimationsHandler.SwitchBabyRunnerAnimation(BabyRunnerAnimationsState.Victory);
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

    #region Getter And Setter
    public BabyRunnerMovementHandler GetBabyRunnerMovementHandler { get => babyRunnerMovementHandler; }
   
    public BabyRunnerAnimationsHandler GetBabyRunnerAnimationsHandler { get => babyRunnerAnimationsHandler; }
    
    public float TargetScale { get; set; }
    #endregion
}
