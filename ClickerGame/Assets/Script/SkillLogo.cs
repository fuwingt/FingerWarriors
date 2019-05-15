using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillLogo : MonoBehaviour
{
    public Text _clickCount;
    public MonsterManager monsterManager;
    private int n;

    // Update is called once per frame
    void Update()
    {
        if (monsterManager.isBossStage)
        {
            n = GlobalManager.currentEnemy.GetComponent<Monster>().getClickShieldCount();
            _clickCount.text = n.ToString();
            if (n <= 0) gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}
