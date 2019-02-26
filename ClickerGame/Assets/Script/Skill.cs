using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {

	
	void Update () {
		
	}

	public void activateSkill_1()
	{
			GlobalManager.selectedHero.GetComponent<Hero>().Skill_1(GlobalManager.currentEnemy);
	}
}
