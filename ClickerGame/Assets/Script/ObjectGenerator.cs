using System.Collections;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [Header("Field")]
    public GameObject Field_1;
    public GameObject Field_2;
    public GameObject Extra;
    public GameObject MonsterField;
    public GameObject PetExtraField;

    [Header("Hero")]
    public GameObject Amon;
    public GameObject Freyr;
    [Header("Monster")]
    public GameObject Smile;
    [Header("Pet")]
    public GameObject Rah;
    [Header("Item")]
    public GameObject HeroItemPrefab;
    public GameObject PetItemPrefab;
    [Header("Icon")]
    public Sprite icon_Amon;
    public Sprite icon_1;
    public Sprite icon_2;
    public Sprite icon_3;
    public Sprite icon_4;

    [Header("Parent")]
    public GameObject heroPanel;
    public GameObject petPanel;


    public void generateHeroes()
    {
        //	First hero  
        Amon = Instantiate(Amon) as GameObject;
        setHeroValue(Amon, Field_1, "Amon", 10, 35, 100, Character.Element.Fire, 1, true, icon_Amon);
        Field_1.GetComponent<Field>().activateSkillButton();
        //  Other hero
        Freyr = Instantiate(Freyr) as GameObject;
        setHeroValue(Freyr, Extra, "Freyr", 10, 30, 500, Character.Element.Water, 0, false, icon_Amon);
        //  Upgrade column for each hero
        for (int i = 0; i < GlobalManager.heroList.Count; i++)
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

    public void generatePet()
    {
        Rah = Instantiate(Rah, PetExtraField.transform, false) as GameObject;
        //createPetItem(Rah);
        //Rah.SetActive(false);
    }


    private void createUpgradeItem(GameObject hero)
    {
        HeroItemPrefab = Instantiate(HeroItemPrefab, heroPanel.transform);
        HeroItemPrefab.name = "Item";
        HeroItemPrefab.GetComponentInChildren<UpgradeHeroItem>().setHero(hero);
        HeroItemPrefab.GetComponentInChildren<SwitchField>().setHero(hero);
    }



    private void setHeroValue(GameObject hero, GameObject parentField, string name, float power, float skillPower_1, float price, Character.Element type, int level, bool active, Sprite icon)
    {
        hero.GetComponent<Hero>().setName(name);
        hero.transform.SetParent(parentField.transform);
        hero.GetComponent<Hero>().setPower(power);
        hero.GetComponent<Hero>().setSkillPower(skillPower_1);
        hero.GetComponent<Hero>().setPrice(price);
        hero.GetComponent<Hero>().setElement(type);
        hero.GetComponent<Hero>().setLevel(level);
        hero.SetActive(active);
        hero.GetComponent<Hero>().Icon = icon;

        GlobalManager.heroList.Add(hero);

    }

    private void setMonsterValue(GameObject monster, string name, float hp, Character.Element type)
    {
        monster.GetComponent<Monster>().setName(name);
        monster.GetComponent<Monster>().setHp(hp);
        monster.GetComponent<Monster>().setMaxHp(hp);
        monster.GetComponent<Monster>().setBasicHp(hp);
        monster.GetComponent<Monster>().setElement(type);
        monster.transform.SetParent(MonsterField.transform);
        GlobalManager.monsterList.Add(monster);
    }
}
