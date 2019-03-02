using System.Collections;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour 
{
	[Header("Field")]
	public GameObject field_1;
	public GameObject field_2;
	[Header("Hero")]
	public GameObject Amon;
	public GameObject Test01;
	[Header("Monster")]
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
		setHeroValue(Amon, field_1, "Amon", 10, 35, 100, Character.Type.Fire);

		Test01 = Instantiate(Test01) as GameObject;
		setHeroValue(Test01, field_2, "Test01", 10, 30, 500, Character.Type.Wind);


	}

	public void generateMonster()
	{
		//	First Monster
		Smile = Instantiate(Smile) as GameObject;
		setMonsterValue(Smile, "Smile", 100, Character.Type.Water);
	}

	private void setHeroValue(GameObject hero, GameObject position, string name, float power, float skillPower_1, float price, Character.Type type)
	{
		hero.GetComponent<Hero>().setName(name);
		hero.transform.SetParent(position.transform);
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
