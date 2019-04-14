using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smile : Monster
{
    private float maxCoolDown = 5;
    private float coolDown = 5;

    void Update()
    {
        if (!monsterManager.isBossStage) return;

        coolDown -= Time.deltaTime;
        PassiveSkill();
        if (coolDown <= 0)
        {
            ActiveSkill();
            coolDown = maxCoolDown;
        }
    }

    protected override void PassiveSkill()
    {
        hp += Time.deltaTime;
    }

    protected override void ActiveSkill()
    {
        hp += maxHp / 10;
    }
}
