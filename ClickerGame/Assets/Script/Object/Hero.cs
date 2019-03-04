using UnityEngine;

public abstract class Hero : Character 
{
	public enum Type
	{
		Melee,
		Ranged
	}
	
	[HideInInspector] public  bool isOwned;
	[SerializeField] protected float skillPower_1;
	[SerializeField] private float power;
	[SerializeField] private float energy = 0;
	[SerializeField] private float price;
	[SerializeField] private int level;
	private float maxEnergy = 100;
	private int upgradeCount;

	public virtual void Attack(GameObject monster)
	{
		if(monster != null)
		{
				/* Considering the type */
				float result = TypeEffect(getElement(),monster.GetComponent<Monster>().getElement(),power);
				/* Do damage */
				monster.GetComponent<Monster>().setHp(monster.GetComponent<Monster>().getHp() - result);
				/* Add 10 Energy each attack */
				if(energy < maxEnergy)
				{
					energy += 10;
				}
				Debug.Log(getName() + ": making damage " + result + " to enemy " + monster.GetComponent<Monster>().getName());
		}
	}

	public abstract void Skill_1(GameObject monster);

	protected float TypeEffect(Character.Element heroElement, Character.Element monsterElement, float power)
	{
		float _result = power;
		if(heroElement == Character.Element.Fire)
		{
			/* Strong against with Wind */
			/* Weak against with Water */
			if(monsterElement == Character.Element.Wind)
			{
				_result *= 2;
			}

			if(monsterElement == Character.Element.Water)
			{
				_result *= 0.5f;
			}
		}
		if(heroElement == Character.Element.Water)
		{
			/* Strong against with Fire */
			/* Weak against with Wind */
			if(monsterElement == Character.Element.Fire)
			{
				_result *= 2;
			}

			if(monsterElement == Character.Element.Wind)
			{
				_result *= 0.5f;
			}
		}
		if(heroElement == Character.Element.Wind)
		{
			/* Strong against with Water */
			/* Weak against with Fire */
			if(monsterElement == Character.Element.Water)
			{
				_result *= 2;
			}

			if(monsterElement == Character.Element.Fire)
			{
				_result *= 0.5f;
			}
		}
		if(heroElement == Character.Element.Light)
		{
			/* Strong against with Dark */
			/* Weak against with itself */
			if(monsterElement == Character.Element.Dark)
			{
				_result *= 2;
			}

			if(monsterElement == Character.Element.Light)
			{
				_result *= 0.5f;
			}
		}
		if(heroElement == Character.Element.Dark)
		{
			/* Strong against with Light */
			/* Weak against with itself */
			if(monsterElement == Character.Element.Light)
			{
				_result *= 2;
			}

			if(monsterElement == Character.Element.Dark)
			{
				_result *= 0.5f;
			}
		}

		return _result;
	}

	public float getSkillPower_1()
	{
		return skillPower_1;
	}
	
	public float getPower()
	{
		return power;
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

	public void setSkillPower_1(float skillPower_1)
	{
		this.skillPower_1 = skillPower_1;
	}

	public void setPower(float power)
	{
		this.power = power;
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
