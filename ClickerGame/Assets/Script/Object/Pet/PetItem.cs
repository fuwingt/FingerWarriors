using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetItem : MonoBehaviour
{
    [Header("Text")]
    public Text nameText;
    public Text levelText;
    public Text descriptionText;

    [Header("Button")]
    public GameObject JoinButton;
    public GameObject QuitButton;
    public GameObject UpgradeButton;
    private Pet pet;
    private GameObject PetField;
    private GameObject ExtraField;

    void Start()
    {
        PetField = GameObject.Find("PetField");
        ExtraField = GameObject.Find("ExtraField");

        if (pet.getLevel() == 0)
            JoinButton.GetComponent<Button>().interactable = false;

        QuitButton.GetComponent<Button>().interactable = false;
    }

    void Update()
    {
        UpdateInfo();
    }

    public void Upgrade()
    {
        if (pet == null) return;

        if (GlobalManager.getGold() >= pet.getPrice())
        {
            GlobalManager.setGold(GlobalManager.getGold() - pet.getPrice());
            pet.setSkillBuffRate(pet.getSkillBuffRate() * 1.2f);
            pet.setLevel(pet.getLevel() + 1);
            pet.setPrice(pet.getPrice() * pet.getPriceRate());

            if (pet.getLevel() == 1)
                JoinButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            Debug.Log("Not enough gold !!");
        }
    }

    public void Join()
    {
        if (pet.getLevel() == 0) return;

        // If there is a pet already
        if (PetField.transform.childCount != 0)
        {
            PetField.transform.GetChild(0).GetComponent<Pet>().PetItemPrefab.GetComponent<PetItem>().Quit();
        }

        pet.transform.SetParent(PetField.transform);
        pet.gameObject.SetActive(true);
        pet.PetEffectOn();


        JoinButton.GetComponent<Button>().interactable = false;
        QuitButton.GetComponent<Button>().interactable = true;
    }

    public void Quit()
    {
        if (pet.getLevel() == 0) return;
        pet.transform.SetParent(ExtraField.transform);
        pet.gameObject.SetActive(false);
        pet.PetEffectOff();

        JoinButton.GetComponent<Button>().interactable = true;
        QuitButton.GetComponent<Button>().interactable = false;
    }

    public void SetPet(Pet pet)
    {
        this.pet = pet;
        nameText.text = pet.getName();
    }

    private void UpdateInfo()
    {
        descriptionText.text = pet.skillDesc;
        levelText.text = "Lv. " + pet.getLevel();

        if (GlobalManager.getGold() >= pet.getPrice())
            UpgradeButton.GetComponent<Button>().interactable = true;
        else
            UpgradeButton.GetComponent<Button>().interactable = false;

    }
}
