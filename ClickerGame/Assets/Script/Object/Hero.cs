using UnityEngine;

public abstract class Hero : Character
{
    public enum Type
    {
        Melee,
        Ranged
    }
    public Sprite Icon;
    public GameObject FloatingText;
    [SerializeField] protected float skillPower;
    [SerializeField] private float power;
    [SerializeField] private float extraPower = 0;
    [SerializeField] protected float extraSkillPower = 0;
    [SerializeField] private float energy = 0;
    [SerializeField] private float price;
    [SerializeField] private int level;
    [SerializeField] public GameObject currentEquipment = null;
    private float maxEnergy = 100;
    private int upgradeCount;

    public abstract void Skill(GameObject monster);

    public virtual void Attack(GameObject monster)
    {
        if (monster != null)
        {
            // Calculate the damage result with element
            float result = ElementEffect(getElement(), monster.GetComponent<Monster>().getElement(), power, extraPower);
            // Animaition
            transform.GetComponent<Animator>().SetTrigger("isAttack");
            // Do damage
            monster.GetComponent<Monster>().BeingAttacked(result);
            // Add 10 Energy each attack
            if (energy < maxEnergy)
            {
                energy += 10;
            }
            // Show damage by FloatingText
            ShowFloatingText(power);
            Debug.Log(getName() + ": making damage " + result + " to enemy " + monster.GetComponent<Monster>().getName());
        }
    }

    public void SuitUp(GameObject Equipment)
    {
        currentEquipment = Equipment;
        currentEquipment.GetComponent<Equipment>().EquipmentEffect(gameObject);
        currentEquipment.GetComponent<Equipment>().isEquiped = true;
        currentEquipment.GetComponent<Equipment>().User = gameObject;
    }

    public void PeelOff()
    {
        if (currentEquipment != null)
        {
            currentEquipment.GetComponent<Equipment>().User = gameObject;
            currentEquipment.GetComponent<Equipment>().isEquiped = false;
            extraPower = 0; extraSkillPower = 0;
            currentEquipment = null;
        }
    }


    protected void ShowFloatingText(float power)
    {
        var damageText = Instantiate(FloatingText, transform.position, Quaternion.identity, transform);
        damageText.GetComponent<TextMesh>().text = power.ToString();

    }

    protected float ElementEffect(Character.Element heroElement, Character.Element monsterElement, float power, float exPower)
    {
        float _result = power + exPower;
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

    public float getSkillPower()
    {
        return skillPower;
    }

    public float getPower()
    {
        return power;
    }

    public float getExtraPower()
    {
        return extraPower;
    }

    public float getExtraSkillPower()
    {
        return extraSkillPower;
    }

    public float getEnergy()
    {
        return energy;
    }

    public float getMaxEnergy()
    {
        return maxEnergy;
    }

    public float getPrice()
    {
        return price;
    }

    public int getLevel()
    {
        return level;
    }

    public int getUpgradeCount()
    {
        return upgradeCount;
    }

    public void setSkillPower(float skillPower)
    {
        this.skillPower = skillPower;
    }

    public void setPower(float power)
    {
        this.power = power;
    }

    public void setExtraPower(float extraPower)
    {
        this.extraPower = extraPower;
    }

    public void setExtraSkillPower(float extraSkillPower)
    {
        this.extraSkillPower = extraSkillPower;
    }

    public void setEnergy(float energy)
    {
        this.energy = energy;
    }

    public void setMaxEnergy(float maxEnergy)
    {
        this.maxEnergy = maxEnergy;
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
}
