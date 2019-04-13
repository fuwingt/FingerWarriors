using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{
    public int currentProgress = 0;
    public int maxProgress;
    private new string name;
    private string description;
    private float reward;



    public Achievement(string name, string description, float reward, int currentProgress, int maxProgress)
    {
        this.name = name;
        this.description = description;
        this.reward = reward;
        this.currentProgress = currentProgress;
        this.maxProgress = maxProgress;
    }

    public void Upgrade()
    {
        reward *= 10;
        currentProgress = 0;
        maxProgress *= 10;
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



}
