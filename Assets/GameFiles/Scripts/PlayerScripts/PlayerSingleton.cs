using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSingleton : MonoBehaviour
{
    #region Properties
    public static PlayerSingleton Instance = null;

    [Header("Attributes")]
    [SerializeField] private int playerEnergyCapacity = 0;
    [SerializeField] private List<string> remarks = new List<string>();

    [Header("Components Reference")]
    [SerializeField] private Image playerEnergyBar = null;
    [SerializeField] private PlayerMovementHandler playerMovementHandler = null;
    [SerializeField] private PlayerAnimationsHandler playerAnimationsHandler = null;
    [SerializeField] private TextMeshPro remarkTxt = null;
    [SerializeField] private PlayerGroundCheckersHander playerGroundCheckersHander = null;

    private int playerEnergy = 0;
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
    public int GetPlayerEnergyCapacity { get => playerEnergyCapacity; }

    public PlayerMovementHandler GetPlayerMovementHandler { get => playerMovementHandler; }

    public PlayerAnimationsHandler GetPlayerAnimationsHandler { get => playerAnimationsHandler; }

    public PlayerGroundCheckersHander GetPlayerGroundCheckersHander { get => playerGroundCheckersHander; }
    #endregion

    #region Public Core Functions
    public void UpdatePlayerEnergy(int amount)
    {
        playerEnergy += amount;
        if (playerEnergy > playerEnergyCapacity)
        {
            playerEnergy = playerEnergyCapacity;
        }
        else if (playerEnergy < 0)
        {
            playerEnergy = 0;
        }

        UpdateEnergyBar((float)playerEnergy / (float)playerEnergyCapacity);
    }
    #endregion

    #region Private Core Functions
    private void UpdateEnergyBar(float value)
    {
        playerEnergyBar.fillAmount = value;

        if (value <= 0.2f)
        {
            remarkTxt.SetText(remarks[0]);
        }
        else if (value <= 0.4f)
        {
            remarkTxt.SetText(remarks[1]);
        }
        else if (value <= 0.6f)
        {
            remarkTxt.SetText(remarks[2]);
        }
        else if (value <= 0.8f)
        {
            remarkTxt.SetText(remarks[3]);
        }
        else if (value <= 1f)
        {
            remarkTxt.SetText(remarks[4]);
        }
    }
    #endregion
}
