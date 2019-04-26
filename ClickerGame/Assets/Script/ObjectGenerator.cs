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
                    "AttackBuffFront",
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
                    "AttackBuffBack",
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
        setMonsterValue(Smile, "Smile", 100, Character.Element.Water, "LittleRecovery", 5, 5);
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
                                string activeSkill, string passiveSkill, string activeSkillDesc, string passiveSkillDesc, bool active, Sprite icon)
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
        h.setActiveSkill(activeSkill);
        h.setPassiveSkill(passiveSkill);
        h.setActiveSkillDesc(activeSkillDesc);
        h.setPassiveSkillDesc(passiveSkillDesc);
        h.Icon = icon;
        hero.SetActive(active);

        GlobalManager.heroList.Add(hero);

    }

    private void setMonsterValue(GameObject monster, string name, float hp, Character.Element type, string skill, float maxCoolDown, float coolDown)
    {
        Monster m = monster.GetComponent<Monster>();
        m.setName(name);
        m.setHp(hp);
        m.setMaxHp(hp);
        m.setBasicHp(hp);
        m.setElement(type);
        m.setSkill(skill);
        m.setMaxCoolDown(maxCoolDown);
        m.setCoolDown(coolDown);
        monster.transform.SetParent(MonsterField.transform);
        MonsterManager.monsterList.Add(monster);
    }

}
