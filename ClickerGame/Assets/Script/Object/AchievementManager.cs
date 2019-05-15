using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public GameObject AchievementItemPrefab;
    public GameObject ScrollPanel;
    public Dictionary<string, Achievement> Achievements = new Dictionary<string, Achievement>();

    public void Init()
    {
        Achievements.Add("TapCount", new Achievement("TapCount", "Tap to Attack!", 500, 0, 10));
        Achievements.Add("DefeatBoss", new Achievement("DefeatBoss", "Defeat Boss!", 1000, 0, 10));

        foreach (KeyValuePair<string, Achievement> kvp in Achievements)
        {
            createAchievement(kvp.Key);
        }
    }

    void Update()
    {
        if (Achievements == null) return;
        // Achievements
        Achievements["TapCount"].currentProgress = GlobalManager.tapCount;
        Achievements["DefeatBoss"].currentProgress = GlobalManager.bossTakenDownCount;
    }

    public void createAchievement(string keyword)
    {
        GameObject achievementObject = (GameObject)Instantiate(AchievementItemPrefab, ScrollPanel.transform);
        achievementObject.GetComponent<AchievementItem>().SetAchievement(Achievements[keyword]);
        Achievements[keyword].setItemPrefab(achievementObject);
    }

}
