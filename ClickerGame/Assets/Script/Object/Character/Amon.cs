using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amon : Hero
{

	public override void Skill_1(GameObject monster)
	{
		if(monster != null)
		{
			float result = TypeEffect(getType(), monster.GetComponent<Monster>().getType(), skillPower_1);

			monster.GetComponent<Monster>().setHp(monster.GetComponent<Monster>().getHp() - skillPower_1);

			Debug.Log(getName() + ": making damage " + result + " to enemy " + monster.GetComponent<Monster>().getName());
		}
	}

}
