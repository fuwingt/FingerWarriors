using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour
{
    /* Store all the heroes */
    public static List<GameObject> heroList = new List<GameObject>();
    public static List<GameObject> petList = new List<GameObject>();
    /* Store all the monsters */
    public static GameObject currentEnemy;
    public static GameObject currentPet;
    public static float gold10xChance = 10;
    public static float bossHpRatio = 10;
    public static bool isInfoPanelOpen = false;
    public static int tapCount = 0;
    public static int bossTakenDownCount = 0;
    public static GameObject[] FieldArray = new GameObject[6];
    [Header("Field")]
    public GameObject Field1;
    public GameObject Field2;
    public GameObject Field3;
    public GameObject Field4;
    public GameObject Field5;
    public GameObject Field6;
    public InputController inputController;
    public Text Stagetext;
    public Text GoldText;
    public Text ATKInfo;
    public Text EnergyInfo;
    public Text CritRateInfo;
    public Text CritChanceInfo;
    public int itemCount;
    public int stage;

    /* monster's HP would be increase in each 10 stage by monsterHpRate */
    private float maxEnergy;
    private float energy;
    private string playerName;
    private static float gold = 500;

    void Start()
    {
        // Default value for beginning
        itemCount = 0;
        maxEnergy = 100;
        energy = maxEnergy;

        FieldArray[0] = Field1;
        FieldArray[1] = Field2;
        FieldArray[2] = Field3;
        FieldArray[3] = Field4;
        FieldArray[4] = Field5;
        FieldArray[5] = Field6;

        for (int i = 0; i < FieldArray.Length; i++)
        {
            FieldArray[i].GetComponent<Field>().ID = i;
        }
    }

    void Update()
    {
        UpdateInfo();
    }

    public static string NumberConverter(int value)
    {
        string convertedString = "";
        if (value >= 1000000000)
        {
            convertedString = (value / 1000000000f).ToString("f2") + "B";
        }
        else if (value >= 1000000)
        {
            convertedString = (value / 1000000f).ToString("f2") + "M";
        }
        else if (value >= 1000)
        {
            convertedString = (value / 1000f).ToString("f2") + "K";
        }
        else
            convertedString = value.ToString();

        return convertedString;
    }

    private void UpdateInfo()
    {
        int totalATK = 0;
        int totalEnergyPerClick = 0;
        for (int i = 0; i < FieldArray.Length; i++)
        {
            if (FieldArray[i].transform.childCount != 0)
            {
                totalATK += (int)FieldArray[i].GetComponentInChildren<Hero>().getAtk();
                totalEnergyPerClick += (int)FieldArray[i].GetComponentInChildren<Hero>().getEnergyPerAttack();
            }
        }

        Stagetext.text = "Stage: " + stage;
        GoldText.text = NumberConverter((int)gold);
        ATKInfo.text = "Basic ATK: \n" +
                        NumberConverter(totalATK);
        EnergyInfo.text = "Energy/Click: \n" +
                            NumberConverter(totalEnergyPerClick);
        CritRateInfo.text = "Crit Rate: \n" +
                            inputController.getCriticalRate() + "%";
        CritChanceInfo.text = "Crit Chance: \n" +
                            inputController.getCriticalChance() + "%";


    }


    /* Getter */
    public string getName()
    {
        return playerName;
    }

    public static float getGold()
    {
        return gold;
    }

    public float getMaxEnergy()
    {
        return maxEnergy;
    }

    public float getEnergy()
    {
        return energy;
    }

    /* Setter */
    public void setPlayerName(string playerName)
    {
        this.playerName = playerName;
    }

    public static void setGold(float gold)
    {
        GlobalManager.gold = gold;
    }

    public void setMaxEnergy(float maxEnergy)
    {
        this.maxEnergy = maxEnergy;
    }

    public void setEnergy(float energy)
    {
        if (energy > maxEnergy)
        {
            this.energy = maxEnergy;
        }
        else
        {
            this.energy = energy;
        }
    }

}
