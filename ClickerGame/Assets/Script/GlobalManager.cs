using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour
{
    /* Store all the heroes */
    public static List<GameObject> heroList = new List<GameObject>();
    /* Store all the monsters */
    public static List<GameObject> currentHeroes = new List<GameObject>();
    public static GameObject currentEnemy;
    public static GameObject currentPet;
    public static float gold10xChance = 10;
    public static float bossHpRatio = 10;
    public static bool isInfoPanelOpen = false;
    public static int tapCount = 0;

    public static GameObject[] FieldArray = new GameObject[6];
    [Header("Field")]
    public GameObject Field1;
    public GameObject Field2;
    public GameObject Field3;
    public GameObject Field4;
    public GameObject Field5;
    public GameObject Field6;


    public Text InfoBoard;
    public int itemCount;
    public int stage;

    /* monster's HP would be increase in each 10 stage by monsterHpRate */
    private float monsterHpRate;
    private float maxEnergy;
    private float energy;
    private string playerName;
    private static float gold = 500;
    private static float bossTimeDuration;

    void Start()
    {
        // Default value for beginning
        itemCount = 0;
        monsterHpRate = 1;
        maxEnergy = 100;
        energy = maxEnergy;

        FieldArray[0] = Field1;
        FieldArray[1] = Field2;
        FieldArray[2] = Field3;
        FieldArray[3] = Field4;
        FieldArray[4] = Field5;
        FieldArray[5] = Field6;
    }

    void Update()
    {
        UpdateInfoBoard();
    }

    private void UpdateInfoBoard()
    {
        InfoBoard.text = "Stage: " + stage
                        + "\nGold: " + gold;
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

    public float getMonsterHpRate()
    {
        return monsterHpRate;
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

    public void setMonsterHpRate(float monsterHpRate)
    {
        this.monsterHpRate = monsterHpRate;
    }
}
