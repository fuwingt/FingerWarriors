using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Equipment")]
public class Equipment : ScriptableObject
{

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

    public void Drop()
    {
        value = Random.Range(10, 15);
    }

    public void EquipmentEffect(Character obj)
    {
        switch (type)
        {
            case Type.Weapon:
                if (rank == Rank.Bronze)
                {
                    // Bronze weapon, increase hero's power with the value between 10 - 15
                    obj.GetComponent<Hero>().setPower(obj.GetComponent<Hero>().getPower() + value);
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

}
