using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{
    public float currentProgress = 0;
    public float maxProgress;
    public bool isAchieved;
    private new string name;
    private string description;
    private float reward;
    private GameObject itemPrefab;


    public Achievement(string name, string description, float reward, int currentProgress, int maxProgress)
    {
        this.name = name;
        this.description = description;
        this.reward = reward;
        this.currentProgress = currentProgress;
        this.maxProgress = maxProgress;
    }

    public void ReceiveReward()
    {
        GlobalManager.setGold(GlobalManager.getGold() + reward);
        Renew();
    }

    private void Renew()
    {
        reward *= 10;
        maxProgress *= 10;
        isAchieved = false;
    }

    //	Getter
    public string getName()
    {
        return name;
    }
    public string getDesc()
    {
        return description;
    }

    public float getReward()
    {
        return reward;
    }

    public GameObject getItemPrefab()
    {
        return itemPrefab;
    }


    //	Setter
    public void setName(string name)
    {
        this.name = name;
    }

    public void setDesc(string desc)
    {
        this.description = desc;
    }

    public void setReward(float reward)
    {
        this.reward = reward;
    }

    public void setItemPrefab(GameObject itemPrefab)
    {
        this.itemPrefab = itemPrefab;
    }



}
