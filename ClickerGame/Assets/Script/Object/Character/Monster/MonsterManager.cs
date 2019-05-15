using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{

    //  Objects
    public GlobalManager globalManager;
    public GameObject MonsterField;
    public GameObject MonsterExtraField;
    public GameObject timeCountdownBar;

    //  Public
    public static List<GameObject> monsterList = new List<GameObject>();
    public float normalHpRate = 1;
    public float bossHpRate = 10;
    public bool isBossStage = false;
    public bool isFarming = false;

    //  Private
    private GameObject currentEnemy;


    void Update()
    {
        StatusUpdate();
        if (isBossStage)
            BossStageUpdate();
    }

    private void StatusUpdate()
    {
        //	Assign current monster
        if (MonsterField.transform.childCount != 0 && currentEnemy == null)
        {
            currentEnemy = MonsterField.transform.GetChild(0).gameObject;
            GlobalManager.currentEnemy = currentEnemy;
        }

        if (currentEnemy == null) return;

        //	Check Death
        if (currentEnemy.GetComponent<Monster>().getHp() <= 0)
        {
            currentEnemy.GetComponent<Monster>().Death();

            if (!isFarming) globalManager.stage++;

            //	If player beat the boss
            if (isBossStage)
            {
                GlobalManager.bossTakenDownCount++;
                timeCountdownBar.SetActive(false);
                timeCountdownBar.transform.GetChild(0).gameObject.SetActive(false);
                timeCountdownBar.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                //  Reset
                timeCountdownBar.GetComponent<TimeCountdownBar>().Start();
                //  Enhance the normal monster
                normalHpRate *= 1.75f;
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
            timeCountdownBar.GetComponent<TimeCountdownBar>().Start();
            NextMonster();
        }

    }

    public void NextMonster()
    {
        //	Move the current monster to extra field
        currentEnemy.transform.SetParent(MonsterExtraField.transform);
        currentEnemy.SetActive(false);

        //	Random choose one of the monster from the list
        int r = Random.Range(0, monsterList.Count);
        //if (r == monsterList.Count) r = 0;
        Debug.Log("Hi , i am here, r = " + r);
        currentEnemy = monsterList[r];
        GlobalManager.currentEnemy = currentEnemy;

        currentEnemy.transform.SetParent(MonsterField.transform);
        currentEnemy.SetActive(true);
        currentEnemy.GetComponent<Monster>().Init();
    }







}
