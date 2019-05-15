using System.Collections;
using UnityEngine;
using Skills;

public class Hero : Character
{
    //  Public
    public enum Type
    {
        Melee,
        Ranged
    }

    public Sprite Icon;
    public Sprite ElementBorder;
    public GameObject SkillObjectPrefab;
    public GameObject currentEquipment = null;
    public float fieldBuff = 1;
    public bool isOnField = false;
    public int currentFieldID = 6;
    //  Private

    // Private string
    [SerializeField] private string activeSkill;
    [SerializeField] private string passiveSkill;
    [SerializeField] private string activeSkillDesc;
    [SerializeField] private string passiveSkillDesc;
    //  Private int
    private int id;
    [SerializeField] private int level;
    [SerializeField] private int upgradeCount;
    //  Private float
    [SerializeField] private float atk = 1;
    [SerializeField] private float extraAtk = 1;
    [SerializeField] private float atkRate = 1;
    [SerializeField] private float skillPower = 1;
    [SerializeField] private float extraSkillPower = 1;
    [SerializeField] private float skillPowerRate = 1;
    [SerializeField] private float requiredEnergy;
    [SerializeField] private float energyPerAttack;
    [SerializeField] private float price;
    //  Others
    private Type type;
    private GlobalManager globalManager;
    private MonsterManager monsterManager;
    private SkillManager skillManager;
    private GameObject monsterPanel;

    void Start()
    {
        globalManager = GameObject.Find("GlobalManager").GetComponent<GlobalManager>();
        monsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        monsterPanel = GameObject.Find("MonsterPanel").gameObject;
    }

    public void ActiveSkill()
    {
        float result = ElementEffect(getElement(), GlobalManager.currentEnemy.GetComponent<Monster>().getElement(), skillPower + extraSkillPower);

        skillManager.TurnOnActiveSkill(activeSkill, result);
    }

    public void PassiveSkill(bool isActivated)
    {
        float buffRate = 1.5f;
        if (skillManager == null) skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();

        skillManager.TurnOnPassiveSkill(passiveSkill, buffRate, isActivated);
    }


    public float Attack(GameObject monster)
    {

        // Calculate the damage result with element and Critical chance
        float result = ElementEffect(getElement(), monster.GetComponent<Monster>().getElement(), CalculateDamage(atk, extraAtk, atkRate, fieldBuff));

        // Animaition
        transform.GetComponent<Animator>().SetTrigger("isAttack");

        globalManager.setEnergy(globalManager.getEnergy() + energyPerAttack);

        Debug.Log(getName() + ": making damage " + result + " to enemy " + monster.GetComponent<Monster>().getName());

        return result;
    }

    public void SuitUp(GameObject Equipment)
    {
        currentEquipment = Equipment;
        currentEquipment.GetComponent<Equipment>().EquipmentEffect(gameObject);
        currentEquipment.GetComponent<Equipment>().isEquiped = true;
        currentEquipment.GetComponent<Equipment>().ownerId = id;
        currentEquipment.GetComponent<Equipment>().owner = gameObject;
    }

    public void PeelOff()
    {
        if (currentEquipment != null)
        {
            currentEquipment.GetComponent<Equipment>().ownerId = -1;
            currentEquipment.GetComponent<Equipment>().owner = null;
            currentEquipment.GetComponent<Equipment>().isEquiped = false;
            extraAtk = 0; extraSkillPower = 0;
            currentEquipment = null;
        }
    }

