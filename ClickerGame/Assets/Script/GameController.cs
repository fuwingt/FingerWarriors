using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public ObjectGenerator objectGenerator;
	public GameObject timeCountdownBar;
	private bool isBossStagePassed;
	
	void Start () {
		objectGenerator.generateHeros();
		objectGenerator.generateHeros();
		objectGenerator.generateMonster();

		GlobalManager.currentHeros[0] = GlobalManager.heroList[0];
		GlobalManager.currentEnemy = GlobalManager.monsterList[0];

	}
	
	void Update () {
		EnemyStatusUpdate(GlobalManager.currentEnemy);
	}

	private void EnemyStatusUpdate(GameObject currentEnemy)
	{
		if(currentEnemy.GetComponent<Monster>().getHp() <= 0 && !timeCountdownBar.GetComponent<TimeCountdownBar>().isTimeOver)
		{	
			/* If the player is already in the boss stage */
			if(GlobalManager.getStage() != 0 && GlobalManager.getStage()%10 == 0)
			{
				timeCountdownBar.SetActive(false);
				timeCountdownBar.transform.GetChild(0).gameObject.SetActive(false);
				timeCountdownBar.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
				timeCountdownBar.GetComponent<TimeCountdownBar>().Reset();
			}
			/* Reset monster's hp */		
			currentEnemy.GetComponent<Monster>().setMaxHp(currentEnemy.GetComponent<Monster>().getBasicHp()*GlobalManager.monsterHpRate);
			currentEnemy.GetComponent<Monster>().setHp(currentEnemy.GetComponent<Monster>().getBasicHp()*GlobalManager.monsterHpRate);
			/* Get gold */
			GlobalManager.setGold(GlobalManager.getGold() + 10);
			/* #Debug: Reborn */
			currentEnemy.GetComponent<Monster>().Reborn();
			GlobalManager.setStage(GlobalManager.getStage() + 1);

			/* #Go into Boss stage after each 10 stage */
			if(GlobalManager.getStage() != 0 && GlobalManager.getStage()%10 == 0)
			{
				/* #Hp upgrade */
				currentEnemy.GetComponent<Monster>().setMaxHp(currentEnemy.GetComponent<Monster>().getBasicHp()*2.2f);
				currentEnemy.GetComponent<Monster>().setHp(currentEnemy.GetComponent<Monster>().getBasicHp()*2.2f);
				Debug.Log("Hi I am Here");
				/* #Time countdown bar show up */
				timeCountdownBar.SetActive(true);
				timeCountdownBar.transform.GetChild(0).gameObject.SetActive(true);
				timeCountdownBar.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
			}
		}else if(timeCountdownBar.GetComponent<TimeCountdownBar>().isTimeOver)
		{
			/* Reset monster's hp */		
			currentEnemy.GetComponent<Monster>().setMaxHp(currentEnemy.GetComponent<Monster>().getBasicHp()*GlobalManager.monsterHpRate);
			currentEnemy.GetComponent<Monster>().setHp(currentEnemy.GetComponent<Monster>().getBasicHp()*GlobalManager.monsterHpRate);
			/* #Debug: Reborn the monster in previous stage */
			currentEnemy.GetComponent<Monster>().Reborn();
			GlobalManager.setStage(GlobalManager.getStage() - 1);
			/* Reset timer */
			timeCountdownBar.GetComponent<TimeCountdownBar>().Reset();
		}
	}

	
}
