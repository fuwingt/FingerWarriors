using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour {

    public Text ItemInfo;   
    private GameObject hero;
    private int itemId;
    private string itemName;
    private float itemPrice;
    private float itemPower;

    void Start()
    {
        itemId = GlobalManager.itemCount - 1;
        hero = GlobalManager.heroList[itemId];
    }
    void Update()
    {
        itemName = hero.GetComponent<Hero>().getName();
        itemPrice = hero.GetComponent<Hero>().getPrice();
        itemPower = hero.GetComponent<Hero>().getPower();
        
        ItemInfo.text = itemName + 
                        "\nPrice: " + itemPrice + 
                        "\n Current Power: " + itemPower;
    }
    
    public void Purchase()
    {
        if(GlobalManager.getGold() >= itemPrice)
        {
            GlobalManager.setGold(GlobalManager.getGold() - itemPrice);
            hero.GetComponent<Hero>().setUpgradeCount(hero.GetComponent<Hero>().getUpgradeCount() + 1);
            hero.GetComponent<Hero>().setPower(Mathf.Round(hero.GetComponent<Hero>().getPower() * 1.3f));
            hero.GetComponent<Hero>().setPrice(Mathf.Round(hero.GetComponent<Hero>().getPrice() * 1.15f));
        }
    }
    

}
