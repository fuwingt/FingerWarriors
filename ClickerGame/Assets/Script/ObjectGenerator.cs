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
        setHeroValue(Amon, Field_1, "Amon", 10, 35, 100, Character.Element.Fire, 1, Hero.Type.Melee, 50, 1,
                    "FireSlash",
                    "Make damage with Fire skill power x 3.",
                    "Attack of All the heroes in front x 1.5.",
                    true, icon_Amon);
        Field_1.GetComponent<Field>().activateSkillButton();
        Amon.GetComponent<Hero>().PassiveSkill(true);
        Amon.GetComponent<Hero>().isOnField = true;
        //  Other hero
        Freyr = Instantiate(Freyr) as GameObject;
        setHeroValue(Freyr, Extra, "Freyr", 10, 30, 500, Character.Element.Water, 0, Hero.Type.Ranged, 30, 3,
                    "Freeze",
                    "Make damage with Water skill power. Stop the time 2 sec in Boss stage.",
                    "Attack of All the heroes in back x 1.2", false, icon_Amon);

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

    }

    private void createUpgradeItem(GameObject hero)
    {
        HeroItemPrefab = Instantiate(HeroItemPrefab, heroPanel.transform);
        HeroItemPrefab.name = "Item";
        HeroItemPrefab.GetComponentInChildren<HeroItem>().setHero(hero.GetComponent<Hero>());
    }



    private void setHeroValue(GameObject hero, GameObject parentField, string name, float power,
                                float skillPower, float price, Character.Element element, int level,
                                Hero.Type type, float requiredEnergy, float energyPerAttack,
                                string skill, string activeSkillDesc, string passiveSkillDesc, bool active, Sprite icon)
    {
        hero.transform.SetParent(parentField.transform);

        Hero h = hero.GetComponent<Hero>();
        h.setName(name);
        h.setPower(power);
        h.setSkillPower(skillPower);
        h.setPrice(price);
        h.setElement(element);
        h.setLevel(level);
        h.setType(type);
        h.setRequiredEnergy(requiredEnergy);
        h.setEnergyPerAttack(energyPerAttack);
        h.setSkill(skill);
        h.setActiveSkillDesc(activeSkillDesc);
        h.setPassiveSkillDesc(passiveSkillDesc);
        h.Icon = icon;
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
        monster.transform.SetParent(MonsterField.transform);
        MonsterManager.monsterList.Add(monster);
    }

}
