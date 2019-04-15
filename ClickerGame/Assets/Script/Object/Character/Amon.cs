using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amon : Hero
{
    public GameObject AmonSkillObjectPrefab;
    private GlobalManager globalManager;
    private MonsterManager monsterManager;
    private GameObject monsterPanel;
    private float requiredEnergy = 50;
    private float energyPerAttack = 10;
    private Hero.Type Type = Hero.Type.Melee;

    void Start()
    {
        globalManager = GameObject.Find("GlobalManager").GetComponent<GlobalManager>();
        monsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        monsterPanel = GameObject.Find("MonsterPanel").gameObject;

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
                // Skill object
                GameObject AmonSkillObject = Instantiate(AmonSkillObjectPrefab, monsterPanel.transform);
                AmonSkillObject.GetComponent<AmonSkillObject>().setResult(result);
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
