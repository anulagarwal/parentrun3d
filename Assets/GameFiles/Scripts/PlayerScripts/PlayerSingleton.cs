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
    [SerializeField] private float lerpSpeed = 4;

    [SerializeField] private List<string> remarks = new List<string>();

    [Header("Components Reference")]
    [SerializeField] private List<Image> playerEnergyBars = new List<Image>();
    [SerializeField] private PlayerMovementHandler playerMovementHandler = null;
    [SerializeField] private PlayerAnimationsHandler playerAnimationsHandler = null;
    [SerializeField] private TextMeshPro remarkTxt = null;
    [SerializeField] private PlayerGroundCheckersHander playerGroundCheckersHander = null;
    [SerializeField] private GameObject playerCart = null;
    [SerializeField] private Transform groundPointTransform = null;

    private int playerEnergy = 0;
    private Image playerEnergyBar = null;
    private int energyBarIndex = 0;
    private int energyCapTemp = 0;
    private int targetEnergy;
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
        energyBarIndex = 0;
        EnableEnergyBar();
        energyCapTemp = playerEnergyCapacity;
        targetEnergy = playerEnergy;
    }
    #endregion

    #region Getter And Setter
    public int GetPlayerEnergyCapacity { get => playerEnergyCapacity; }

    public PlayerMovementHandler GetPlayerMovementHandler { get => playerMovementHandler; }

    public PlayerAnimationsHandler GetPlayerAnimationsHandler { get => playerAnimationsHandler; }

    public PlayerGroundCheckersHander GetPlayerGroundCheckersHander { get => playerGroundCheckersHander; }
    
    public Transform GetGroundPointTransform { get => groundPointTransform; }
    #endregion


    private void Update()
    {
        playerEnergy =  Mathf.FloorToInt(Mathf.Lerp(playerEnergy, targetEnergy, lerpSpeed));
        UpdateEnergyBar((float)playerEnergy / (float)playerEnergyCapacity);

    }
    #region Public Core Functions
    public void UpdatePlayerEnergy(int amount)
    {
        targetEnergy += amount;
        if (targetEnergy > playerEnergyCapacity)
        {
            UpdateEnergyBar((float)targetEnergy / (float)playerEnergyCapacity);
            targetEnergy = 0;
        }
        else if (targetEnergy < 0)
        {
            targetEnergy = 0;
        }
    }

    public void EnablePlayerHingeJoint(bool value)
    {
        playerCart.SetActive(value);
    }
    #endregion

    #region Private Core Functions
    private void UpdateEnergyBar(float value)
    {
        playerEnergyBar.fillAmount = value;

       /* if (value <= 0.2f)
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
       */
        if (value >= 1f)
        {
            if (energyBarIndex < playerEnergyBars.Count)
            {
                energyBarIndex++;
                EnableEnergyBar();
            }
            else
            {
                print("Full");
            }
        }
        else if (value <= 0f)
        {
            if (energyBarIndex > 0)
            {
                energyBarIndex--;
                EnableEnergyBar();
            }
            else
            {
                print("Empty");
            }
        }
    }

    private void EnableEnergyBar()
    {
        foreach (Image i in playerEnergyBars)
        {
            i.enabled = false;
        }
       playerEnergyBars[energyBarIndex].enabled = true;
        remarkTxt.SetText(remarks[energyBarIndex]);

        playerEnergyBar = playerEnergyBars[energyBarIndex];
        playerEnergyBar.fillAmount = 0;
        playerEnergyCapacity += energyCapTemp;
    }
    #endregion

}
