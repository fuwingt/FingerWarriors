using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour 
{
	public GameObject Field;
	
	public Hero Hero;


	// Use this for initialization
	void Start () 
	{
		if(Field.transform.childCount != 0)
			Hero = Field.GetComponentInChildren<Hero>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Field.transform.childCount != 0)
		{

		}
	}
}
