using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("BarColor")]
    public Sprite Sprite_Fire;
    public Sprite Sprite_Water;
    public Sprite Sprite_Wind;
    public Sprite Sprite_Light;
    public Sprite Sprite_Dark;
    [Header("Text")]
    public GameObject HpText;
    private Image healthBar;
    private float maxHp;
    private float currentHp;

    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    void Update()
    {
        if (GlobalManager.currentEnemy != null)
        {
            maxHp = GlobalManager.currentEnemy.GetComponent<Monster>().getMaxHp();
            currentHp = GlobalManager.currentEnemy.GetComponent<Monster>().getHp();
            ChangeBarColor();
            HpText.GetComponent<TextMesh>().text = currentHp.ToString();
            healthBar.fillAmount = currentHp / maxHp;
        }
        else
        {
            Debug.Log("GlobalManager.currentEnemy should not be null.");
        }
    }

    private void ChangeBarColor()
    {
        switch (GlobalManager.currentEnemy.GetComponent<Monster>().getElement())
        {
            case Character.Element.Fire:
                GetComponent<Image>().sprite = Sprite_Fire;
                break;
            case Character.Element.Water:
                GetComponent<Image>().sprite = Sprite_Water;
                break;
            case Character.Element.Wind:
                GetComponent<Image>().sprite = Sprite_Wind;
                break;
            case Character.Element.Light:
                GetComponent<Image>().sprite = Sprite_Light;
                break;
            case Character.Element.Dark:
                GetComponent<Image>().sprite = Sprite_Dark;
                break;
            default:
                Debug.Log("Error in switch case.");
                break;
        }
    }
}
