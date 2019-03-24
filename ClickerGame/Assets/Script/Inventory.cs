using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Equipment equipment;
    public Equipment[] equipmentList = new Equipment[30];

    public void AddEquipment(Equipment equipment)
    {
        for (int i = 0; i < equipmentList.Length; i++)
        {
            if (equipmentList[i] == null)
            {
                equipmentList[i] = equipment;
                Debug.Log("Equipment " + equipment.name + " add into inventory successfully.");
                Debug.Log("Player got an equipment: " + equipment.name + " (power: " + equipment.value + ").");
                return;
            }

            // If the loop is run through the whole list and cannot find a empty place, Return.
            if (i == equipmentList.Length - 1 && equipmentList[i] != null)
            {
                Debug.Log("Not enough space in inventory.");
                return;
            }
        }
    }
}
