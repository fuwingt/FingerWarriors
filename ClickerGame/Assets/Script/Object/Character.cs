using UnityEngine;

public class Character : MonoBehaviour 
{	
	public enum Type
	{
		Fire,
		Water,
		Wind,
		Light,
		Dark
	}
	[SerializeField] private new string name;
	[SerializeField] private Type type = Type.Fire;
		
	public string getName()
	{
		return name;
	}

	public Type getType()
	{
		return type;
	}

	public void setName(string name)
	{
		this.name = name;
	}

	public void setType(Type type)
	{
		this.type = type;
	}

	

}
