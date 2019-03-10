using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour 
{
	[HideInInspector] public Hero hero;

	public void activateSkill()
	{
			hero.Skill(GlobalManager.currentEnemy);
	}
}
