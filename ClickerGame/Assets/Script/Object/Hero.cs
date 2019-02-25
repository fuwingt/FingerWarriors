using UnityEngine;

public class Hero : Character 
{
	public  bool isOwned;
	private float power;
	private float price;
	private int level;
	private int upgradeCount;

	public void Attack(GameObject monster)
	{
		if(monster != null)
		{
				monster.GetComponent<Monster>().setHp(monster.GetComponent<Monster>().getHp() - power);
				Debug.Log("HP: " + monster.GetComponent<Monster>().getHp());
		}
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