    protected float ElementEffect(Character.Element heroElement, Character.Element monsterElement, float power)
    {
        float _result = power;
        if (heroElement == Character.Element.Fire)
        {
            /* Strong against with Wind */
            /* Weak against with Water */
            if (monsterElement == Character.Element.Wind)
            {
                _result *= 2;
            }

            if (monsterElement == Character.Element.Water)
            {
                _result *= 0.5f;
            }
        }
        if (heroElement == Character.Element.Water)
        {
            /* Strong against with Fire */
            /* Weak against with Wind */
            if (monsterElement == Character.Element.Fire)
            {
                _result *= 2;
            }

            if (monsterElement == Character.Element.Wind)
            {
                _result *= 0.5f;
            }
        }
        if (heroElement == Character.Element.Wind)
        {
            /* Strong against with Water */
            /* Weak against with Fire */
            if (monsterElement == Character.Element.Water)
            {
                _result *= 2;
            }

            if (monsterElement == Character.Element.Fire)
            {
                _result *= 0.5f;
            }
        }
        if (heroElement == Character.Element.Light)
        {
            /* Strong against with Dark */
            /* Weak against with itself */
            if (monsterElement == Character.Element.Dark)
            {
                _result *= 2;
            }

            if (monsterElement == Character.Element.Light)
            {
                _result *= 0.5f;
            }
        }
        if (heroElement == Character.Element.Dark)
        {
            /* Strong against with Light */
            /* Weak against with itself */
            if (monsterElement == Character.Element.Light)
            {
                _result *= 2;
            }

            if (monsterElement == Character.Element.Dark)
            {
                _result *= 0.5f;
            }
        }

        return _result;
    }

    protected float CalculateDamage(float power, float extraPower, float powerRatio, float fieldBuff)
    {
        float result;
        float randValue = Random.Range(0, 100);

        result = (power + extraPower) * powerRatio * fieldBuff;

        return result;
    }

    //  Getter
    public float getSkillPower()
    {
        return skillPower;
    }

    public float getAtk()
    {
        return atk;
    }

    public float getExtraAtk()
    {
        return extraAtk;
    }

    public float getExtraSkillPower()
    {
        return extraSkillPower;
    }

    public float getPrice()
    {
        return price;
    }

    public float getAtkRate()
    {
        return atkRate;
    }

    public float getSkillPowerRate()
    {
        return skillPowerRate;
    }

    public int getLevel()
    {
        return level;
    }

    public int getUpgradeCount()
    {
        return upgradeCount;
    }

    public int getId()
    {
        return id;
    }

    public string getActiveSkillDesc()
    {
        return activeSkillDesc;
    }

    public string getPassiveSkillDesc()
    {
        return passiveSkillDesc;
    }

    public string getActiveSkill()
    {
        return activeSkill;
    }
    public string getPassiveSkill()
    {
        return passiveSkill;
    }

    public Type getType()
    {
        return type;
    }

    public float getRequiredEnergy()
    {
        return requiredEnergy;
    }

    public float getEnergyPerAttack()
    {
        return energyPerAttack;
    }

    //  Setter
    public void setSkillPower(float skillPower)
    {
        this.skillPower = skillPower;
    }

    public void setAtk(float atk)
    {
        this.atk = atk;
    }

    public void setExtraAtk(float extraAtk)
    {
        this.extraAtk = extraAtk;
    }

    public void setExtraSkillPower(float extraSkillPower)
    {
        this.extraSkillPower = extraSkillPower;
    }

    public void setPrice(float price)
    {
        this.price = price;
    }

    public void setLevel(int level)
    {
        this.level = level;
    }

    public void setUpgradeCount(int upgradeCount)
    {
        this.upgradeCount = upgradeCount;
    }

    public void setAtkRate(float atkRate)
    {
        this.atkRate = atkRate;
    }

    public void setSkillPowerRate(float skillPowerRate)
    {
        this.skillPowerRate = skillPowerRate;
    }

    public void setActiveSkill(string activeSkill)
    {
        this.activeSkill = activeSkill;
    }

    public void setPassiveSkill(string passiveSkill)
    {
        this.passiveSkill = passiveSkill;
    }

    public void setActiveSkillDesc(string activeSkillDesc)
    {
        this.activeSkillDesc = activeSkillDesc;
    }

    public void setPassiveSkillDesc(string passiveSkillDesc)
    {
        this.passiveSkillDesc = passiveSkillDesc;
    }

    public void setType(Type type)
    {
        this.type = type;
    }

    public void setRequiredEnergy(float requiredEnergy)
    {
        this.requiredEnergy = requiredEnergy;
    }

    public void setEnergyPerAttack(float energyPerAttack)
    {
        this.energyPerAttack = energyPerAttack;
    }

    public void setId(int id)
    {
        this.id = id;
    }


}
