using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pet : MonoBehaviour
{
    public Sprite sprite;
    protected new string name;
    protected int level;
    protected float price;
    protected float priceRate;
    protected float skillBuffRate;
    public string description;
    //protected GameObject _globalManager;
    protected GameObject[] FieldArray = GlobalManager.FieldArray;


    public abstract void PetEffectOn();
    public abstract void PetEffectOff();

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

    public int getlevel()
    {
        return level;
    }

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

}
