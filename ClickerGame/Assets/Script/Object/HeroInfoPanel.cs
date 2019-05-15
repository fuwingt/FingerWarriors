using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroInfoPanel : MonoBehaviour
{
    public GameObject ElementBorder;
    public GameObject Icon;
    public Text nameText;
    public Text levelText;
    public Text attackPowerText;
    public Text skillPowerText;
    public Text activeSkilDescText;
    public Text passiveSkilDescText;

    //  Private  
    private Hero hero;
    private HeroItem heroItem;



    public void SetHeroInfo(Hero hero, HeroItem heroItem)
    {
        this.hero = hero;
        this.heroItem = heroItem;
        nameText.text = hero.getName();
        levelText.text = "Lv. " + hero.getLevel().ToString();
        attackPowerText.text = "ATK: " + GlobalManager.NumberConverter((int)hero.getAtk());
        skillPowerText.text = "Skill Power: " + GlobalManager.NumberConverter((int)hero.getSkillPower());
        activeSkilDescText.text = hero.getActiveSkillDesc();
        passiveSkilDescText.text = hero.getPassiveSkillDesc();
        Icon.GetComponent<Image>().sprite = hero.Icon;
        ElementBorder.GetComponent<Image>().sprite = hero.ElementBorder;
    }

    public void ClosePanel()
    {
        GlobalManager.isInfoPanelOpen = !GlobalManager.isInfoPanelOpen;
        gameObject.SetActive(false);
    }

}
