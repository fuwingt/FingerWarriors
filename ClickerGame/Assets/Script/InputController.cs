using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 19/2/2019 - InputContorller should be control the input for the object which store in "current" list
				instead of a single object. */
public class InputController : MonoBehaviour 
{
	public GameObject _globalManager;

	void Update()
	{
		ScreenRayCast();
	}

	public void Click()
	{
		/* To record that how many times the player clicked */
		_globalManager.GetComponent<GlobalManager>().clickCount++;
		/* Attack animation will be triggered " */
		for(int i=0;i<GlobalManager.currentHeroes.Count;i++)
		{
			GlobalManager.currentHeroes[i].GetComponent<Animator>().SetTrigger("isAttack01");;
		}
		/*	# Click to deduct the HP from monster */
		for(int i=0;i<GlobalManager.currentHeroes.Count;i++)
		{
			GlobalManager.currentHeroes[i].GetComponent<Hero>().Attack(GlobalManager.currentEnemy);
		}
	}

	public void ScreenRayCast()
	{
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider != null)
			{
				// Click to select the hero
				//GlobalManager.selectedHero = hit.collider.transform.GetChild(0).gameObject;
				//Debug.Log("Target object: " + GlobalManager.selectedHero.name);
			}
		}
	}
}
