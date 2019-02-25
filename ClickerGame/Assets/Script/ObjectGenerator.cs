using System.Collections;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour 
{
	public GameObject Amon;
	public GameObject Smile;
	void Start () 
	{
		
		
	}
	
	void Update () 
	{
		
	}

	public void generateHeros()
	{
		//	First Character
		Amon = Instantiate(Amon) as GameObject;
		setHeroValue(Amon, "Amon", 10, 100);
	}

	public void generateMonster()
	{
		//	First Monster
		Smile = Instantiate(Smile) as GameObject;
		setMonsterValue(Smile, "Smile", 100);
	}
	private void setHeroValue(GameObject hero, string name, float power, float price)
	{
		hero.GetComponent<Hero>().setName(name);
		hero.GetComponent<Hero>().setPower(power);
		hero.GetComponent<Hero>().setPrice(price);
		GlobalManager.heroList.Add(hero);

	}

	private void setMonsterValue(GameObject monster, string name, float hp)
	{
		monster.GetComponent<Monster>().setName(name);
		monster.GetComponent<Monster>().setHp(hp);
		monster.GetComponent<Monster>().setMaxHp(hp);
		monster.GetComponent<Monster>().setBasicHp(hp);
		GlobalManager.monsterList.Add(monster);
	}

}
