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
	public static GameObject [] currentHeroes = new GameObject [5];
	public static GameObject currentEnemy;
	public static GameObject selectedHero;
	public static int itemCount;
	/* monster's HP would be increase in each 10 stage by monsterHpRate */
	public static float monsterHpRate;
	public Text InfoBoard;
	private static string playerName;
	private static int clickCount;
	private static float gold;
	private static int stage;
	private static float bossTimeDuration;

	void Start()
	{
		itemCount = 0;
		monsterHpRate = 1;
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
	public static string getName()
	{
		return playerName;
	}
	public static int getClickCount()
	{
		return clickCount;
	}

	public static float getGold()
	{
		return gold;
	}

	public static int getStage()
	{
		return stage;
	}

	/* Setter */
	public static void setPlayerName(string playerName)
	{
		GlobalManager.playerName = playerName;
	}

	public static void setClickCount(int clickCount)
	{
		GlobalManager.clickCount = clickCount;
	}

	public static void setGold(float gold)
	{
		GlobalManager.gold = gold;
	}

	public static void setStage(int stage)
	{
		GlobalManager.stage = stage;
	}
}
