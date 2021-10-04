using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : MonoBehaviour
{
    #region Properties
    public static LevelUIManager Instance = null;

    [Header("Attributes")]
    [SerializeField] private List<string> remarks = new List<string>();

    [Header("UI Panels")]
    [SerializeField] private GameObject mainMenuUIObj = null;
    [SerializeField] private GameObject gameplayUIObj = null;
    [SerializeField] private GameObject gameOverUIObj = null;
    [SerializeField] private GameObject gameOverVictoryUIObj = null;
    [SerializeField] private GameObject gameOverDefeatUIObj = null;

    [Header("Gameplay UI Components Reference")]
    [SerializeField] private VariableJoystick movementJS = null;
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

    #region Getter And Setter
    public VariableJoystick GetMovementJS { get => movementJS; }
    #endregion

    #region Btn Events Functions
    public void OnClick_PlayBtn()
    {
        PlayerSingleton.Instance.GetPlayerMovementHandler.enabled = true;
        SwitchUIPanel(UIPanelState.Gameplay);
    }
    #endregion

    #region Public Core Functions
    public void SwitchUIPanel(UIPanelState state, GameOverState gameOverState = GameOverState.None)
    {
        switch (state)
        {
            case UIPanelState.MainMenu:
                mainMenuUIObj.SetActive(true);
                gameplayUIObj.SetActive(false);
                gameOverUIObj.SetActive(false);
                gameOverVictoryUIObj.SetActive(false);
                gameOverDefeatUIObj.SetActive(false);
                break;
            case UIPanelState.Gameplay:
                mainMenuUIObj.SetActive(false);
                gameplayUIObj.SetActive(true);
                gameOverUIObj.SetActive(false);
                gameOverVictoryUIObj.SetActive(false);
                gameOverDefeatUIObj.SetActive(false);
                break;
            case UIPanelState.GameOver:
                mainMenuUIObj.SetActive(false);
                gameplayUIObj.SetActive(false);
                gameOverUIObj.SetActive(true);

                if (gameOverState == GameOverState.Victory)
                {
                    gameOverVictoryUIObj.SetActive(true);
                    gameOverDefeatUIObj.SetActive(false);
                }
                else if (gameOverState == GameOverState.Defeat)
                {
                    gameOverVictoryUIObj.SetActive(false);
                    gameOverDefeatUIObj.SetActive(true);
                }
                break;
        }
    }
    #endregion
}
