using System.Collections;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour 
{
	[Header("Field")]
	public GameObject Field_1;
	public GameObject Field_2;
	public GameObject Extra;

	[Header("Hero")]
	public GameObject Amon;
	public GameObject Test01;
	[Header("Monster")]
	public GameObject Smile;
	[Header("Item")]
	public GameObject UpgradeHeroItem;
	[Header("Parent")]
	public GameObject ScrollPanel;


	public void generateHeros()
	{
		//	First Character
		Amon = Instantiate(Amon) as GameObject;
		setHeroValue(Amon, Field_1, "Amon", 10, 35, 100, Character.Element.Fire, 1, true);

		Test01 = Instantiate(Test01) as GameObject;
		setHeroValue(Test01, Extra, "Test01", 10, 30, 500, Character.Element.Wind, 0, false);

		for(int i=0;i<GlobalManager.heroList.Count;i++)
		{
			createUpgradeItem(GlobalManager.heroList[i]);
		}
	}

	public void generateMonster()
	{
		//	First Monster
		Smile = Instantiate(Smile) as GameObject;
		setMonsterValue(Smile, "Smile", 100, Character.Element.Water);
	}

	private void createUpgradeItem(GameObject hero)
	{
		UpgradeHeroItem = Instantiate(UpgradeHeroItem, ScrollPanel.transform);
		UpgradeHeroItem.name = "Item";
		UpgradeHeroItem.GetComponentInChildren<UpgradeHeroItem>().setHero(hero);
	}

	private void setHeroValue(GameObject hero, GameObject position, string name, float power, float skillPower_1, float price, Character.Element type, int level, bool active)
	{
		hero.GetComponent<Hero>().setName(name);
		hero.transform.SetParent(position.transform);
		hero.GetComponent<Hero>().setPower(power);
		hero.GetComponent<Hero>().setSkillPower_1(skillPower_1);
		hero.GetComponent<Hero>().setPrice(price);
		hero.GetComponent<Hero>().setElement(type);
		hero.GetComponent<Hero>().setLevel(level);
		hero.SetActive(active);
		
		GlobalManager.heroList.Add(hero);

	}

	private void setMonsterValue(GameObject monster, string name, float hp, Character.Element type)
	{
		monster.GetComponent<Monster>().setName(name);
		monster.GetComponent<Monster>().setHp(hp);
		monster.GetComponent<Monster>().setMaxHp(hp);
		monster.GetComponent<Monster>().setBasicHp(hp);
		monster.GetComponent<Monster>().setElement(type);
		GlobalManager.monsterList.Add(monster);
	}
}
