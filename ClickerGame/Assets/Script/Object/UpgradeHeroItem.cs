using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeHeroItem : MonoBehaviour
{
    [Header("Color")]
    public Color standard;
    public Color unaffordable;
    [Header("Text")]
    public Text NameText;
    public Text LevelText;
    public Text PowerText;
    public Text LevelUpText;
    [Header("Button")]
    public GameObject JoinButton;
    public GameObject QuitButton;
    private GlobalManager _globalManager;
    private GameObject hero;
    private string heroName;
    private float heroPrice;
    private float heroPower;
    private float heroSkillPower;
    private float heroLevel;
    private bool isSelectingField = false;

    // Use this for initialization
    void Start()
    {
        _globalManager = GameObject.Find("GlobalManager").gameObject.GetComponent<GlobalManager>();
        InfoUpdate();
    }


    // Update is called once per frame
    void Update()
    {
        InfoUpdate();
        ButtonStatusUpdate();
    }

    public void Purchase()
    {
        if (hero == null) return;

        if (_globalManager.getGold() >= heroPrice)
        {
            _globalManager.setGold(_globalManager.getGold() - heroPrice);
            hero.GetComponent<Hero>().setUpgradeCount(hero.GetComponent<Hero>().getUpgradeCount() + 1);
            hero.GetComponent<Hero>().setPower(Mathf.Round(hero.GetComponent<Hero>().getPower() * 1.3f));
            hero.GetComponent<Hero>().setSkillPower(Mathf.Round(hero.GetComponent<Hero>().getSkillPower() * 1.1f));
            hero.GetComponent<Hero>().setPrice(Mathf.Round(hero.GetComponent<Hero>().getPrice() * 1.15f));
            hero.GetComponent<Hero>().setLevel(hero.GetComponent<Hero>().getLevel() + 1);
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
            heroName = hero.GetComponent<Hero>().getName();
            heroPrice = hero.GetComponent<Hero>().getPrice();
            heroPower = hero.GetComponent<Hero>().getPower();
            heroSkillPower = hero.GetComponent<Hero>().getSkillPower();
            heroLevel = hero.GetComponent<Hero>().getLevel();

            NameText.text = heroName;
            LevelText.text = "Lv. " + heroLevel;
            PowerText.text = "DPS: " + heroPower
                                + "\nSkill Power: " + heroSkillPower;

            LevelUpText.text = "$" + heroPrice + " Level Up"
                                + "\n+ DPS: "
                                + "\n+ Skill Power: ";

            if (_globalManager.getGold() >= heroPrice)
            {
                transform.parent.GetComponent<Image>().color = standard;
            }
            else
            {
                transform.parent.GetComponent<Image>().color = unaffordable;
            }
        }
    }

    private void ButtonStatusUpdate()
    {
        // If hero's level = 0(player haven't own it), 'JoinButton' and 'QuitButton' are not avaliable.
        // If player has not enough money, 'UpgradeButton' is not avaliable.
        if (hero.GetComponent<Hero>().getLevel() == 0)
        {
            JoinButton.GetComponent<Button>().interactable = false;
            QuitButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            JoinButton.GetComponent<Button>().interactable = true;
            QuitButton.GetComponent<Button>().interactable = true;
        }

        if (_globalManager.getGold() < hero.GetComponent<Hero>().getPrice())
            GetComponent<Button>().interactable = false;
        else
            GetComponent<Button>().interactable = true;
    }



    public void setHero(GameObject hero)
    {
        this.hero = hero;
    }
}
