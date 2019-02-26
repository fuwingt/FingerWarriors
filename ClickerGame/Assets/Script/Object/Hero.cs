using UnityEngine;

public abstract class Hero : Character 
{
	[HideInInspector] public  bool isOwned;
	[SerializeField] protected float skillPower_1;
	[SerializeField] private float power;
	[SerializeField] private float price;
	[SerializeField] private int level;
	
	private int upgradeCount;

	public void Attack(GameObject monster)
	{
		if(monster != null)
		{
				/* Considering the type */
				float result = TypeEffect(getType(),monster.GetComponent<Monster>().getType(),power);
				/* Do damage */
				monster.GetComponent<Monster>().setHp(monster.GetComponent<Monster>().getHp() - result);

				Debug.Log(getName() + ": making damage " + result + " to enemy " + monster.GetComponent<Monster>().getName());
		}
	}

	public abstract void Skill_1(GameObject monster);

	protected float TypeEffect(Character.Type heroType, Character.Type monsterType, float power)
	{
		float _result = power;
		if(heroType == Character.Type.Fire)
		{
			/* Strong against with Wind */
			/* Weak against with Water */
			if(monsterType == Character.Type.Wind)
			{
				_result *= 2;
			}

			if(monsterType == Character.Type.Water)
			{
				_result *= 0.5f;
			}
		}
		if(heroType == Character.Type.Water)
		{
			/* Strong against with Fire */
			/* Weak against with Wind */
			if(monsterType == Character.Type.Fire)
			{
				_result *= 2;
			}

			if(monsterType == Character.Type.Wind)
			{
				_result *= 0.5f;
			}
		}
		if(heroType == Character.Type.Wind)
		{
			/* Strong against with Water */
			/* Weak against with Fire */
			if(monsterType == Character.Type.Water)
			{
				_result *= 2;
			}

			if(monsterType == Character.Type.Fire)
			{
				_result *= 0.5f;
			}
		}
		if(heroType == Character.Type.Light)
		{
			/* Strong against with Dark */
			/* Weak against with itself */
			if(monsterType == Character.Type.Dark)
			{
				_result *= 2;
			}

			if(monsterType == Character.Type.Light)
			{
				_result *= 0.5f;
			}
		}
		if(heroType == Character.Type.Dark)
		{
			/* Strong against with Light */
			/* Weak against with itself */
			if(monsterType == Character.Type.Light)
			{
				_result *= 2;
			}

			if(monsterType == Character.Type.Dark)
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
