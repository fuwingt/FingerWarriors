using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("BarColor")]
    public Sprite BarSprite_Fire;
    public Sprite BarSprite_Water;
    public Sprite BarSprite_Wind;
    public Sprite BarSprite_Light;
    public Sprite BarSprite_Dark;

    [Header("Icon")]
    public Sprite IconSprite_Fire;
    public Sprite IconSprite_Water;
    public Sprite IconSprite_Wind;
    public Sprite IconSprite_Light;
    public Sprite IconSprite_Dark;

    [Header("Objects")]
    public Text HpText;
    public GameObject ElementIcon;

    private Image healthBar;
    private float maxHp;
    private float currentHp;

    void Start()
    {
        //healthBar = GetComponent<Image>();
    }

    void Update()
    {
        if (GlobalManager.currentEnemy != null)
        {
            maxHp = GlobalManager.currentEnemy.GetComponent<Monster>().getMaxHp();
            currentHp = GlobalManager.currentEnemy.GetComponent<Monster>().getHp();
            ChangeBarColor();
            HpText.text = currentHp.ToString();
            GetComponent<Image>().fillAmount = currentHp / maxHp;
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
                GetComponent<Image>().sprite = BarSprite_Fire;
                ElementIcon.GetComponent<Image>().sprite = IconSprite_Fire;
                break;
            case Character.Element.Water:
                GetComponent<Image>().sprite = BarSprite_Water;
                ElementIcon.GetComponent<Image>().sprite = IconSprite_Water;

                break;
            case Character.Element.Wind:
                GetComponent<Image>().sprite = BarSprite_Wind;
                ElementIcon.GetComponent<Image>().sprite = IconSprite_Wind;
                break;
            case Character.Element.Light:
                GetComponent<Image>().sprite = BarSprite_Light;
                ElementIcon.GetComponent<Image>().sprite = IconSprite_Light;
                break;
            case Character.Element.Dark:
                GetComponent<Image>().sprite = BarSprite_Dark;
                ElementIcon.GetComponent<Image>().sprite = IconSprite_Dark;
                break;
            default:
                Debug.Log("Error in switch case.");
                break;
        }
    }
}
