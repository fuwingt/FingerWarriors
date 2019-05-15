using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skills;

public class Pet : MonoBehaviour
{
    public Sprite sprite;
    public GameObject PetItemPrefab;
    public string skillDesc;
    protected new string name;
    protected int level;
    protected float price;
    protected float priceRate;
    protected float skillBuffRate;
    protected GameObject[] FieldArray;
    private GameObject ScrollPanel_Pet;
    private SkillManager skillManager;
    private string skill;


    void Start()
    {
        FieldArray = GlobalManager.FieldArray;
        ScrollPanel_Pet = GameObject.Find("ScrollPanel_Pet");
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        gameObject.SetActive(false);
        createPetItem();
    }

    public void PetEffectOn()
    {
        skillManager.TurnOnPassiveSkill(skill, skillBuffRate, true);
    }

    public void PetEffectOff()
    {
        skillManager.TurnOnPassiveSkill(skill, skillBuffRate, false);
    }

    protected void createPetItem()
    {
        PetItemPrefab = Instantiate(PetItemPrefab, ScrollPanel_Pet.transform);
        PetItemPrefab.name = "Item";
        PetItemPrefab.GetComponent<PetItem>().SetPet(this);
    }

    //  Getter

    public string getName()
    {
        return name;
    }

    public float getPrice()
    {
        return price;
    }

    public float getPriceRate()
    {
        return priceRate;
    }

    public float getSkillBuffRate()
    {
        return skillBuffRate;
    }

    public int getLevel()
    {
        return level;
    }

    public string getSkill()
    {
        return skill;
    }

    public string getSkillDesc()
    {
        return skillDesc;
    }

    //  Setter

    public void setName(string name)
    {
        this.name = name;
    }

    public void setPrice(float price)
    {
        this.price = price;
    }

    public void setPriceRate(float priceRate)
    {
        this.priceRate = priceRate;
    }

    public void setSkillBuffRate(float skillBuffRate)
    {
        this.skillBuffRate = skillBuffRate;
    }

    public void setLevel(int level)
    {
        this.level = level;
    }

    public void setSkill(string skill)
    {
        this.skill = skill;
    }

    public void setSkillDesc(string skillDesc)
    {
        this.skillDesc = skillDesc;
    }

}
