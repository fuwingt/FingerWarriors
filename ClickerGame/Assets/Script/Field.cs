using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Field : MonoBehaviour
{
    [Header("Skill Related")]
    public GameObject SkillButton;
    public GameObject BorderImage;
    public GameObject Image_icon;
    [Header("Border")]
    public Sprite Border_Fire;
    public Sprite Border_Water;
    public Sprite Border_Wind;
    public Sprite Border_Light;
    public Sprite Border_Dark;

    private Hero Hero;


    public void activateSkillButton()
    {
        Hero = transform.GetComponentInChildren<Hero>();
        Image_icon.GetComponent<Image>().sprite = Hero.Icon;
        SkillButton.SetActive(true);
        SkillButton.GetComponent<Skill>().hero = Hero;

        switch (Hero.getElement())
        {
            case Character.Element.Fire:
                BorderImage.GetComponent<Image>().sprite = Border_Fire;
                break;
            case Character.Element.Water:
                BorderImage.GetComponent<Image>().sprite = Border_Water;
                break;
            case Character.Element.Wind:
                BorderImage.GetComponent<Image>().sprite = Border_Wind;
                break;
            case Character.Element.Light:
                BorderImage.GetComponent<Image>().sprite = Border_Light;
                break;
            case Character.Element.Dark:
                BorderImage.GetComponent<Image>().sprite = Border_Dark;
                break;
            default:
                Debug.LogError("Error in switch case.");
                break;
        }
    }

    public void deactivateSkillButton()
    {
        SkillButton.SetActive(false);
    }
}
