using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour {

	public GameObject _globalManager;
	private Image energyBar;
	private float maxEnergy;
	private float currentEnergy;

	void Start () {
		energyBar = GetComponent<Image>();
	}
	
	void Update () {
		if(GlobalManager.selectedHero != null)
		{
			energyBar.fillAmount = _globalManager.GetComponent<GlobalManager>().getEnergy() / _globalManager.GetComponent<GlobalManager>().getMaxEnergy();
		}
	}
}
