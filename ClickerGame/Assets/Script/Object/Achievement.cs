using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{
    public int currentProgress = 0;
    public int maxProgress;
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
    public string GetName()
    {
        return name;
    }
    public string GetDesc()
    {
        return description;
    }

    public float GetReward()
    {
        return reward;
    }

    public GameObject GetItemPrefab()
    {
        return itemPrefab;
    }


    //	Setter
    public void SetName(string name)
    {
        this.name = name;
    }

    public void SetDesc(string desc)
    {
        this.description = desc;
    }

    public void SetReward(float reward)
    {
        this.reward = reward;
    }

    public void SetItemPrefab(GameObject itemPrefab)
    {
        this.itemPrefab = itemPrefab;
    }



}
