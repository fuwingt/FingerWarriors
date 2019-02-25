using UnityEngine;

public class Monster : Character
{
	private float hp;
	private float maxHp;
	private float basicHp;

	public void Reborn()
	{
		hp = maxHp;
	}

	public float getHp()
	{
		return hp;
	}

	public float getMaxHp()
	{
		return maxHp;
	}

	public float getBasicHp()
	{
		return basicHp;
	}
	public void setHp(float hp)
	{
		this.hp = hp;
	}

	public void setMaxHp(float maxHp)
	{
		this.maxHp = maxHp;
	}

	public void setBasicHp(float basicHp)
	{
		this.basicHp = basicHp;
	}

	
}
