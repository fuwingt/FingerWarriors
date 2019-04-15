using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freyr : Hero
{

    private GlobalManager globalManager;
    private MonsterManager monsterManager;
    private float requiredEnergy = 30;
    private float energyPerAttack = 3;
    private Hero.Type Type = Hero.Type.Ranged;
    private Character.Element Element = Character.Element.Water;

    void Start()
    {
        globalManager = GameObject.Find("GlobalManager").GetComponent<GlobalManager>();
        monsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
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
