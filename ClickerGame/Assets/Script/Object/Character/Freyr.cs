using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freyr : Hero
{

    private GameObject _globalManager;
    private float requiredEnergy = 30;
    private float energyPerAttack = 3;
    private Hero.Type Type = Hero.Type.Ranged;
    private Character.Element Element = Character.Element.Water;
    private int id = 1;

    void Start()
    {
        _globalManager = GameObject.Find("GlobalManager").gameObject;
    }

    public override void Attack(GameObject monster)
    {
        base.Attack(monster);

        _globalManager.GetComponent<GlobalManager>().setEnergy(_globalManager.GetComponent<GlobalManager>().getEnergy() + energyPerAttack);
    }

    public override void Skill(GameObject monster)
    {
        if (monster != null)
        {
            if (_globalManager.GetComponent<GlobalManager>().getEnergy() >= requiredEnergy)
            {
                _globalManager.GetComponent<GlobalManager>().setEnergy(_globalManager.GetComponent<GlobalManager>().getEnergy() - requiredEnergy);
                float result = ElementEffect(getElement(), monster.GetComponent<Monster>().getElement(), skillPower, extraSkillPower);
                monster.GetComponent<Monster>().setHp(monster.GetComponent<Monster>().getHp() - result);
                ShowFloatingText(skillPower);
                Debug.Log(getName() + ": making damage " + result + " to enemy " + monster.GetComponent<Monster>().getName() + " using Skill!!!");

            }
            else
            {
                // Not enough energy
            }
        }
    }

    public int getID()
    {
        return id;
    }
}
