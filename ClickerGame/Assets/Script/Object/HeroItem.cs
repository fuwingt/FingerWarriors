using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroItem : MonoBehaviour
{
    [Header("Text")]
    public Text NameText;
    public Text LevelText;
    public Text PowerText;
    public Text UpgradeText;
    [Header("Button")]
    public GameObject JoinButton;
    public GameObject QuitButton;
    public GameObject UpgradeButton;
    private Hero hero;
    private string heroName;
    private float upgradePrice;
    private float heroPower;
    private float heroExtraPower;
    private float heroSkillPower;
    private float heroExtraSkillPower;
    private float heroLevel;
    private bool isSelectingField = false;

    void Start()
    {
        InfoUpdate();
    }

    void Update()
    {
        InfoUpdate();
        ButtonStatusUpdate();
    }

    public void Upgrade()
    {
        if (hero == null) return;

        if (GlobalManager.getGold() >= upgradePrice)
        {
            GlobalManager.setGold(GlobalManager.getGold() - upgradePrice);
            hero.setUpgradeCount(hero.getUpgradeCount() + 1);
            hero.setPower(Mathf.Round(hero.getPower() * 1.3f));
            hero.setSkillPower(Mathf.Round(hero.getSkillPower() * 1.1f));
            hero.setPrice(Mathf.Round(hero.getPrice() * 1.15f));
            hero.setLevel(hero.getLevel() + 1);
        }
        else
        {
            Debug.Log("Not enough gold !!");
        }
    }



    private void InfoUpdate()
    {
        if (hero != null)
        {
            heroName = hero.getName();
            upgradePrice = hero.getPrice();
            heroPower = hero.getPower();
            heroExtraPower = hero.getExtraPower();
            heroSkillPower = hero.getSkillPower();
            heroExtraSkillPower = hero.getExtraSkillPower();
            heroLevel = hero.getLevel();

            NameText.text = heroName;
            LevelText.text = "Lv. " + heroLevel;
            PowerText.text = "DPS: " + (heroPower + heroExtraPower)
                                + "\nSkill Power: " + (heroSkillPower + heroExtraSkillPower);

            UpgradeText.text = "$" + upgradePrice + " Level Up"
                                + "\n+ DPS: "
                                + "\n+ Skill Power: ";

        }
    }

    private void ButtonStatusUpdate()
    {
        // If hero's level = 0(player haven't own it), 'JoinButton' and 'QuitButton' are not avaliable.
        // If player has not enough money, 'UpgradeButton' is not avaliable.
        if (hero.getLevel() == 0)
        {
            JoinButton.GetComponent<Button>().interactable = false;
            QuitButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            JoinButton.GetComponent<Button>().interactable = true;
            QuitButton.GetComponent<Button>().interactable = true;
        }

        if (GlobalManager.getGold() < hero.getPrice())
            UpgradeButton.GetComponent<Button>().interactable = false;
        else
            UpgradeButton.GetComponent<Button>().interactable = true;
    }



    public void setHero(Hero hero)
    {
        this.hero = hero;
    }
}
