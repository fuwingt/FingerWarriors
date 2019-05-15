using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject EquipmentMenu;
    public GameObject EquipmentPrefab;
    public Text EquipmentNameText;
    public Text EquipmentDescText;
    public GameObject EquipButton;
    public Text EquipButtonText;
    public GameObject SellButton;
    public static List<Equipment> equipmentList = new List<Equipment>();
    public static GameObject currentSelectingEquip = null;
    public static GameObject lastSelectingEquip = null;
    private bool isSelectingHero = false;
    private GameObject[] FieldArray;


    void Start()
    {
        FieldArray = GlobalManager.FieldArray;
    }
    void Update()
    {
        UpdateInfo();

        if (currentSelectingEquip != null && isSelectingHero == true)
        {
            if (!currentSelectingEquip.GetComponent<Equipment>().isEquiped)
            {
                EquipButtonText.text = "Selecting...";
                EquipButtonText.fontSize = 35;
            }

            Equip();
        }
    }

    public void AddEquipment()
    {
        // If the list is full, Return.
        if (equipmentList.Count >= 30)
        {
            Debug.Log("Not enough space in inventory.");
            return;
        }
        // 1. Add into List
        Equipment eq = EquipmentPrefab.GetComponent<Equipment>();

        // 2. Show on the Menu
        GameObject ePrefab = Instantiate(EquipmentPrefab, EquipmentMenu.transform);
        ePrefab.GetComponent<Equipment>().setName("Bronze Sword");
        ePrefab.GetComponent<Equipment>().value = Random.Range(10, 16);
        ePrefab.GetComponent<Equipment>().description = "increase " + ePrefab.GetComponent<Equipment>().value + " power to hero.";
        equipmentList.Add(eq);

    }

    public static void ShowSelectingBorder(GameObject equipment)
    {
        equipment.transform.GetChild(0).gameObject.SetActive(true);

        // Check if player is already selecting equip
        if (currentSelectingEquip != null)
        {
            lastSelectingEquip = currentSelectingEquip;
            currentSelectingEquip = equipment;
        }
        else
        {
            currentSelectingEquip = equipment;
        }

        // Shut off the border of lastSelectedEquip
        if (lastSelectingEquip != null && lastSelectingEquip != equipment)
        {
            lastSelectingEquip.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void Equip()
    {
        if (currentSelectingEquip.GetComponent<Equipment>().isEquiped)
        {
            currentSelectingEquip.GetComponent<Equipment>().isEquiped = false;
            currentSelectingEquip.GetComponent<Equipment>().owner.GetComponent<Hero>().PeelOff();
            return;
        }
        // Called by button click
        isSelectingHero = true;
        // Trigger the bool
        TriggerHeroesShiningAnim(isSelectingHero);
        // Get the next screen tap from plsyer
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                // If player clicks on the Field
                if (hit.collider.tag == "FrontField" || hit.collider.tag == "BackField")
                {
                    // If there is a hero on the Field
                    if (hit.collider.transform.childCount == 1)
                    {
                        Hero hero = hit.collider.transform.GetChild(0).gameObject.GetComponent<Hero>();
                        if (hero.currentEquipment != null)
                            hero.PeelOff();

                        hero.SuitUp(currentSelectingEquip);
                    }
                    // If there is nothing on the Field
                    else
                    {

                    }
                }
            }
            isSelectingHero = false;
            TriggerHeroesShiningAnim(isSelectingHero);
        }
    }

    public void Sell()
    {
        if (currentSelectingEquip != null)
            currentSelectingEquip.GetComponent<Equipment>().SellOut();
        else
            Debug.LogError("currentSelectingEquip = NULL.");
    }

    private void UpdateInfo()
    {
        if (currentSelectingEquip != null)
        {
            EquipButton.SetActive(true);
            SellButton.SetActive(true);
            EquipmentNameText.text = currentSelectingEquip.GetComponent<Equipment>().getName();
            EquipmentDescText.text = currentSelectingEquip.GetComponent<Equipment>().description;
            if (currentSelectingEquip.GetComponent<Equipment>().isEquiped == true)
            {
                EquipButtonText.text = "Equiped";
                EquipButtonText.fontSize = 50;
            }
            else
            {
                EquipButtonText.text = "Equip";
                EquipButtonText.fontSize = 50;
            }

        }
        else
        {
            EquipmentNameText.text = "";
            EquipmentDescText.text = "Please choose a equipment";
            EquipButton.SetActive(false);
            SellButton.SetActive(false);
        }
    }

    private void TriggerHeroesShiningAnim(bool isShining)
    {
        for (int i = 0; i < FieldArray.Length; i++)
        {
            if (FieldArray[i].transform.childCount == 1)
            {
                FieldArray[i].transform.GetChild(0).GetComponent<Animator>().SetBool("isShining", isShining);
            }
        }
    }
}
