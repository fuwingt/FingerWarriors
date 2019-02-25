using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 19/2/2019 - InputContorller should be control the input for the object which store in "current" list
				instead of a single object. */
public class InputController : MonoBehaviour 
{
	private GameObject Amon;
	Animator animator;

	void Update()
	{
		if(Amon == null)
		{
			Amon = GlobalManager.heroList[0];
			animator = Amon.GetComponent<Animator>();
		}
	}

	public void Click()
	{
		/* To record that how many times the player clicked */
		GlobalManager.setClickCount(GlobalManager.getClickCount() + 1);
		/* Attack animation will be triggered " */
		animator.SetTrigger("isAttack01");
		/*	# Click to deduct the HP from monster */
		//GlobalManager.monsterList[0].GetComponent<Monster>().setHp(GlobalManager.monsterList[0].GetComponent<Monster>().getHp() - 10);

		GlobalManager.currentHeros[0].GetComponent<Hero>().Attack(GlobalManager.currentEnemy);
	}
}
