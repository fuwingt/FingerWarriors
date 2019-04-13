using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItem : MonoBehaviour
{
    // Public 
    public Sprite rewardItemImage;
    public Text descriptionText;
    public Text progressText;
    public Text rewardText;
    public GameObject rewardButton;

    // Private
    private Achievement achievement;

    void Update()
    {
        UpdateInfo();
    }

    // Call by Reward button
    public void ReceiveReward()
    {
        // 1. Receive reward
        // 2. Upgrade the achievement 
        if (achievement != null)
        {
            GlobalManager.setGold(GlobalManager.getGold() + achievement.GetReward());
            achievement.Upgrade();
        }
    }

    private void UpdateInfo()
    {
        if (achievement != null)
        {
            descriptionText.text = achievement.GetDesc();
            progressText.text = achievement.currentProgress + "/" + achievement.maxProgress;
            rewardText.text = achievement.GetReward() + "";
        }

    }

    public void SetAchievement(Achievement achievement)
    {
        this.achievement = achievement;
    }


}
