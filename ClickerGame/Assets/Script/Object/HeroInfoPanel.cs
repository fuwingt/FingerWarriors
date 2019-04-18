using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroInfoPanel : MonoBehaviour
{
    public GameObject image;
    public Text nameText;
    public Text levelText;
    public Text attackPowerText;
    public Text skillPowerText;
    public Text activeSkilDescText;
    public Text passiveSkilDescText;

    private Hero hero;
    private HeroItem heroItem;

    void Start()
    {
    }

    public void SetHeroInfo(Hero hero, HeroItem heroItem)
    {
        this.hero = hero;
        this.heroItem = heroItem;
        nameText.text = hero.getName();
        levelText.text = hero.getLevel().ToString();
        attackPowerText.text = hero.getPower().ToString();
        skillPowerText.text = hero.getSkillPower().ToString();
        activeSkilDescText.text = hero.getActiveSkillDesc();
        passiveSkilDescText.text = hero.getPassiveSkillDesc();
    }

    public void ClosePanel()
    {
        GlobalManager.isInfoPanelOpen = !GlobalManager.isInfoPanelOpen;
        gameObject.SetActive(false);
    }

}
