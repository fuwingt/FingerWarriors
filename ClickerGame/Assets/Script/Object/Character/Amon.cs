using System.Collections;
using UnityEngine;

public class Amon : Hero
{
    protected override void Start()
    {
        base.Start();
        element = Character.Element.Fire;
        type = Hero.Type.Melee;
        requiredEnergy = 50;
        energyPerAttack = 10;
        activeSkillDesc = "Fire slash attack with damage " + skillPower + " 3 times";
        passiveSkillDesc = "Attack of All the heroes in front x 1.5";
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
                //Debug.Log(getName() + ": making damage " + result + " to enemy " + monster.GetComponent<Monster>().getName() + " using Skill!!!");
            }
            else
            {
                // Not enough energy
            }
        }

    }

    public override void PassiveSkill(bool isActivated)
    {
        float extraBuff = 1.5f;

        for (int i = 0; i < 3; i++)
        {
            Field f = GlobalManager.FieldArray[i].GetComponent<Field>();
            if (isActivated)
                f.fieldBuff *= extraBuff;
            else
                f.fieldBuff /= extraBuff;
        }

    }

}
