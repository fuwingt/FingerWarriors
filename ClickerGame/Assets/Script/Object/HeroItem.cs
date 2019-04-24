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
    private GameObject heroInfoPanel;
    private GlobalManager globalManager;
    private GameObject[] FieldArray;
    private GameObject ExtraField;
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
        globalManager = GameObject.Find("GlobalManager").gameObject.GetComponent<GlobalManager>();
        FieldArray = GlobalManager.FieldArray;
        ExtraField = GameObject.Find("ExtraField");
    }

    void Update()
    {
        InfoUpdate();
        ButtonStatusUpdate();

        if (isSelectingField == true)
        {
            SwitchHero();
        }
    }

    /* Call by Join button */
    public void SwitchStatus()
    {
        if (hero == null) return;
        isSelectingField = true;
        // Show arrow logo
        for (int i = 0; i < FieldArray.Length; i++)
            FieldArray[i].GetComponent<Field>().activateLogo();
    }


    /* Call by Quit button */
    public void QuitField()
    {
        if (hero == null) return;
        hero.gameObject.SetActive(false);
        hero.isOnField = false;
        hero.PassiveSkill(false);

        hero.transform.parent.GetComponent<Field>().deactivateSkillButton();

        hero.isOnField = false;

        hero.transform.SetParent(ExtraField.transform);
    }


    private void SwitchHero()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "FrontField" || hit.collider.gameObject.tag == "BackField")
                {
                    if (hit.collider.transform.childCount == 0)
                    {
                        // Join
                        hero.gameObject.SetActive(true);
                        hero.isOnField = true;

                        if (hero.transform.parent.tag == "FrontField" || hero.transform.parent.tag == "BackField")
                            hero.transform.parent.GetComponent<Field>().deactivateSkillButton();
                        hero.transform.SetParent(hit.collider.gameObject.transform);
                        //hero.PassiveSkill(false);
                        hero.PassiveSkill(true);

                        hit.collider.GetComponent<Field>().activateSkillButton();

                    }
                    else if (hit.collider.transform.childCount == 1)
                    {
                        // Replace
                        hit.collider.transform.GetChild(0).gameObject.GetComponent<Hero>().PassiveSkill(false);
                        hit.collider.transform.GetChild(0).gameObject.SetActive(false);
                        hit.collider.transform.GetChild(0).SetParent(ExtraField.transform);

                        hero.gameObject.SetActive(true);
                        hero.isOnField = true;
                        hero.transform.parent.GetComponent<Field>().deactivateSkillButton();
                        hero.transform.SetParent(hit.collider.gameObject.transform);
                        hero.PassiveSkill(true);

                        hit.collider.GetComponent<Field>().activateSkillButton();

                    }
                }
                else
                {
                    // Hide the arrow and then return
                }
            }
            isSelectingField = false;
            // Hide arrow logo
            for (int i = 0; i < FieldArray.Length; i++)
                FieldArray[i].GetComponent<Field>().activateLogo();
        }
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

    public void ShowHeroInfoPanel()
    {
        GlobalManager.isInfoPanelOpen = true;
        heroInfoPanel.SetActive(true);
        heroInfoPanel.GetComponent<HeroInfoPanel>().SetHeroInfo(hero, this);
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

        if (heroInfoPanel == null)
        {
            heroInfoPanel = GameObject.Find("HeroInfoPanel");
        }
        else if (heroInfoPanel != null && !GlobalManager.isInfoPanelOpen)
        {
            heroInfoPanel.SetActive(false);
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
            if (hero.isOnField)
            {
                JoinButton.GetComponent<Button>().interactable = false;
                QuitButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                JoinButton.GetComponent<Button>().interactable = true;
                QuitButton.GetComponent<Button>().interactable = false;
            }


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
