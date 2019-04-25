using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smile : Monster
{
    protected override void Start()
    {
        base.Start();
        maxCoolDown = 5;
        coolDown = 5;
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
