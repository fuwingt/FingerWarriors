using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public GameObject AchievementItemPrefab;
    public GameObject ScrollPanel;
    public Dictionary<string, Achievement> Achievements = new Dictionary<string, Achievement>();

    void Start()
    {
        Achievements.Add("TapCount", new Achievement("TapCount", "This is desc", 500, 0, 10));

        foreach (KeyValuePair<string, Achievement> kvp in Achievements)
        {
            createAchievement(kvp.Key);
        }
    }

    public void createAchievement(string keyword)
    {
        GameObject achievementObject = (GameObject)Instantiate(AchievementItemPrefab);
        SetAchievementObjectInfo(achievementObject, keyword);
    }

    private void SetAchievementObjectInfo(GameObject achievementObject, string keyword)
    {
        achievementObject.GetComponent<AchievementItem>().SetAchievement(Achievements[keyword]);
        achievementObject.transform.SetParent(ScrollPanel.transform);
        achievementObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
