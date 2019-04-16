using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freyr : Hero
{
    protected override void Start()
    {
        base.Start();
        element = Character.Element.Water;
        type = Hero.Type.Ranged;
        requiredEnergy = 30;
        energyPerAttack = 3;
    }

    public override void Attack(GameObject monster)
    {
        base.Attack(monster);

        globalManager.setEnergy(globalManager.getEnergy() + energyPerAttack);
    }

    public override void ActiveSkill()
    {
        if (monsterManager.GetCurrentMonster() != null)
        {
            if (globalManager.getEnergy() >= requiredEnergy)
            {
                globalManager.setEnergy(globalManager.getEnergy() - requiredEnergy);
                float result = ElementEffect(getElement(), monsterManager.GetCurrentMonster().GetComponent<Monster>().getElement(), skillPower + extraSkillPower);
                monsterManager.GetCurrentMonster().GetComponent<Monster>().BeingAttacked(result);

            }
            else
            {
                // Not enough energy
            }
        }
    }

    public override void PassiveSkill(bool isActivated)
    {

    }

}
