using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour 
{
	public GameObject _globalManager;
	public GameObject item;

	void Start () 
	{

	}
	
	void Update () 
	{
		int diff = GlobalManager.heroList.Count - _globalManager.GetComponent<GlobalManager>().itemCount;
		if(diff != 0)
		{
			for(int i=0;i<diff;i++)
			{
				GameObject newItem = Instantiate(item, this.transform);
				newItem.name = item.name;
				_globalManager.GetComponent<GlobalManager>().itemCount++;
			}
		}
	}
}
