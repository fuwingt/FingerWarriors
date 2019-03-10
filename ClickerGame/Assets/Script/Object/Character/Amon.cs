﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amon : Hero
{
    private GameObject _globalManager;
    private float requiredEnergy = 50;
    private float energyPerAttack = 10;
    private Hero.Type Type = Hero.Type.Melee;
    private int id = 0;

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
                float result = ElementEffect(getElement(), monster.GetComponent<Monster>().getElement(), skillPower_1);
                monster.GetComponent<Monster>().setHp(monster.GetComponent<Monster>().getHp() - result);

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
