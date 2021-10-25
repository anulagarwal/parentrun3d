using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTranslationHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private Transform point_1 = null;
    [SerializeField] private Transform point_2 = null;

    private Vector3 direction = Vector3.zero;
    private bool moveTowardsPoint_1 = false;
    #endregion
    private void Start()
    {
        
    }
    #region MonoBehaviour Functions
    private void Update()
    {
        if (moveTowardsPoint_1)
        {
            if (Vector3.Distance(transform.position, point_1.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, point_1.position, Time.deltaTime * moveSpeed);
            }
            else
            {
                moveTowardsPoint_1 = false;
            }
            direction = (point_1.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction);
        }
        else
        {
            if (Vector3.Distance(transform.position, point_2.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, point_2.position, Time.deltaTime * moveSpeed);
            }
            else
            {
                moveTowardsPoint_1 = true;
            }
            direction = (point_2.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
    #endregion
}
