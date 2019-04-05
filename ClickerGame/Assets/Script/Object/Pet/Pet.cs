using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pet : MonoBehaviour
{
    public Sprite sprite;
    protected new string name;
    protected float price;
    protected float priceRate;

    public abstract void PetSkill();

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
}
