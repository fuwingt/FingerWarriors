using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{

    public GameObject _globalManager;
    public GameObject EnergyText;
    private Image energyBar;

    void Start()
    {
        energyBar = GetComponent<Image>();
    }

    void Update()
    {
        EnergyText.GetComponent<TextMesh>().text = _globalManager.GetComponent<GlobalManager>().getEnergy() + "/" + _globalManager.GetComponent<GlobalManager>().getMaxEnergy();
        energyBar.fillAmount = _globalManager.GetComponent<GlobalManager>().getEnergy() / _globalManager.GetComponent<GlobalManager>().getMaxEnergy();
    }
}
