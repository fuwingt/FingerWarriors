using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freyr : Hero
{
    private TimeCountdownBar timeCountdownBar;
    protected override void Start()
    {
        base.Start();
        element = Character.Element.Water;
        type = Hero.Type.Ranged;
        requiredEnergy = 30;
        energyPerAttack = 3;
        activeSkillDesc = "Make water attack with " + skillPower + " damage. " + "Stop the time 1 second in Boss stage.";
        passiveSkillDesc = "Attack of All the heroes in back x 1.2";
    }

    public override void ActiveSkill()
    {
        if (monsterManager.GetCurrentMonster() != null)
        {
            if (globalManager.getEnergy() >= requiredEnergy)
            {
                globalManager.setEnergy(globalManager.getEnergy() - requiredEnergy);
                float result = ElementEffect(getElement(), monsterManager.GetCurrentMonster().GetComponent<Monster>().getElement(), skillPower + extraSkillPower);
                // Skill object
                GameObject SkillObject = Instantiate(SkillObjectPrefab, monsterPanel.transform);
                SkillObject.GetComponent<SkillObject>().setResult(result);
                ActiveSkillEffect();
            }
            else
            {
                // Not enough energy
            }
        }
    }

    public override void PassiveSkill(bool isActivated)
    {
        float extraBuff = 1.2f;

        for (int i = 0; i < GlobalManager.FieldArray.Length; i++)
        {
            Field f = GlobalManager.FieldArray[i].GetComponent<Field>();

            if (f.tag != "BackField") continue;

            if (isActivated)
                f.fieldBuff *= extraBuff;
            else
                f.fieldBuff /= extraBuff;
        }
    }

    private void ActiveSkillEffect()
    {
        if (monsterManager.isBossStage)
        {
            if (timeCountdownBar == null)
                timeCountdownBar = GameObject.Find("TimeCountdownBar").GetComponent<TimeCountdownBar>();

            timeCountdownBar.StopCounting(1);
        }
    }

}
