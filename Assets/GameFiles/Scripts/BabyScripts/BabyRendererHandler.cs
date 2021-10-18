using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRendererHandler : MonoBehaviour
{
    #region Properties
    [Header("attributes")]
    [SerializeField] private float lerpSpeed = 0;
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color hotRedColor = Color.red;

    [Header("Components Reference")]
    [SerializeField] private SkinnedMeshRenderer babyFaceMeshRenderer = null;

    private Material babyFaceMat = null;
    #endregion

    #region Delegates
    public delegate void ColorLerpMech();

    private Color targetColor = Color.white;
    public ColorLerpMech colorLerpMech = null;
    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        babyFaceMat = babyFaceMeshRenderer.material;
        colorLerpMech = null;
    }

    private void Update()
    {
        if (colorLerpMech != null)
        {
            colorLerpMech();
        }
    }
    #endregion

    #region Private Core Functions
    private void SwitchingMech()
    {
        if (babyFaceMeshRenderer.material.color != targetColor)
        {
            babyFaceMeshRenderer.material.color = Color.Lerp(babyFaceMeshRenderer.material.color, targetColor, Time.deltaTime * lerpSpeed);
        }
        else
        {
            colorLerpMech = null;
        }
    }
    #endregion

    #region Public Core Functions
    public void SwitchColor(BabyFaceColor color)
    {
        switch (color)
        {
            case BabyFaceColor.White:
                targetColor = defaultColor;
                colorLerpMech += SwitchingMech;
                break;
            case BabyFaceColor.Red:
                targetColor = hotRedColor;
                colorLerpMech += SwitchingMech;
                break;
        }
    }
    #endregion
}
