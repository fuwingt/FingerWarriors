using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject _globalManager;
    public ObjectGenerator objectGenerator;
    public GameObject timeCountdownBar;

    void Start()
    {
        objectGenerator.generateHeros();
        objectGenerator.generateMonster();


        GlobalManager.currentEnemy = GlobalManager.monsterList[0];
    }

    void Update()
    {
        EnemyStatusUpdate(GlobalManager.currentEnemy);

    }

    private void EnemyStatusUpdate(GameObject currentEnemy)
    {
        /* If the current monster has been taken down */
        if (currentEnemy.GetComponent<Monster>().getHp() <= 0 && !timeCountdownBar.GetComponent<TimeCountdownBar>().isTimeOver)
        {
            /* If the player is already in the boss stage */
            if (_globalManager.GetComponent<GlobalManager>().stage != 0 && _globalManager.GetComponent<GlobalManager>().stage % 10 == 0)
            {
                /* Boss has been defeated, hide and reset the countdown bar */
                timeCountdownBar.SetActive(false);
                timeCountdownBar.transform.GetChild(0).gameObject.SetActive(false);
                timeCountdownBar.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                timeCountdownBar.GetComponent<TimeCountdownBar>().Reset();
            }
            /* (Change to next monster)#Reset monster's hp */
            currentEnemy.GetComponent<Monster>().setMaxHp(currentEnemy.GetComponent<Monster>().getBasicHp() * _globalManager.GetComponent<GlobalManager>().getMonsterHpRate());
            currentEnemy.GetComponent<Monster>().setHp(currentEnemy.GetComponent<Monster>().getBasicHp() * _globalManager.GetComponent<GlobalManager>().getMonsterHpRate());
            /* Get gold */
            GlobalManager.setGold(GlobalManager.getGold() + 10);
            /* #Debug: Reborn */
            currentEnemy.GetComponent<Monster>().Reborn();
            _globalManager.GetComponent<GlobalManager>().stage++;
            /* #Go into Boss stage after each 10 stage */
            if (_globalManager.GetComponent<GlobalManager>().stage != 0 && _globalManager.GetComponent<GlobalManager>().stage % 10 == 0)
            {
                /* #Hp upgrade */
                currentEnemy.GetComponent<Monster>().setMaxHp(currentEnemy.GetComponent<Monster>().getBasicHp() * 2.2f);
                currentEnemy.GetComponent<Monster>().setHp(currentEnemy.GetComponent<Monster>().getBasicHp() * 2.2f);
                /* #Time countdown bar show up */
                timeCountdownBar.SetActive(true);
                timeCountdownBar.transform.GetChild(0).gameObject.SetActive(true);
                timeCountdownBar.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            }
        }
        else if (timeCountdownBar.GetComponent<TimeCountdownBar>().isTimeOver)
        {
            /* Reset monster's hp */
            currentEnemy.GetComponent<Monster>().setMaxHp(currentEnemy.GetComponent<Monster>().getBasicHp() * _globalManager.GetComponent<GlobalManager>().getMonsterHpRate());
            currentEnemy.GetComponent<Monster>().setHp(currentEnemy.GetComponent<Monster>().getBasicHp() * _globalManager.GetComponent<GlobalManager>().getMonsterHpRate());
            /* #Debug: Reborn the monster in previous stage */
            currentEnemy.GetComponent<Monster>().Reborn();
            _globalManager.GetComponent<GlobalManager>().stage--;
            /* Reset timer */
            timeCountdownBar.GetComponent<TimeCountdownBar>().Reset();
        }
    }


}
