using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public GameObject SelectingBorder;
    public GameObject User = null;
    public new string name;
    public string description;
    public float price;
    public enum Type
    {
        Weapon,
        Armor,
        Accessorires,
    }

    public enum Rank
    {
        Bronze,
        Iron,
    }

    public Type type = Type.Weapon;
    public Rank rank = Rank.Bronze;
    public int value;
    public bool isEquiped = false;

    public void CreateEquip()
    {
        // This function is to Create the equipment
        name = "Bronze Sword";
        value = Random.Range(10, 15);
        description = "increase " + value + " power to hero.";
    }

    public void SelectEquip()
    {
        // Called by button click
        Inventory.ShowSelectingBorder(transform.gameObject);
    }

    public void EquipmentEffect(GameObject hero)
    {
        switch (type)
        {
            case Type.Weapon:
                if (rank == Rank.Bronze)
                {
                    // Bronze weapon, increase hero's power with the value between 10 - 15
                    hero.GetComponent<Hero>().setExtraPower(value);
                }
                break;

            case Type.Armor:
                break;

            case Type.Accessorires:
                break;

            default:
                Debug.Log("");
                break;
        }
    }

    public void SellOut()
    {
        if (isEquiped == false)
        {
            GlobalManager.setGold(GlobalManager.getGold() + price);
            Destroy(gameObject);
        }
        else
            Debug.Log("Equipment cannot be sell while it is equiped.");

    }

}
