using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{
	private Image healthBar;
	private float maxHp;
	private float currentHp;

	void Start () {
		healthBar = GetComponent<Image>();
	}
	
	void Update () {
		if(GlobalManager.monsterList.Count!=0)
		{
			maxHp = GlobalManager.monsterList[0].GetComponent<Monster>().getMaxHp();
			currentHp = GlobalManager.monsterList[0].GetComponent<Monster>().getHp();
			healthBar.fillAmount = currentHp / maxHp;
		}
	}
}
