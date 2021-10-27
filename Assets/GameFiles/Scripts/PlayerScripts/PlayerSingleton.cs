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
    [SerializeField] public GameType gameType;
    [SerializeField] private List<string> remarks = new List<string>();

    [Header("Components Reference")]
    [SerializeField] private GameObject canvas = null;
    [SerializeField] private List<Image> playerEnergyBars = new List<Image>();
    [SerializeField] private PlayerMovementHandler playerMovementHandler = null;
    [SerializeField] private PlayerAnimationsHandler playerAnimationsHandler = null;
    [SerializeField] private TextMeshPro remarkTxt = null;
    [SerializeField] private PlayerGroundCheckersHander playerGroundCheckersHander = null;
    [SerializeField] private GameObject playerCart = null;
    [SerializeField] private Transform groundPointTransform = null;

    [SerializeField] private int playerEnergy = 0;
    private Image playerEnergyBar = null;
   [SerializeField] private int energyBarIndex = 0;
    private int energyCapTemp = 0;
    [SerializeField] private int targetEnergy;
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
    public int GetEnergyBarIndex { get => energyBarIndex; }

    #endregion


    private void Update()
    {
      //  playerEnergy =  Mathf.FloorToInt(Mathf.Lerp((float)playerEnergy, (float)targetEnergy, lerpSpeed));
      //  print(targetEnergy);
      //  UpdateEnergyBar((float)playerEnergy / (float)playerEnergyCapacity);

        

    }
    #region Public Core Functions
    public void UpdatePlayerEnergy(int amount)
    {
        targetEnergy += amount;
        UpdateEnergyBar((float)targetEnergy / (float)playerEnergyCapacity);

        if (targetEnergy > playerEnergyCapacity)
        {
            targetEnergy = 0;
        }

        if (targetEnergy < 0)
        {
            targetEnergy = playerEnergyCapacity;
        }

    }

    public void EnablePlayerHingeJoint(bool value)
    {
        playerCart.SetActive(value);
    }
    #endregion

    #region Private Core Functions

    void UpdateBabySleep()
    {
//        print(energyBarIndex);
        switch (energyBarIndex)
        {
            
            case 0:
                BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.Awake);
                break;
            case 1:
                BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.WakingUp);

                break;

            case 2:
                BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.Sleep);

                break;

            case 3:
                BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.LightSleep);

                break;

            case 4:
                BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.DeepSleep);
                break;
        }
    }
    void UpdateBabyHealth()
    {
        switch (energyBarIndex)
        {

            case 0:
                BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.HighFever);
                break;
            case 1:
                BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.LowFever);

                break;

            case 2:
                BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.MildFever);

                break;

            case 3:
                BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.LukeWarm);

                break;

            case 4:
                BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.Healthy);
                break;
        }
    }

    void UpdateBabyFun()
    {
        switch (energyBarIndex)
        {

            case 0:
                BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.SUPERBORED);
                break;
            case 1:
                BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.NOTINTERESTED);
                break;

            case 2:
                BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.BORED);
                break;

            case 3:
                BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.ENJOYING);
                break;

            case 4:
                BabySingleton.Instance.GetBabyAnimationsHandler.SwitchBabyAnimations(BabyState.FUN);
                break;
        }
    }

    public void EnableCanvas(bool value)
    {
        canvas.SetActive(value);
    }

   public void SetBar(int value)
    {

        if(energyBarIndex < value)
        {
            while (energyBarIndex < value)
            {
                energyBarIndex++;
                EnableEnergyBar();
            }
        }
        else if(energyBarIndex > value)
        {
            while (energyBarIndex > value)
            {
                energyBarIndex--;
                ReduceEnergyBar();
            }
        }
               // energyBarIndex = value;

            
            if (gameType == GameType.Sleep)
            {
                UpdateBabySleep();
            }                   
    }
    private void UpdateEnergyBar(float value)
    {
        playerEnergyBar.fillAmount = value;
            if (value >= 1f)
            {
                if (energyBarIndex < playerEnergyBars.Count)
                {
                    energyBarIndex++;
                    EnableEnergyBar();
                if (gameType == GameType.Sleep)
                {
                    UpdateBabySleep();
                }
                if(gameType == GameType.Health)
                {
                    UpdateBabyHealth();
                }
                if (gameType == GameType.Playground)
                {
                    UpdateBabyFun();
                }
            }
               
            }
            else if (value <= 0f)
            {
                if (energyBarIndex > 0)
                {
                energyBarIndex--;
                ReduceEnergyBar();
                playerEnergyBar.fillAmount =1- value;
                targetEnergy = playerEnergyCapacity;

                if (gameType == GameType.Sleep)
                {
                    UpdateBabySleep();
                }
                if (gameType == GameType.Health)
                {
                    UpdateBabyHealth();
                }
                if (gameType == GameType.Playground)
                {
                    UpdateBabyFun();
                }
            }
                
            }
       
    }

    private void EnableEnergyBar()
    {
        foreach (Image i in playerEnergyBars)
        {
            i.enabled = false;
        }

        if(energyBarIndex >= playerEnergyBars.Count)
        {
            playerEnergyBars[energyBarIndex-1].enabled = true;
            remarkTxt.SetText(remarks[energyBarIndex-1]);
            remarkTxt.color = playerEnergyBars[energyBarIndex - 1].color;
            playerEnergyBar = playerEnergyBars[energyBarIndex-1];
        }
        else
        {
            playerEnergyBars[energyBarIndex].enabled = true;
            remarkTxt.SetText(remarks[energyBarIndex]);
            remarkTxt.color = playerEnergyBars[energyBarIndex].color;

            playerEnergyBar = playerEnergyBars[energyBarIndex];
        }
     
        playerEnergyBar.fillAmount = 0;
        //playerEnergyCapacity += energyCapTemp;
       // playerEnergyCapacity = energyCapTemp* (Mathf.Max(energyBarIndex,1));
        //playeren
    }

    private void ReduceEnergyBar()
    {
        foreach (Image i in playerEnergyBars)
        {
            i.enabled = false;
        }
        playerEnergyBars[energyBarIndex].enabled = true;
        remarkTxt.SetText(remarks[energyBarIndex]);
        remarkTxt.color = playerEnergyBars[energyBarIndex].color;

        playerEnergyBar = playerEnergyBars[energyBarIndex];
        playerEnergyBar.fillAmount = 0;
        //playerEnergyCapacity -= energyCapTemp;
    }
    #endregion

}
