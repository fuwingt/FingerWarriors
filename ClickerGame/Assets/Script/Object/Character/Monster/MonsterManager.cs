using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static List<GameObject> monsterList = new List<GameObject>();

    public GlobalManager globalManager;
    public GameObject MonsterField;
    public GameObject MonsterExtraField;
    public GameObject timeCountdownBar;
    public float normalHpRate = 1;
    public float bossHpRate = 10;

    private GameObject currentMonster;
    public bool isBossStage = false;
    public bool isFarming = false;

    void Start()
    {

    }

    void Update()
    {
        StatusUpdate();
        if (isBossStage)
            BossStageUpdate();
    }

    private void StatusUpdate()
    {
        //	Assign current monster
        if (MonsterField.transform.childCount != 0 && currentMonster == null)
        {
            currentMonster = MonsterField.transform.GetChild(0).gameObject;
        }

        if (currentMonster == null) return;

        //	Check Death
        if (currentMonster.GetComponent<Monster>().getHp() <= 0)
        {
            currentMonster.GetComponent<Monster>().Death();

            if (!isFarming) globalManager.stage++;

            //	If player beat the boss
            if (isBossStage)
            {
                timeCountdownBar.SetActive(false);
                timeCountdownBar.transform.GetChild(0).gameObject.SetActive(false);
                timeCountdownBar.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                timeCountdownBar.GetComponent<TimeCountdownBar>().Reset();
            }
            //	Entry next stage after monster dead
            if (globalManager.stage % 10 == 0 && globalManager.stage != 0)
                isBossStage = true;
            else
                isBossStage = false;

            //	Change next monster for next stage
            NextMonster();

            EntryBossStage(isBossStage);
        }
    }

    public void EntryBossStage(bool isBossStage)
    {
        if (isBossStage)
        {
            //	Show Time countdown bar
            timeCountdownBar.SetActive(true);
            timeCountdownBar.transform.GetChild(0).gameObject.SetActive(true);
            timeCountdownBar.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }

    }

    private void BossStageUpdate()
    {
        // If player cannot beat the monster within the limitied time, 
        //	go back to last stage and change another monster from monsterlist
        if (timeCountdownBar.GetComponent<TimeCountdownBar>().isTimeOver)
        {
            globalManager.stage--;
            isBossStage = false;
            isFarming = true;
            timeCountdownBar.GetComponent<TimeCountdownBar>().Reset();
            NextMonster();
        }

    }

    public void NextMonster()
    {
        //	Move the current monster to extra field
        currentMonster.transform.SetParent(MonsterExtraField.transform);
        currentMonster.SetActive(false);

        //	Random choose one of the monster from the list
        currentMonster = monsterList[Random.Range(0, monsterList.Count - 1)];
        currentMonster.transform.SetParent(MonsterField.transform);
        currentMonster.SetActive(true);
        currentMonster.GetComponent<Monster>().Init();
    }

    public GameObject GetCurrentMonster()
    {
        return currentMonster;
    }




}
