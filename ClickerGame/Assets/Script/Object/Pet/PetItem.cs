using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetItem : MonoBehaviour
{
    [Header("Text")]
    public Text NameText;
    public Text description;

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
    }

    void Update()
    {

    }

    public void Upgrade()
    {
        if (pet == null) return;

        if (GlobalManager.getGold() >= pet.getPrice())
        {
            GlobalManager.setGold(GlobalManager.getGold() - pet.getPrice());
            pet.setSkillBuffRate(pet.getSkillBuffRate() * 1.2f);
            pet.setLevel(pet.getlevel() + 1);
            pet.setPrice(pet.getPrice() * pet.getPriceRate());
        }
        else
        {
            Debug.Log("Not enough gold !!");
        }
    }

    public void Join()
    {
        pet.transform.SetParent(PetField.transform);
        pet.PetEffectOn();
    }

    public void Quit()
    {
        pet.transform.SetParent(ExtraField.transform);
        pet.PetEffectOff();
    }

    public void setPet(Pet pet)
    {
        this.pet = pet;
    }

}
