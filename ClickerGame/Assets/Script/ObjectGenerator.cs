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
		setHeroValue(Amon, "Amon", 10, 12, 100, Character.Type.Fire);
	}

	public void generateMonster()
	{
		//	First Monster
		Smile = Instantiate(Smile) as GameObject;
		setMonsterValue(Smile, "Smile", 100, Character.Type.Water);
	}
	private void setHeroValue(GameObject hero, string name, float power, float skillPower_1, float price, Character.Type type)
	{
		hero.GetComponent<Hero>().setName(name);
		hero.GetComponent<Hero>().setPower(power);
		hero.GetComponent<Hero>().setSkillPower_1(skillPower_1);
		hero.GetComponent<Hero>().setPrice(price);
		hero.GetComponent<Hero>().setType(type);
		GlobalManager.heroList.Add(hero);

	}

	private void setMonsterValue(GameObject monster, string name, float hp, Character.Type type)
	{
		monster.GetComponent<Monster>().setName(name);
		monster.GetComponent<Monster>().setHp(hp);
		monster.GetComponent<Monster>().setMaxHp(hp);
		monster.GetComponent<Monster>().setBasicHp(hp);
		monster.GetComponent<Monster>().setType(type);
		GlobalManager.monsterList.Add(monster);
	}

}
