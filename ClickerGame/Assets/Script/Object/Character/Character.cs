using UnityEngine;

public class Character : MonoBehaviour 
{	
	public enum Element
	{
		Fire,
		Water,
		Wind,
		Light,
		Dark
	}
	[SerializeField] private new string name;
	[SerializeField] private Element element = Element.Fire;
		
	public string getName()
	{
		return name;
	}

	public Element getElement()
	{
		return element;
	}

	public void setName(string name)
	{
		this.name = name;
	}

	public void setElement(Element element)
	{
		this.element = element;
	}

	

}
