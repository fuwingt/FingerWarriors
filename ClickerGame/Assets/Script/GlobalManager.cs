using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour 
{
	/* Store all the heroes */
	public static List<GameObject> heroList = new List<GameObject>();
	/* Store all the monsters */
	public static List<GameObject> monsterList = new List<GameObject>();
	public static List<GameObject> currentHeroes = new List<GameObject>();
	public static GameObject currentEnemy;
	public static GameObject selectedHero;
	
	public Text InfoBoard;
	public int itemCount;
	public int clickCount;
	public int stage;
	
	/* monster's HP would be increase in each 10 stage by monsterHpRate */
	private float monsterHpRate;
	private float maxEnergy;
	private float energy;
	private string playerName;
	private float gold;
	
	private static float bossTimeDuration;

	void Start()
	{
		// Default value for beginning
		itemCount = 0;
		monsterHpRate = 1;
		maxEnergy = 100;
		energy =  maxEnergy;
	}

	void Update()
	{
		UpdateInfoBoard();
	}

	private void UpdateInfoBoard()
	{
		InfoBoard.text = "Click: " + clickCount + "\nGold: " + gold + "\nStage: " + stage;
	}

	
	/* Getter */
	public string getName()
	{
		return playerName;
	}

	public float getGold()
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

	public void setGold(float gold)
	{
		this.gold = gold;
	}

	public void setMaxEnergy(float maxEnergy)
	{
		this.maxEnergy = maxEnergy;
	}

	public void setEnergy(float energy)
	{
		if(energy > maxEnergy)
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
