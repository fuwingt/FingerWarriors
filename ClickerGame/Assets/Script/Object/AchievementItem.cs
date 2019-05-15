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
    public GameObject progressBarSprite;
    // Private
    private Achievement achievement;

    void Update()
    {
        UpdateInfo();
    }

    // Call by Reward button
    public void ReceiveReward()
    {
        if (achievement != null)
        {
            achievement.ReceiveReward();
        }
    }

    void UpdateInfo()
    {
        if (achievement != null)
        {
            descriptionText.text = achievement.getDesc();

            progressText.text = achievement.currentProgress + "/" + achievement.maxProgress;
            progressBarSprite.GetComponent<Image>().fillAmount = achievement.currentProgress / achievement.maxProgress;

            if (achievement.currentProgress >= achievement.maxProgress)
            {
                rewardButton.GetComponent<Button>().interactable = true;
                //achievement.currentProgress = achievement.maxProgress;
                achievement.isAchieved = true;
            }
            else
            {
                rewardButton.GetComponent<Button>().interactable = false;
                achievement.isAchieved = false;
            }

        }

    }



    public void SetAchievement(Achievement achievement)
    {
        this.achievement = achievement;
    }


}
