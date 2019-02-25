using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountdownBar : MonoBehaviour 
{
	[SerializeField ]private Image timeCountdownBar;
	private float timer;
	private float timeDuration;
	public bool isTimeOver;
	
	public void Reset()
	{
		timeDuration = 5f;
		timer = timeDuration;
		isTimeOver = false;
	}

	void Start()
	{
		//timeCountdownBar = GetComponent<Image>();
		timeDuration = 5f;
		timer = timeDuration;
		isTimeOver = false;
	}
	void Update () 
	{
		if(timer >= 0)
		{
			timer -= Time.deltaTime;
			timeCountdownBar.fillAmount = timer / timeDuration;
		}else
		{
			gameObject.SetActive(false);
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
			gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
			isTimeOver = true;
		}
		
	}
}
